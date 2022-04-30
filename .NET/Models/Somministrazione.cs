namespace Esercizio;

public class Somministrazione
{
    public int id { get; set; }

    public string vaccino { get; set; }

    public string dose { get; set; }

    public DateTime data_somm {get;set;}

    public string note { get; set; }

    public int operatore_id { get; set; }

    public int persona_id { get; set; }

}
