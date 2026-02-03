using System;

namespace VisitantesCheckIn;

public class Visitantes
{
    public string nome {get; set;}
    public int id {get; set;}
    public string documento {get; set;}
    public DateTime horarioChegada {get; set;}
    public bool isPrimeiraVez {get; set;}

    public Visitantes(string nome, int id, string documento, DateTime horarioChegada, bool isPrimeiraVez)
    {
        this.nome = nome;
        this.id = id;
        this.documento = documento;
        this.horarioChegada = horarioChegada;
        this.isPrimeiraVez = isPrimeiraVez;
    }


}
