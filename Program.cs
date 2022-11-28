using SistemaBiblioteca.ConsoleHandler;

var consoleHandler = new ConsoleHandler();

while (true)
{
    var result = consoleHandler.ExecuteCommand(Console.ReadLine());
    Console.WriteLine(result); 
}

