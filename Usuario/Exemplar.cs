namespace SistemaBiblioteca.Usuario
{
    public class Exemplar
    {
        public int CodigoLivro { get; set; }
        public int CodigoExemplar { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }
        public string Status { get; set; }



        public Exemplar(int codigoLivro, int codigoExemplar, string status) {
            CodigoLivro = codigoLivro;
            CodigoExemplar = codigoExemplar;
            Status = status;
        }


        public void Emprestar(Emprestimo emprestimo)
        {   
            Status = "Indisponivel";
            Emprestimos.Add(emprestimo)
            return;        
        }

         public void Devolver(Emprestimo emprestimo)
        {   
            Status = "Disponivel";
            Emprestimos.Remove(emprestimo);
            emprestimo.Status = 'inativo';
            Emprestimos.Add(emprestimo)
            return;        
        }
    }
}
