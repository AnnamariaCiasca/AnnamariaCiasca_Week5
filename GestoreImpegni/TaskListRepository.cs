using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GestoreImpegni.Task;

namespace GestoreImpegni
{
    internal class TaskListRepository : ITaskRepository
    {
        static List<Task> tasks = new List<Task>
        {
            new Task("Visita", "Dentistica", new DateTime(2021, 12, 10), Task.Livello.Media, false, null),
            new Task("Esame", "Analisi 2", new DateTime(2021, 10, 20), Task.Livello.Alta, false, null),
            new Task("Festa", "Compleanno", new DateTime(2021, 09, 12), Task.Livello.Bassa, false, null),
            new Task("Studiare", "Capitolo 4 di Analisi 2", new DateTime(2021, 10, 09), Task.Livello.Media, true, null),
        };

        public void Delete(Task task)
        {
            tasks.Remove(task);
        }

        public List<Task> Fetch()
        {
            return tasks;
        }

        public void Insert(Task task)
        {
            tasks.Add(task);
        }

        public void Update(Task task)
        {
            Insert(task);
        }

        public List<Task> GetByTitle(string titolo)
        {
            return tasks.Where(t => t.Titolo == titolo).ToList();
        }

        public List<Task> GetTerminated()
        {
            return tasks.Where(t => t.IsTerminato == true).ToList();
        }

        public List<Task> GetByImportanza(Livello importanza)
        {
            return tasks.Where(t => t.Importanza == importanza).ToList();
        }

        public List<Task> GetByDate(DateTime dataScadenza)
        {
            return tasks.Where(t => t.DataScadenza >= dataScadenza).ToList();
        }
    }
}