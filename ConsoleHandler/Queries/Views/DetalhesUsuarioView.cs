using SistemaBiblioteca.Usuario;

namespace SistemaBiblioteca.ConsoleHandler.Queries.Views
{
    public class DetalhesUsuarioView
    {
        public int CodigoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public List<EmprestimoView> Emprestimos { get; set; }
        public List<Reserva> Reservas { get; set; }

        public override string ToString()
        {
            var retorno = "\n===============================================\n" +
                    $" USUARIO: {NomeUsuario.ToUpper()}\n" +
                    $" código: {CodigoUsuario}\n\n"; 


            retorno += "==> RESERVAS: \n"; 
            foreach (Reserva reserva in Reservas)
            {
                retorno += $"--> Livro {reserva.CodigoLivro} reservado em {reserva.DataSolicitacao} \n\n";
            }

            retorno += "\n==> EMPRÉSTIMOS: \n";
            foreach (EmprestimoView emprestimo in Emprestimos)
            {
                retorno += $"  > Livro {emprestimo.NomeLivro} emprestado no dia {emprestimo.SolicitacaoData} \n";
                retorno += $"  > Status atual: {emprestimo.Status}. Retorno programado para o dia {emprestimo.DevolucaoData} \n";
                retorno += "-------------------\n";
            }

            retorno += "\n===============================================\n";

            return retorno;
        }
    }
}
