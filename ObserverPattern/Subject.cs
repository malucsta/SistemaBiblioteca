namespace SistemaBiblioteca.Usuario
{
    public abstract class Subject
    {
        public List<UsuarioObservador> UsuariosNotificaveis { get; set; } = new List<UsuarioObservador>();

        public void AddObserver(UsuarioObservador usuario)
        {
            UsuariosNotificaveis.Add(usuario);
        }

        public void RemoveObserver(UsuarioObservador usuario)
        {
            UsuariosNotificaveis.Remove(usuario);
        }

        public void NotifyObservers()
        {
            foreach (UsuarioObservador usuario in UsuariosNotificaveis)
            {
                usuario.Notificar();
            };

        }
    }
}
