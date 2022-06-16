using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ignorant_notepad
{
    class example
    {
        public List<string> list = new List<string>();
        public example()
        {
            list.Add(example1);
            list.Add(example2);
            list.Add(example3);
            list.Add(example4);
            list.Add(example5);
        }
        string example1 = @"void TableRowView()
            {
                while (true)
                {
                    if (!Listthread.IsAlive && !dicthread.IsAlive && !Qthread.IsAlive
                    && !CDicthread.IsAlive && !CQthread.IsAlive)
                    {
                        DataCount.Add(string.Format({0:0,0}, msglist.Count));
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                        {
                            datatable = tv.TableRowView(datatable, DataCount, list_List, list_Dic, list_Q, list_CDic, list_CQ);
                            gridview.ItemsSource = datatable.DefaultView;
                            gridview.ScrollIntoView(gridview.Items[gridview.Items.Count - 1]);
                            timeLabel.Content = 입력된 데이터 :  + (datatable.Rows.Count - 2) + 개;
                            if (int.Parse(cycletext.Text) > cycle + 1)
                            {
                                startbtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                                cycle++;
                            }
                            else
                            {
                                cycle = 0;
                                startbtn.IsEnabled = true;
                                clearbtn.IsEnabled = true;
                            }
                        }));
                        return;
                    }
                }
            }";

        string example2 = @"public DataTable TableRowView(DataTable datatable, List<string> DataCount, List<string> list_List, List<string> list_Dic, List<string> list_Q, List<string> list_CDic, List<string> list_CQ)
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

                datatable.Rows.Add(new string[] { 평균, t.avg(list_List), t.avg(list_Dic), t.avg(list_Q), t.avg(list_CDic), t.avg(list_CQ) });
                List<string> list = new List<string>();
                list = t.rank(t.avg(list_List), t.avg(list_Dic), t.avg(list_Q), t.avg(list_CDic), t.avg(list_CQ));
                datatable.Rows.Add(new string[] { 순위, list[0], list[1], list[2], list[3], list[4]
                });
                return datatable;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }";

        string example3 = @"private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            if (pipecheck.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(Databox.Text) || (int.Parse(Databox.Text) > 10000000) || string.IsNullOrWhiteSpace(cycletext.Text))
                {
                    MessageBox.Show(올바른 데이터를 넣어주세요.);
                }
                else
                {
                    Thread createList = new Thread(new ParameterizedThreadStart(newlist));
                    createList.Start(Databox.Text);
                    clearbtn.IsEnabled = false;
                    startbtn.IsEnabled = false;
                }
            }
            else
            {
                Databox.Clear();
                msglist = Server.Readmsg();
                Thread start = new Thread(StartAllThread);
                start.Start();
                clearbtn.IsEnabled = false;
                startbtn.IsEnabled = false;
            }
        }";

        string example4 = @"private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Thread testpipeopen = new Thread(Server.ServerOpen);
            testpipeopen.IsBackground = true;
            testpipeopen.Start();

            Thread loadpipeopen = new Thread(Client.ClientOpen);
            loadpipeopen.IsBackground = true;
            loadpipeopen.Start();

            datatable.Columns.Add(DataCount, typeof(string));
            datatable.Columns.Add(ListGrid, typeof(string));
            datatable.Columns.Add(DicGrid, typeof(string));
            datatable.Columns.Add(QGrid, typeof(string));
            datatable.Columns.Add(CDicGrid, typeof(string));
            datatable.Columns.Add(CQGrid, typeof(string));
        }";

        string example5 = @"NamedPipeControl Server = new NamedPipeControl(test);
        NamedPipeControl Client = new NamedPipeControl(load);
        //DBConnect DBC = new DBConnect(@C:\Users\sungmin\Desktop, test);
        TestSpeed ts = new TestSpeed();
        TableView tv = new TableView();

        private int cycle { get; set; } // 반복 횟수 카운트
        List<string> msglist = new List<string>();  // 데이터 저장
        List<string> DataCount = new List<string>();  // 데이터 입력 개수 저장
        DataTable datatable = new DataTable(); // 테이블

        // 결과값을 저장
        List<string> list_List = new List<string>();
        List<string> list_Dic = new List<string>();
        List<string> list_Q = new List<string>();
        List<string> list_CDic = new List<string>();
        List<string> list_CQ = new List<string>();";
    }
}
