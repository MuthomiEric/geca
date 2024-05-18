using Confluent.Kafka;
using EventHandler.Configurations;
using Shared.Interfaces;

namespace EventHandler;
public class EventProcessor
{
    private readonly string _topic;

    private readonly string _bootstrapServers;

    public EventProcessor(string bootstrapServers, string topic)
    {
        _topic = topic;

        _bootstrapServers = bootstrapServers;
    }

    public void PublishMessage(ICommand command)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = _bootstrapServers
        };

        using var producer = new ProducerBuilder<string, ICommand>(config)
            .SetKeySerializer(Serializers.Utf8)
            .SetValueSerializer(new KafkaJsonSerializer<ICommand>())
            .Build();

        var deliveryReport = producer.ProduceAsync(_topic, new Message<string, ICommand>
        {
            Key = Guid.NewGuid().ToString(),
            Value = command
        }).Result;

        Console.WriteLine($"Message delivered: {deliveryReport.Value}");

    }

    public void StartConsuming(Action<ICommand> messageHandler)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = _bootstrapServers,
            GroupId = "geca",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<string, ICommand>(config)
            .SetKeyDeserializer(Deserializers.Utf8)
            .SetValueDeserializer(new CommandDeserializer())
            .Build();

        consumer.Subscribe(_topic);

        while (true)
        {
            try
            {
                var consumeResult = consumer.Consume();

                messageHandler(consumeResult.Message.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
