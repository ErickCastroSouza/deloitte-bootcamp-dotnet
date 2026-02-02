using System.Globalization;
using System.Text;
namespace ConsultaDeNotas;

public class Turma
{
    private List<Aluno> alunos;
    private string nomeTurma;

    public Turma(string nomeTurma)
    {
        this.nomeTurma = nomeTurma;
        this.alunos = new List<Aluno>();
    }

    public void AdicionarAluno(Aluno aluno)
    {
        alunos.Add(aluno);
    }

    public void RemoverAluno(int matricula)
    {
        alunos.RemoveAll(a => a.getMatricula() == matricula);
    }

    public Aluno BuscarAluno(string nome)
    {
        return alunos.FirstOrDefault(a => NormalizarTexto(a.getNome()) == NormalizarTexto(nome));
    }

    public List<Aluno> ObterTodos()
    {
        return alunos;
    }

    public void ExibirTodos()
    {
        Console.WriteLine($"\n========== TURMA: {nomeTurma} ==========");
        if (alunos.Count == 0)
        {
            Console.WriteLine("Nenhum aluno na turma.");
            return;
        }

        foreach (var aluno in alunos)
        {
            ExibirAluno(aluno);
        }
    }

    public void ExibirAluno(Aluno aluno)
    {
        Console.WriteLine($"\n--- {aluno.getNome()} ---");
        Console.WriteLine($"Matrícula: {aluno.getMatricula()}");
        Console.WriteLine("Disciplinas:");
        foreach (var disciplina in aluno.getDisciplinas())
        {
            Console.WriteLine($"  - {disciplina}");
        }
        Console.WriteLine("Notas:");
        for (int i = 0; i < aluno.getNotas().Count; i++)
        {
            Console.WriteLine($"  {aluno.getDisciplinas()[i]}: {aluno.getNotas()[i]}");
        }

        double media = aluno.getNotas().Count > 0 ? aluno.getNotas().Average() : 0;
        Console.WriteLine($"Média: {media:F2}");

        string status = media >= 7.0 ? "Aprovado" : "Reprovado";
        Console.WriteLine($"Status: {status}");
    }

    private string RemoverAcentos(string texto)
    {
        string formaNFD = texto.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();
        
        foreach (char ch in formaNFD)
        {
            UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
            if (uc != UnicodeCategory.NonSpacingMark)
                sb.Append(ch);
        }
        
        return sb.ToString();
    }

    private string NormalizarTexto(string texto)
    {
        string normalizado = texto.ToLower();
        string semAcento = RemoverAcentos(normalizado);
        return semAcento;
    }

    public void ExibirAlunoPorNome(string nome)
    {
        Aluno aluno = BuscarAluno(nome);
        if (aluno != null)
        {
            ExibirAluno(aluno);
        }
        else
        {
            Console.WriteLine("\nAluno não encontrado!");
        }
    }
}
