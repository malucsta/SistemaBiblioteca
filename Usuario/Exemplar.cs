namespace SistemaBiblioteca.Usuario
{
    public class Exemplar
    {
        public string CodigoLivro { get; set; }
        public string CodigoExemplar { get; set; }
        public string Status { get; set; }



        public Exemplar(string codigoLivro, string codigoExemplar, string status) {
            CodigoLivro = codigoLivro;
            CodigoExemplar = codigoExemplar;
            Status = status;
        }


        public void Emprestar()
        {   
            Status = 'Indisponivel';
            return;        
        }

         public void Devolver()
        {   
            Status = 'Disponivel';
            return;        
        }
    }
}
