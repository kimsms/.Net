using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EventHandle
{
    public class SystemEventArgs : EventArgs
    {
        public string Message { get; set; }
        public object Data { get; set; }

        public SystemEventArgs(string command, string data)
        {
            Message = command;
            Data = data;
        }
    }
      
    class EventTest
    {
        public event EventHandler<SystemEventArgs> CommandStatus;
        private Thread Run = null;
        bool ThreadRunControl = false;

        public EventTest()
        { 
            
        }

        public void Start()
        {
            if (ThreadRunControl) return;

            Run = new Thread(new ThreadStart(ThreadRun));
            Run.Start();

            CommandStatus?.Invoke(this, new SystemEventArgs("TEST", "Start"));
        }
        public void Stop()
        {
            ThreadRunControl = false;
            Run.Join();

            CommandStatus?.Invoke(this, new SystemEventArgs("TEST", "Stop"));
        }

        private void ThreadRun()
        {
            int Cnt = 0;

            ThreadRunControl = true;

            while (ThreadRunControl)
            {
                CommandStatus?.Invoke(this, new SystemEventArgs("TEST", (Cnt++).ToString()));
                Thread.Sleep(200);
            }
        }
    }
}
