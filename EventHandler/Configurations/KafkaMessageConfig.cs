using Confluent.Kafka;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Shared.Interfaces;
using Shared.Commands.Direction;
using Shared.Commands.Action;
#nullable disable
namespace EventHandler.Configurations;

public class KafkaJsonSerializer<T> : ISerializer<T>
{
    public byte[] Serialize(T data, SerializationContext context)
    {
        if (data == null)
        {
            throw new ArgumentNullException(nameof(data), "Value cannot be null.");
        }
        var jsonString = JsonConvert.SerializeObject(data, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });
        return System.Text.Encoding.UTF8.GetBytes(jsonString);
    }
}

public class KafkaJsonDeserializer<T> : IDeserializer<T>
{
    public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        if (isNull)
        {
            throw new ArgumentNullException(nameof(data), "Value cannot be null.");
        }
        var jsonString = System.Text.Encoding.UTF8.GetString(data);
        return JsonConvert.DeserializeObject<T>(jsonString, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });
    }
}

public class CommandDeserializer : IDeserializer<ICommand>
{
    private readonly Dictionary<string, Type> _typeMap = new Dictionary<string, Type>
    {
        { nameof(UpCommand), typeof(UpCommand) },
        { nameof(DownCommand), typeof(DownCommand) },
        { nameof(LeftCommand), typeof(LeftCommand) },
        { nameof(RightCommand), typeof(RightCommand) },

        { nameof(ShrinkCommand), typeof(ShrinkCommand) },
        { nameof(GrowCommand), typeof(GrowCommand) },
        { nameof(UndoCommand), typeof(UndoCommand) },
        { nameof(RedoCommand), typeof(RedoCommand) },

    };

    public ICommand Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        if (isNull)
        {
            throw new ArgumentNullException(nameof(data), "Value cannot be null.");
        }

        var jsonString = System.Text.Encoding.UTF8.GetString(data);
        var jsonObject = JObject.Parse(jsonString);
        var type = jsonObject["$type"].Value<string>().Split(',')[0];

        if (_typeMap.TryGetValue(type.Split('.')[^1], out var commandType))
        {
            return (ICommand)jsonObject.ToObject(commandType);
        }

        throw new InvalidOperationException($"Unknown command type: {type}");
    }
}