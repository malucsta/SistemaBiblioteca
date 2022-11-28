using SistemaBiblioteca.Usuario;

namespace SistemaBiblioteca.ConsoleHandler
{
    public class DevolverLivroCommand
    {
        public static int CodigoUsuario { get; set; }
        public static int CodigoLivro { get; set; }

        public static string Execute(string command)
        {
            ExtractArguments(command);
            return Biblioteca.GetInstancia().Devolver(CodigoUsuario, CodigoLivro);

        }

        public static void ExtractArguments(string command)
        {
            var parameters = command.Substring(4, command.Length - 4).Split(" ");
            CodigoUsuario = int.Parse(parameters[0]);
            CodigoLivro = int.Parse(parameters[1]);
        }
    }
}
