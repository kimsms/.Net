using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;

namespace WPF_Named_Pipe_Server
{
    public class NamedPipeControl
    {
        private const int TIMEOUT = 10000;

        private string PipeName { get; set; }

        public static NamedPipeServerStream PipeServerStream { get; set; }
        public NamedPipeClientStream PipeClientStream { get; set; }

        private Queue<string> q = new Queue<string>();

        public NamedPipeControl(string name)
        {
            PipeName = name;
        }

        // PipeName의 이름을 가진 Pipe서버 오픈
        public void ServerOpen()
        {
            try
            {
                PipeServerStream = new NamedPipeServerStream(PipeName);

                PipeServerStream.WaitForConnection();

                Savemsg();
            }
            catch { }
        }

        // 받아온 메세지를 큐에 저장
        private async void Savemsg()
        {
            while (true)
            {
                try
                {
                    var read = new byte[4096];

                    await PipeServerStream.ReadAsync(read, 0, read.Length);

                    var msg = Encoding.UTF8.GetString(read).TrimEnd('\0');

                    q.Enqueue(msg);

                }
                catch { }
            }
        }

        // 큐에 저장된 메세지를 List에 넣어 리턴
        public List<string> Readmsg()
        {
            List<string> list = new List<string>();

            while (q.Count != 0)
            {
                list.Add(q.Dequeue());
            }
            return list;
        }

        // PipeName의 이름을 가진 Pipe서버에 연결
        public void ClientOpen()
        {
            PipeClientStream = new NamedPipeClientStream(PipeName);

            //PipeClientStream.Connect(TIMEOUT);
        }

        // 메세지를 전송
        public async void Write(string msg)
        {
            try
            {
                var write = Encoding.UTF8.GetBytes(msg);

                await PipeClientStream.WriteAsync(write, 0, write.Length);
                PipeClientStream.Flush();
            }
            catch
            {

            }
        }
    }
}
