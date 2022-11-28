using SistemaBiblioteca.Livro;
using SistemaBiblioteca.Usuario;

var biblioteca = Biblioteca.GetInstancia();
var usuario = biblioteca.GetUsuario(123);
var livro = biblioteca.GetLivro(100);

if (usuario is not null && livro is not null)
{
    Console.WriteLine(usuario.ToString());
    Console.WriteLine(livro.ToString());
    biblioteca.Emprestar(usuario.Codigo, 100);
    biblioteca.Emprestar(usuario.Codigo, 101);
    biblioteca.Emprestar(usuario.Codigo, 300);
    var result = biblioteca.Emprestar(usuario.Codigo, 400); //aqui ele bloqueou
    Console.WriteLine(result);
    Console.WriteLine($"Número de emprestimos do usuário {usuario.Nome}: {usuario.Emprestimos.Count}");

    foreach (Emprestimo emprestimo in usuario.Emprestimos)
    {
        if (emprestimo is null) Console.WriteLine("Nenhum");
        else Console.WriteLine(emprestimo.ToString());
    }

    var exemplaresEmprestados = biblioteca.Exemplares.FindAll(ex => ex.Status == EmprestimoStatus.Indisponivel);
    foreach (Exemplar ex in exemplaresEmprestados)
    {
        if (ex is null) Console.WriteLine("Nenhum");
        else Console.WriteLine(ex);
    }

    Console.WriteLine("============================");

    biblioteca.Devolver(usuario.Codigo, 100);

    var exemplaresEmprestadosNew = biblioteca.Exemplares.FindAll(ex => ex.Status == EmprestimoStatus.Indisponivel);
    foreach (Exemplar ex in exemplaresEmprestados)
    {
        if (ex is null) Console.WriteLine("Nenhum");
        else Console.WriteLine(ex);
    }

    Console.WriteLine("============================");

    biblioteca.Reservar(usuario.Codigo, 200);

    var reservasEmAberto = biblioteca.Livros.Find(livro => livro.Codigo == 200).Reservas.FindAll(res => res.CodigoUsuario == usuario.Codigo);
    foreach (Reserva reserva in reservasEmAberto)
    {
        if (reserva is null) Console.WriteLine("Nenhuma");
        else Console.WriteLine(reserva);
    }
}

