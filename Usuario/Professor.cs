﻿namespace SistemaBiblioteca.Usuario
{
    public class Professor : UsuarioObservador
    {
        public int NotificacoesRecebidas { get; set; } = 0; 
        public Professor(int codigo, string nome) : base(codigo, nome) { }

        public override string Devolver()
        {
            return "Livro Devolvido"; 
        }

        public override string Emprestar()
        {
            return "Livro Emprestado";
        }

        public override void Notificar()
        {
            NotificacoesRecebidas++;
            Console.WriteLine($"Professor(a) {Nome} tem {NotificacoesRecebidas} notificações"); 
        }

         private override Tuple<bool, string> PodePegarEmprestimo()
        {
            return (true, 'Tudo OK!')
        }

        public AddObservable(Livro livro)
        {
            this.livrosObservados.Add(livro)
        }

        public override string Reservar()
        {
            return "Livro Reservado";
        }
    }
}
