using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreImpegni
{
    class Task { 
    public string Titolo { get; set; }
    public string Descrizione { get; set; }
    public DateTime DataScadenza { get; set; }
    public Livello Importanza { get; set; }
        public bool IsTerminato { get; set; } = false;
    public int? Id { get; set; }

    public Task()
    {

    }
    public Task(string titolo, string descrizione, DateTime dataScadenza, Livello importanza, bool isTerminato, int? id)
    {
            Titolo = titolo;
            Descrizione = descrizione;
            DataScadenza = dataScadenza;
            Importanza = importanza;
            IsTerminato = isTerminato;
            Id = id;
    }
    public enum Livello
    {
        Alta = 1,
        Media = 2,
        Bassa = 3
    }

    public string Print()
    {
        var finished = IsTerminato ? "Terminato" : "Non terminato";
        string dS = DataScadenza.ToString("dd/MM/yyyy");
        return $"{Titolo} - {Descrizione} - {dS} - Priorità: {Importanza} - {finished}";  
    }
}
}
