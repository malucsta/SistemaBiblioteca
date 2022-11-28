using SistemaBiblioteca.Livro;

namespace SistemaBiblioteca.Usuario
{
    public abstract class UsuarioAluno : Usuario
    {
        public int LimiteEmprestimos { get; set; }
        public UsuarioAluno(int codigo, string nome) : base(codigo, nome) { }

        public override string Emprestar(ref Livro livro, List<Exemplar> Exemplares)
        {
            string baseMotivo = "Empréstimo não pôde ser realizado. Motivo:  ";
            var codigoLivro = livro.Codigo;

            if (!livro.PodeSerEmprestado())
            {
                if (livro.Reservas.Any(reserva => reserva.CodigoUsuario == Codigo))
                {
                    var emprestimoRealizado = EmprestarLivro(ref livro, Exemplares);
                    if (emprestimoRealizado is null) return baseMotivo + "não há mais exemplares disponíveis";
                    return emprestimoRealizado;
                }

                return baseMotivo + "Não há mais exemplares disponíveis";
            }

            // se não tem emprestimos atrasados
            if (Emprestimos.Any(emprestimo => emprestimo.DevolucaoData < DateTime.Now))
                return baseMotivo + $"Existem empréstimos atrasados para o usuário {Codigo}";

            // está dentro do limite de emprestimos
            if (Emprestimos.FindAll(emprestimo => emprestimo.Status == EmprestimoStatus.Ativo).Count >= LimiteEmprestimos)
                return baseMotivo + $"Já existem {LimiteEmprestimos} empréstimos em andamento para o usuário {Codigo}";

            //se o usuário não tem nenhum empréstimo em curso daquele mesmo livro
            if (Emprestimos.Any(emprestimo => emprestimo.CodigoLivro == codigoLivro && emprestimo.Status == EmprestimoStatus.Ativo))
                return baseMotivo + $"Já existe um empréstimo em andamento para o livro {livro.Codigo}";

            var emprestimo = EmprestarLivro(ref livro, Exemplares);
            if (emprestimo is null) return baseMotivo + "não há mais exemplares disponíveis";
            return emprestimo;
        }
    }
}