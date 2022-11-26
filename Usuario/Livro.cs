namespace SistemaBiblioteca.Usuario
{
    public class Livro : Subject
    {
        public string Codigo { get; set; }
        public List<Reserva> Reservas { get; set; }
        public List<Usuario> UsuariosNotificaveis { get; set; }
        public string Nome { get; set; }
        public string Editora { get; set; }
        public string Autores { get; set; }
        public string Edicao { get; set; }
        public string AnoPublicacao { get; set; }


        public Livro(int codigo, List<Reserva> reservas, string nome, string editora, string autores, string edicao, string anoPublicacao) {
           Codigo = codigo;
           Reservas = reservas;
           Nome = nome;
           Editora = editora;
           Autores = autores;
           Edicao = edicao;
           AnoPublicacao = anoPublicacao;
        }




        public List<Usuario> AddReserva(Reserva reserva, List<Usuario> usuarios)
        {   
            Reservas.Add(reserva);

            if(Reservas.Length >= 2)
            {
              NotifyObservers();

              foreach (var usuarioNotificado in UsuariosNotificaveis)
                {
                    var usuarioA = usuarios.FindAll(usuario => usuario.Codigo == usuarioNotificado.Codigo);
                    usuarioNotificado.NotificacoesRecebidas = usuarioNotificado.NotificacoesRecebidas + usuarioA.NotificacoesRecebidas;

                    usuarios.Remove(usuarioA);
                    usuarios.Add(usuarioNotificado);
                }
            }

            return usuarios;

            
        }
    }
}
