using SistemaBiblioteca.ConsoleHandler.Commands;
using SistemaBiblioteca.ConsoleHandler.Queries;
using System.Data;

namespace SistemaBiblioteca.ConsoleHandler
{
    public class ConsoleHandler
    {
        public Dictionary<string, Delegate>? Commands { get; set; } = new Dictionary<string, Delegate>();

        public ConsoleHandler()
        {
            RegisterCommands();
        }

        public string? ExecuteCommand(string command)
        {
            var commandToExecute = Commands.Where(k => k.Key.Contains(command.Substring(0, 3))).First();
            return (string?)commandToExecute.Value.DynamicInvoke(command);
        }

        private void RegisterCommands()
        {
            //ações
            Commands.Add("emp", new Func<string, string>(CreateEmprestimoCommand.Execute));
            Commands.Add("res", new Func<string, string>(CreateReservaCommand.Execute));
            Commands.Add("dev", new Func<string, string>(DevolverLivroCommand.Execute));
            Commands.Add("obs", new Func<string, string?>(RegistrarObservadorCommand.Execute));

            //consultas
            Commands.Add("liv", new Func<string, string?>(GetDetalhesLivroQuery.Execute));
            Commands.Add("usu", new Func<string, string?>(GetDetalhesUsuarioQuery.Execute));
            Commands.Add("ntf", new Func<string, string?>(GetNotificacoesQuery.Execute));
        }
    }
}