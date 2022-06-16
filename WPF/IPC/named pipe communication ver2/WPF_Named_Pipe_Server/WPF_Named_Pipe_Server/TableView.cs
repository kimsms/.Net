using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace WPF_Named_Pipe_Server
{
    internal class TableView
    {
        Tools t = new Tools();

        // 테이블 행 추가
        public DataTable TableRowView(DataTable datatable, List<string> DataCount, List<string> list_List, List<string> list_Dic, List<string> list_Q, List<string> list_CDic, List<string> list_CQ)
        {
            try
            {
                int i = list_List.Count-1;
                if (datatable.Rows.Count >= 3)
                {
                    datatable.Rows.RemoveAt(datatable.Rows.Count - 1);
                    datatable.Rows.RemoveAt(datatable.Rows.Count - 1);
                }
                datatable.Rows.Add(new string[] { DataCount[i], list_List[i], list_Dic[i], list_Q[i], list_CDic[i], list_CQ[i] });

                datatable.Rows.Add(new string[] { "평균", t.avg(list_List), t.avg(list_Dic), t.avg(list_Q), t.avg(list_CDic), t.avg(list_CQ) });
                List<string> list = new List<string>();
                list = t.rank(t.avg(list_List), t.avg(list_Dic), t.avg(list_Q), t.avg(list_CDic), t.avg(list_CQ));
                datatable.Rows.Add(new string[] { "순위", list[0], list[1], list[2], list[3], list[4] });
                return datatable;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
    }
}
