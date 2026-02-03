using System;

namespace Agenda;

public class Contatos
{
    private string nome;
    private string telefone;
    private string email;


    public string GetNome()
    {
        return this.nome;
    }

    public void SetNome(string nome)
    {
        this.nome = nome;
    }
    public string GetTelefone()
    {
        return this.telefone;
    }
    public void SetTelefone(string telefone)
    {
        this.telefone = telefone;
    }

    public string GetEmail()
    {
        return this.email;
    }

    public void SetEmail(string email)
    {
        this.email = email;
    }

    static void CreateContact()
    {
        
    }




}
