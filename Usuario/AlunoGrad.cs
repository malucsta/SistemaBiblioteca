using SistemaBiblioteca.Livro;

namespace SistemaBiblioteca.Usuario
{
    public class AlunoGrad : UsuarioAluno
    {
        public AlunoGrad(int codigo, string nome) : base(codigo, nome) { LimiteEmprestimos = 3; }
    }
}
