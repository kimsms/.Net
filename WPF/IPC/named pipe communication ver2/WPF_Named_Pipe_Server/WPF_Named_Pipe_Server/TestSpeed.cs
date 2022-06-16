using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;

namespace WPF_Named_Pipe_Server
{
    internal class TestSpeed
    {
        Tools t = new Tools();
        // 리스트 속도 측정
        // TODO 동일한 조건인지 확인할것
        public string testList(List<string> msglist)
        {
            Stopwatch SW = new Stopwatch();
            List<string> testlist = new List<string>();

            SW.Start();
            for (int i = 0; i < msglist.Count; i++)
            {
                //testlist.Add(msglist[i]);
                testlist.Add("1");
            }
            SW.Stop();
            return t.sub(SW.Elapsed.ToString(), 7);
        }

        // 딕셔너리 속도 측정
        public string testDic(List<string> msglist)
        {
            Stopwatch SW = new Stopwatch();
            Dictionary<int, string> dic = new Dictionary<int, string>();

            SW.Start();
            for (int i = 0; i < msglist.Count; i++)
            {
                //dic.Add(i, msglist[i]);
                dic.Add(i, "1");
            }
            SW.Stop();
            return t.sub(SW.Elapsed.ToString(), 7);
        }

        // 큐 속도 측정
        public string testQ(List<string> msglist)
        {
            Stopwatch SW = new Stopwatch();
            Queue Q = new Queue();

            SW.Start();
            for (int i = 0; i < msglist.Count; i++)
            {
                //Q.Enqueue(msglist[i]);
                Q.Enqueue("1");
            }
            SW.Stop();
            return t.sub(SW.Elapsed.ToString(), 7);
        }

        // C딕셔너리 속도 측정
        public string testCDic(List<string> msglist)
        {
            Stopwatch SW = new Stopwatch();
            ConcurrentDictionary<int, string> CDic = new ConcurrentDictionary<int, string>();

            SW.Start();
            for (int i = 0; i < msglist.Count; i++)
            {
                //CDic.TryAdd(i, msglist[i]);
                CDic.TryAdd(i, "1");
            }
            SW.Stop();
            return t.sub(SW.Elapsed.ToString(), 7);
        }

        // C큐 속도 측정
        public string testCQ(List<string> msglist)
        {
            Stopwatch SW = new Stopwatch();
            ConcurrentQueue<string> CQ = new ConcurrentQueue<string>();

            SW.Start();
            for (int i = 0; i < msglist.Count; i++)
            {
                //CQ.Enqueue(msglist[i]);
                CQ.Enqueue("1");
            }
            SW.Stop();
            return t.sub(SW.Elapsed.ToString(), 7);
        }
    }
}
