using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // Shortest Remaining Time
    public class SRT
    {
        private List<IProcess> processes;

        public SRT(List<IProcess> processes)
        {
            this.processes = processes;
        }

        public void Execute()
        {
            var sortedList = processes.OrderBy(x => x.GetRunningTime());

            foreach (var p in sortedList)
            {
                p.Process();
            }

        }
    }
}
