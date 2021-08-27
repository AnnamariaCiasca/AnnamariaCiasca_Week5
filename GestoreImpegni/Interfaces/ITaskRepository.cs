using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GestoreImpegni.Task;

namespace GestoreImpegni
{
    interface ITaskRepository : IDbRepository
    {
        public List<Task> GetByTitle(string titolo);
        public List<Task> GetTerminated();
        public List<Task> GetByImportanza(Livello importanza);
        public List<Task> GetByDate(DateTime dataScadenza);
      
    }
}