using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // Priority Scheduling
    public class Priority
    {
        private List<IProcess> processes;

        public Priority(List<IProcess> processes)
        {
            this.processes = processes;
        }

        public void Execute()
        {
            var sortedList = processes.OrderBy(x => x.GetPriority());

            foreach(var p in sortedList)
            {
                p.Process();
            }

        }
    }
}
