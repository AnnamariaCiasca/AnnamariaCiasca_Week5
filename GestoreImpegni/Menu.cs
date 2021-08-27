using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreImpegni
{
    class Menu
    {
        internal static void Start()
        {
            bool continuare = true;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPremi 1 per visualizzare tutti gli impegni");   //ok
                Console.WriteLine("Premi 2 per modificare un impegno");              //ok
                Console.WriteLine("Premi 3 per eliminare un impegno");               //ok
                Console.WriteLine("Premi 4 per inserire un nuovo impegno");          //ok
                Console.WriteLine("Premi 5 per visualizzare gli impegni con data maggiore o uguale a quella inserita");  //ok
                Console.WriteLine("Premi 6 per visualizzare gli impegni del livello di importanza inserito");  //ok
                Console.WriteLine("Premi 7 per visualizzare gli impegni portati a termine"); //ok
                Console.WriteLine("Premi 8 per impostare un impegno come 'Terminato'");    //ok
                Console.WriteLine("Premi 0 per uscire");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        Manager.ShowTasks();
                        break;
                    case "2":
                        Manager.UpdateTasks();
                        break;
                    case "3":
                        Manager.DeleteTasks();
                        break;
                    case "4":
                        Manager.InsertTasks();
                        break;
                    case "5":
                        Manager.FilterByDate();
                        break;
                    case "6":
                        Manager.FilterLevel();
                        break;
                    case "7":
                        Manager.ShowTerminated();
                        break;
                   case "8":
                        Manager.SetTerminated();
                        break;
                    case "0":
                        Console.WriteLine("Arrivederci");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Inserisci un valore corretto");
                        break;
                }
            } while (continuare);
        }
    }
}