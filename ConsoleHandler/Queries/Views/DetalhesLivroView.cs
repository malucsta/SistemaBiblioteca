using SistemaBiblioteca.Usuario;

namespace SistemaBiblioteca.ConsoleHandler.Queries.Views
{
    public class DetalhesLivroView
    {
        public string Titulo { get; set; }
        public int QuantidadeReservas { get; set; }
        public List<EmprestimoView>? Emprestimos { get; set; }
        public List<string>? NomeUsuariosReservasEmAberto { get; set; }
        public List<Exemplar> Exemplares { get; set; }

        public override string ToString()
        {
            var retorno = "\n===============================================\n" +
                    $" TITULO: {Titulo.ToUpper()}\n";

            if (NomeUsuariosReservasEmAberto.Count != 0)
            {
                foreach (string nome in NomeUsuariosReservasEmAberto)
                {
                    retorno += $"Reserva em nome de {nome}\n";
                }
            }

            foreach (Exemplar exemplar in Exemplares)
            {
                retorno += "\n";
                retorno += $"Exemplar código {exemplar.CodigoExemplar}, status: {exemplar.Status} \n";

                if (exemplar.Status == Livro.EmprestimoStatus.Indisponivel)
                {
                    var emprestimo = Emprestimos.Find(emprestimo => emprestimo.CodigoExemplar == exemplar.CodigoExemplar);
                    retorno += "\n";
                    retorno += $"==> Detalhes do empréstimo do exemplar {exemplar.CodigoExemplar} \n";
                    retorno += $" Nome do Usuário: {emprestimo.NomeUsuario}\n";
                    retorno += $" Data do Emprestimo: {emprestimo.SolicitacaoData.ToLocalTime()}\n";
                    retorno += $" Data de Devolucao: {emprestimo.DevolucaoData.ToLocalTime()}\n";
                }
            }

            retorno += "\n===============================================\n";

            return retorno;
        }
    }
}
