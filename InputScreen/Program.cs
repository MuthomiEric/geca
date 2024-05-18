using EventHandler;
using InputScreen.Helpers;

var eventHandler = new EventProcessor("localhost:29092", "geca");

while (true)
{
    Console.WriteLine($"Enter Direction:");

    var result = UserInputHelper.GetInput(Console.ReadLine());

    eventHandler.PublishMessage(result);
}