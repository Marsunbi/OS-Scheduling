using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // Round Robin
    public class RR
    {
        private List<IProcess> processes;

        public RR(List<IProcess> processes)
        {
            this.processes = processes;
        }

        public void Execute()
        {
            var sortedList = processes.OrderBy(x => x.GetArrivalTime()).ToList();
            Queue<IProcess> queue = new Queue<IProcess>(sortedList);

            

        }
    }
}
