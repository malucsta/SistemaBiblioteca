namespace SistemaBiblioteca.Usuario
{
    public class Livro : Subject
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Editora { get; set; }
        public string Autores { get; set; }
        public string Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
        public List<Reserva> Reservas { get; private set; } = new List<Reserva>();
        public List<Exemplar> Exemplares { get; set; } = new List<Exemplar>();

        public Livro(int codigo, string nome, string editora, string autores, string edicao, string anoPublicacao)
        {
            Codigo = codigo;
            Nome = nome;
            Editora = editora;
            Autores = autores;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
        }

        public void AdicionaReserva(Reserva reserva)
        {
            Reservas.Add(reserva);

            if (Reservas.Count > 2)
                NotifyObservers();
        }
        public bool PodeSerEmprestado()
        {
            return Exemplares.Count > Emprestimos.Count;
        }
    }
}
