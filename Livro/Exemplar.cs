using SistemaBiblioteca.Livro;

namespace SistemaBiblioteca.Usuario
{
    public class Exemplar
    {
        public int CodigoLivro { get; set; }
        public int CodigoExemplar { get; set; }
        //public List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
        public EmprestimoStatus Status { get; set; }

        public Exemplar(int codigoLivro, int codigoExemplar, EmprestimoStatus status)
        {
            CodigoLivro = codigoLivro;
            CodigoExemplar = codigoExemplar;
            Status = status;
        }

        // public void Emprestar(Emprestimo emprestimo)
        // {
        //     Status = EmprestimoStatus.Indisponivel;
        //     Emprestimos.Add(emprestimo);
        // }

        // public void Devolver(Emprestimo emprestimo)
        // {
        //     // atualiza o status do exemplar para disponivel
        //     Status = EmprestimoStatus.Disponivel;

        //     //remove o empréstimo da lista
        //     Emprestimos.Remove(emprestimo);

        //     // atualiza o status do empréstimo para inativo
        //     emprestimo.Status = EmprestimoStatus.Inativo;

        //     //adiciona o emprestimo, agora inativado, à lista
        //     Emprestimos.Add(emprestimo);
        // }

        public override string ToString()
        {
            return $"==> Exemplar do livro {CodigoLivro}: código {CodigoExemplar}, status: {Status}";
        }
    }
}
