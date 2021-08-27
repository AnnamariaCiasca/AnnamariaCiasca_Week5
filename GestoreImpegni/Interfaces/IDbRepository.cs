using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreImpegni
{
    interface IDbRepository
    {
        public List<Task> Fetch();
        public void Insert(Task task);
        public void Delete(Task task);
        public void Update(Task task);
    }
}
