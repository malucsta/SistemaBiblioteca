using SistemaBiblioteca.Usuario;

namespace SistemaBiblioteca.ConsoleHandler.Queries
{
    public class GetDetalhesLivroQuery
    {
        public static int CodigoLivro { get; set; }

        public static string? Execute(string command)
        {
            ExtractArguments(command);
            return Biblioteca.GetInstancia().GetDetalhesLivro(CodigoLivro);
        }

        public static void ExtractArguments(string command)
        {
            CodigoLivro = int.Parse(command.Substring(4, command.Length - 4));
            
        }
    }
}
