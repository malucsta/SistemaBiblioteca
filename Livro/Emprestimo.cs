using SistemaBiblioteca.Livro;

namespace SistemaBiblioteca.Usuario
{
    public class Emprestimo
    {
        public int CodigoLivro { get; set; }
        public int CodigoExemplar { get; set; }
        public int CodigoUsuario { get; set; }
        public EmprestimoStatus Status { get; set; }
        public DateTime SolicitacaoData { get; set; }
        public DateTime DevolucaoData { get; set; }

        public Emprestimo(int codigoLivro, int codigoExemplar, int codigoUsuario)
        {
            CodigoLivro = codigoLivro;
            CodigoUsuario = codigoUsuario;
            Status = EmprestimoStatus.Ativo;
            SolicitacaoData = DateTime.Now;

            //para simplificar, definimos que o período de um emprestimo é de 7 dias
            DevolucaoData = DateTime.Now.AddDays(7);
        }
    }

}