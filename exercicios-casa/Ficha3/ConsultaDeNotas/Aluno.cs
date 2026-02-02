namespace ConsultaDeNotas;

public class Aluno
{
    private string nome;
    private int matricula;
    private List<string> disciplinas;
    private List<double> notas;

    public string getNome()
    {
        return nome;
    }
    public void setNome(string nome)
    {
        this.nome = nome;
    }
    public int getMatricula()
    {
        return matricula;
    }
    public void setMatricula(int matricula)
    {
        this.matricula = matricula; 
    }
    public List<string> getDisciplinas()
    {
        return disciplinas;
    }
    public void setDisciplinas(List<string> disciplinas)
    {
        this.disciplinas = disciplinas;
    }
    public List<double> getNotas()
    {
        return notas;
    }
    public void setNotas(List<double> notas)
    {
        this.notas = notas;
    }

    public Aluno(string nome, int matricula, List<string> disciplinas, List<double> notas)
    {
        this.nome = nome;
        this.matricula = matricula;
        this.disciplinas = disciplinas;
        this.notas = notas;
    }

    // Construtor com valores padrões
    public Aluno()
    {
        this.nome = "Sem nome";
        this.matricula = 0;
        this.disciplinas = new List<string>();
        this.notas = new List<double>();
    }

    // Construtor com apenas nome (outros com valores padrões)
    public Aluno(string nome) : this()
    {
        this.nome = nome;
    }

}