namespace SistemaBiblioteca.Usuario
{
    public abstract class Subject
    {
        public List<Usuario> UsuariosNotificaveis { get; set; }

        public void AddObserver(Usuario usuario)
        {
            UsuariosNotificaveis.Add(usuario);
        }

        public void RemoveObserver(Usuario usuario)
        {
            UsuariosNotificaveis.Remove(usuario);
        }


        public string NotifyObservers()
        {
            UsuariosNotificaveis = UsuariosNotificaveis.Select(usuario => {
                usuario.Notificar()
            }).toArray()

        }
    }
}
