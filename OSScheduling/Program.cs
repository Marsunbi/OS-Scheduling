using System;
using System.Collections.Generic;
using System.Threading;
using Algorithms;

namespace OSScheduling
{
    internal class Program
    {
        public static class MyTimer
        {
            public static int ServiceTime { get; set; } = 0;
        }

        private static void Main(string[] args)
        {
            var processList = new List<IProcess>();
            var rnd = new Random();
            for (var i = 0; i < 10000; i++)
                processList.Add(new MyProcess("Process# " + i, rnd.Next(1, 10), rnd.Next(1, 1000), rnd.Next(1, 100)));

            // TODO: Run algorithm
            //var alg = new FCFS(processList);
            //SJN alg = new SJN(processList);
            //SRT alg = new SRT(processList);
            //Priority alg = new Priority(processList);
            RR alg = new RR(processList);

            alg.Execute();
            Console.WriteLine("--- Press Enter to continue ---");
            Console.ReadLine();
        }
    }

    internal class MyProcess : IProcess
    {
        private readonly int _arrival;
        private readonly string _name;
        private readonly int _priority;
        private int _runningTime;

        public MyProcess(string name, int runningTime, int priority, int arrival)
        {
            _runningTime = runningTime;
            _priority = priority;
            _name = name;
            _arrival = arrival;
        }
        

        public bool Process()
        {
            Console.WriteLine("Starting {0}", ShowInfo());
            while (_runningTime > 0)
            {
                Thread.Sleep(100);
                Program.MyTimer.ServiceTime++;
                _runningTime--;
            }
            Console.WriteLine("Stopping {0}\tWaittime: {1}", ShowInfo(),GetWaitTime());
            return true;
        }

        // RR Process
        public bool RR_Process()
        {
            return true;
        }

        public int GetRunningTime()
        {
            return _runningTime;
        }

        public int GetPriority()
        {
            return _priority;
        }

        public int GetArrivalTime()
        {
            return _arrival;
        }

        private int GetWaitTime()
        {
            return Program.MyTimer.ServiceTime - _arrival;
        }

        private string ShowInfo()
        {
            return string.Format("\tName: {0}\tPriority: {1}\tRunningTime: {2}\tArrivalTime: {3}", _name, _priority,
                _runningTime, _arrival);
        }
    }
}