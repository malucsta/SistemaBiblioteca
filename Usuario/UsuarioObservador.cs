namespace SistemaBiblioteca.Usuario
{
    public abstract class UsuarioObservador : Usuario, IObserver
    {
        public int NotificacoesRecebidas { get; set; } = 0;
        public List<Livro> LivrosObservados { get; set; } = new List<Livro>();

        public UsuarioObservador(int codigo, string nome) : base(codigo, nome) { }

        public abstract void Notificar();
    }
}
