﻿using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    // First-Come, First-Served
    public class FCFS
    {
        private List<IProcess> _processes;

        public FCFS(List<IProcess> processes)
        {
            this._processes = processes;
        }

        public void Execute()
        {
            var sortedList = _processes.OrderBy(x => x.GetArrivalTime());

            foreach(var p in sortedList)
            {
                p.Process();
            }
        }
    }
}