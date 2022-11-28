using SistemaBiblioteca.Livro;

namespace SistemaBiblioteca.Usuario
{
    public class AlunoPosGrad : UsuarioAluno
    {
        public AlunoPosGrad(int codigo, string nome) : base(codigo, nome) { LimiteEmprestimos = 4; }
    }
}
