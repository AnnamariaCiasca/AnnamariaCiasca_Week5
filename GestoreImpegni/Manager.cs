using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreImpegni
{
    class Manager
    {
        static TaskAdoRepository taskRepository = new TaskAdoRepository();

        //METODI CRUD
        internal static void InsertTasks()     //CREATE

        {

            Task task = new Task();

            task.Titolo = InsertTitolo();
            task.Descrizione = InsertDescrizione();
            task.DataScadenza = InsertDate();
            task.Importanza = InsertImportanza();
            //non faccio inserire all'utente se l'impegno è terminato o meno, di default IsTerminato = false

            taskRepository.Insert(task);
            Console.WriteLine("L'impegno è stato inserito correttamente.");
        }   


        internal static void ShowTasks()   //READ
        {   
            List<Task> tasks = taskRepository.Fetch();
            foreach (var task in tasks)
            Console.WriteLine(task.Print());
        }    


        internal static void UpdateTasks()  //UPDATE
        {
            List<Task> tasks = taskRepository.Fetch();
            int i = 1;
            
                foreach (var t in tasks)
                {
                Console.Write($"Seleziona {i} per modificare ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{ t.Print()}");
                i++;
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            bool isInt;
            int taskScelto;
            do
            {
               

                isInt = int.TryParse(Console.ReadLine(), out taskScelto);

            } while (!isInt || taskScelto <= 0 || taskScelto > tasks.Count);

            Console.WriteLine("Hai scelto di modificare");
            Task task = tasks.ElementAt(taskScelto - 1);
            Console.WriteLine($"{task.Print()}");

            if (task.IsTerminato == true)
            {
                Console.WriteLine("Non puoi modificare questo impegno perché è già stato terminato");  //ho impedito all'utente di modificare un impegno già terminato
            }
            else
            {
                if (task.Id == null)
                {
                    taskRepository.Delete(task);
                }

                bool continuare = true;
                string risposta;
                do
                {
                    Console.WriteLine("Vuoi modificare il titolo? Rispondi si o no");
                    risposta = Console.ReadLine();
                    if (risposta == "si" || risposta == "no")
                        continuare = false;
                } while (continuare);
                if (risposta == "si")
                {
                    task.Titolo = InsertTitolo();
                }

                do
                {
                    Console.WriteLine("Vuoi modificare la descrizione? Rispondi si o no");
                    risposta = Console.ReadLine();
                    if (risposta == "si" || risposta == "no")
                        continuare = false;
                } while (continuare);
                if (risposta == "si")
                {
                    task.Descrizione = InsertDescrizione();
                }

                do
                {
                    Console.WriteLine("Vuoi modificare la data di scadenza? Rispondi si o no");
                    risposta = Console.ReadLine();
                    if (risposta == "si" || risposta == "no")
                        continuare = false;
                } while (continuare);
                if (risposta == "si")
                {
                    task.DataScadenza = InsertDate();
                }

                do
                {
                    Console.WriteLine("Vuoi modificare il livello di importanza? Rispondi si o no");
                    risposta = Console.ReadLine();
                    if (risposta == "si" || risposta == "no")
                        continuare = false;
                } while (continuare);
                if (risposta == "si")
                {
                    task.Importanza = InsertImportanza();
                }

                //l'utente non può modificare se l'impegno è terminato o meno, per settarlo su 'terminato' deve scegliere l'apposita voce dal menù

                Console.WriteLine("Modifica avvenuta correttamente");
                taskRepository.Update(task);
            }
        }  


        internal static void DeleteTasks()
        {
            List<Task> tasks = taskRepository.Fetch();

            int i = 1;
            foreach (var task in tasks)
            {

                Console.Write($"Seleziona {i} per eliminare ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{ task.Print()}");
                i++;
                Console.ForegroundColor = ConsoleColor.White;
            }

            bool isInt;
            int taskScelto;
            do
            {

                isInt = int.TryParse(Console.ReadLine(), out taskScelto);

            } while (!isInt || taskScelto <= 0 || taskScelto > tasks.Count);

            taskRepository.Delete(tasks.ElementAt(taskScelto - 1));
            Console.Write($"Eliminazione avvenuta correttamente ");

        }  //DELETE




        //METODI DI SUPPORTO
        private static bool InsertTerminato()
        {
            bool continuare = true;
            string risposta;
            do
            {
                Console.WriteLine("L'impegno è stato portato a termine? Scrivi si o no");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);

            return risposta == "si" ? true : false;
        }

        private static Task.Livello InsertImportanza()
        {
            
            int importanza = 0;
           
                Console.WriteLine("Inserisci il livello di importanza");
                foreach (var livello in Enum.GetValues(typeof(Task.Livello)))
                {
                    Console.WriteLine($"Premi {(int)livello} per {(Task.Livello)livello}");
                }

            while (!int.TryParse(Console.ReadLine(), out importanza) || importanza < 1 || importanza >3 )
            {
                Console.WriteLine("Inserire valore corretto!");
            }
            return (Task.Livello)importanza;
        }

        private static DateTime InsertDate()
        {
            DateTime dataScadenza = new DateTime();
           
                Console.WriteLine("Inserisci la data di scadenza nel formato ANNO-MESE-GIORNO");
                while (!DateTime.TryParse(Console.ReadLine(), out dataScadenza) || dataScadenza<DateTime.Today)   //Obbligo l'utente ad inserire una data successiva a quella di oggi
                {
                    Console.WriteLine("Inserire una data successiva a quella di oggi");
                }

            return dataScadenza;
        }

        private static string InsertDescrizione()
        {
            string descrizione = String.Empty;
            do
            {
                Console.WriteLine("Inserisci descrizione");
                descrizione = Console.ReadLine();

            } while (String.IsNullOrEmpty(descrizione));
            return descrizione;
        }

        private static string InsertTitolo()
        {
            string titolo = String.Empty;
            do
            {
                Console.WriteLine("Inserisci il titolo dell'impegno:");
                titolo = Console.ReadLine();

            } while (String.IsNullOrEmpty(titolo));
            return titolo;
        }


    
        //METODI PER LE RICHIESTE DEL MENU
        internal static void SetTerminated()
        {
            List<Task> tasks = taskRepository.Fetch();
            int i = 1;
            foreach (var t in tasks)
            {
                Console.WriteLine($"Seleziona {i} per scegliere l'impegno {t.Print()}");
                i++;
            }
            bool isInt;
            int taskScelto;
            do
            {
                Console.WriteLine("Quale impegno vuoi settare su Terminato?");

                isInt = int.TryParse(Console.ReadLine(), out taskScelto);

            } while (!isInt || taskScelto <= 0 || taskScelto > tasks.Count);

            ;
            Task task = tasks.ElementAt(taskScelto - 1);
            if (task.Id == null)
            {
                taskRepository.Delete(task);
            }
            else if (task.IsTerminato == true)
            {
                Console.WriteLine("L'impegno è già stato portato a termine");
            }
            else if (task.IsTerminato == false)
            {
                Console.WriteLine("Ok, l'impegno selezionato è settato su terminato");

                task.IsTerminato = true;

                taskRepository.Update(task);
            }


        }

        internal static void ShowTerminated()
        {
            {
                List<Task> tasks = taskRepository.GetTerminated();
                foreach (var task in tasks)
                    Console.WriteLine(task.Print());
            }
        }

        internal static void FilterLevel()
        {
            Task.Livello importanza = InsertImportanza();
            List<Task> tasks = taskRepository.GetByImportanza(importanza);
            foreach (var t in tasks)
                Console.WriteLine(t.Print());
        }

        internal static void FilterByDate()
        {
            DateTime dataScadenza = InsertDate();
            List<Task> tasks = taskRepository.GetByDate(dataScadenza);
            foreach (var t in tasks)
                Console.WriteLine(t.Print());
        }
    }
}
