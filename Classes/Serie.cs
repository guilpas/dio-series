public class Serie:EntidadeBase
{
    private Genero Genero{get;set;}

    public string Titulo{get;private set;}

    public string Descricao{get;private set;}
    private int Ano{get;set;}
    
    public Serie(int id, Genero genero, string titulo, string descricao, int ano)
    {
        Id=id;
        Genero = genero;
        Titulo = titulo;
        Descricao = descricao;
        Ano=ano;
        Excluido = false;
    }

    public void Excluir(){
        Excluido = true;
    }

    public override string ToString()
    {
        string retorno = "";
        retorno +="Gênero: " + this.Genero + Environment.NewLine;
        retorno += "Título: " + this.Titulo + Environment.NewLine;
        retorno += "Descrição: " + this.Descricao + Environment.NewLine;
        retorno += "Ano de lançamento: " + this.Ano + Environment.NewLine;
        retorno += "Excluido: " + this.Excluido;
        return retorno;
    }
}