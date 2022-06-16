using System.Collections.Generic;

namespace WPF_Named_Pipe_Server
{
    internal class Tools
    {
        // Substring 실행
        public string sub(string value, int start)
        {
            return value.Substring(start);
        }
        public string sub(string value, int start, int end)
        {
            return value.Substring(start, end);
        }


        // 평균
        public string avg(List<string> input)
        {
            double temp = 0;
            for (int i = 0; i < input.Count; i++)
            {
                temp += double.Parse(input[i]);
            }
            temp /= input.Count;
            return temp.ToString();
        }

        // 순위
        public List<string> rank(string input, string input1, string input2, string input3, string input4)
        {
            List<string> list = new List<string>
            {
                input,
                input1,
                input2,
                input3,
                input4
            };
            int[] rank = { 1, 1, 1, 1, 1 };
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (float.Parse(list[i]) > float.Parse(list[j]))
                    {
                        rank[i]++;
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = rank[i].ToString();
            }
            return list;
        }
    }
}
