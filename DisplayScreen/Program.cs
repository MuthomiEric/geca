using DisplayScreen.CommandHandler;
using EventHandler;
using Serilog;
using Serilog.Formatting.Json;
using Shared.Helpers;
#nullable disable

Log.Logger = new LoggerConfiguration()
            .WriteTo.File(new JsonFormatter(), @"C:\Temp\geca.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

var handler = new RequestHandler();

var eventHandler = new EventProcessor("localhost:29092", "geca");

MapFactory.GetMap();

eventHandler.StartConsuming(message =>
{
    Task.Run(() => handler.Handle(message));
});