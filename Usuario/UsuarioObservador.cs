namespace SistemaBiblioteca.Usuario
{
    public abstract class UsuarioObservador : Usuario, IObserver
    {
        public UsuarioObservador(int codigo, string nome) : base(codigo, nome) { }

        public abstract override string Emprestar();
        public abstract override string Reservar();
        public abstract override string Devolver();
        public abstract void Notificar(); 
    }
}
