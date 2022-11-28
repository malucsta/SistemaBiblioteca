﻿using SistemaBiblioteca.Usuario;

namespace SistemaBiblioteca.ConsoleHandler.Queries
{
    public class GetDetalhesUsuarioQuery
    {
        public static int CodigoUsuario { get; set; }

        public static string? Execute(string command)
        {
            ExtractArguments(command);
            return Biblioteca.GetInstancia().GetDetalhesUsuario(CodigoUsuario);
        }

        public static void ExtractArguments(string command)
        {
            CodigoUsuario = int.Parse(command.Substring(4, command.Length - 4));

        }
    }
}
