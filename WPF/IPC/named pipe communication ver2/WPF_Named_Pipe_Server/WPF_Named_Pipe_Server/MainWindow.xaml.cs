using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace WPF_Named_Pipe_Server
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        NamedPipeControl Server = new NamedPipeControl("test");
        NamedPipeControl Client = new NamedPipeControl("load");
        //DBConnect DBC = new DBConnect(@"C:\Users\sungmin\Desktop", "test");
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
        List<string> list_CQ = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // 서버 open
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Thread testpipeopen = new Thread(Server.ServerOpen);
            testpipeopen.IsBackground = true;
            testpipeopen.Start();

            Thread loadpipeopen = new Thread(Client.ClientOpen);
            loadpipeopen.IsBackground = true;
            loadpipeopen.Start();

            datatable.Columns.Add("DataCount", typeof(string));
            datatable.Columns.Add("ListGrid", typeof(string));
            datatable.Columns.Add("DicGrid", typeof(string));
            datatable.Columns.Add("QGrid", typeof(string));
            datatable.Columns.Add("CDicGrid", typeof(string));
            datatable.Columns.Add("CQGrid", typeof(string));
        }

        // 데이터 초기화
        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            datatable.Clear();
            gridview.ItemsSource = null;
            viewbox.Clear();
            DataCount.Clear();
            list_List.Clear();
            list_Dic.Clear();
            list_Q.Clear();
            list_CDic.Clear();
            list_CQ.Clear();
        }

        // 데이터를 받아올 곳을 확인, 입력 받은 데이터 확인
        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            if (pipecheck.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(Databox.Text) || (int.Parse(Databox.Text) > 10000000) || string.IsNullOrWhiteSpace(cycletext.Text))
                {
                    MessageBox.Show("올바른 데이터를 넣어주세요.");
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
        }

        // 새로운 리스트 생성
        private void newlist(object input)
        {
            msglist.Clear();
            for (int i = 0; i < Convert.ToInt32(input); i++)
            {
                msglist.Add(i.ToString());
            }
            Thread start = new Thread(StartAllThread);
            start.Start();
        }

        // 테스트 스레드 일괄 실행
        private void StartAllThread()
        {
            Thread Listthread = new Thread(testList);
            Listthread.Start();

            Thread dicthread = new Thread(testDic);
            dicthread.Start();

            Thread Qthread = new Thread(testQ);
            Qthread.Start();

            Thread CDicthread = new Thread(testCDic);
            CDicthread.Start();

            Thread CQthread = new Thread(testCQ);
            CQthread.Start();

            Thread chkthread = new Thread(TableRowView)
            {
                IsBackground = true
            };
            chkthread.Start();

            // 표 출력
            void TableRowView() // TODO 데이터에이블을 좀더 간편하고 빠르게 출력하는 방법을 찾을것
            {
                while (true)
                {
                    if (!Listthread.IsAlive && !dicthread.IsAlive && !Qthread.IsAlive
                    && !CDicthread.IsAlive && !CQthread.IsAlive)
                    {
                        DataCount.Add(string.Format("{0:0,0}", msglist.Count));
                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                        {
                            datatable = tv.TableRowView(datatable, DataCount, list_List, list_Dic, list_Q, list_CDic, list_CQ);
                            gridview.ItemsSource = datatable.DefaultView;
                            gridview.ScrollIntoView(gridview.Items[gridview.Items.Count - 1]);
                            timeLabel.Content = "입력된 데이터 : " + (datatable.Rows.Count - 2) + "개";
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
            }

            void testList() => list_List.Add(ts.testList(msglist));
            void testDic() => list_Dic.Add(ts.testDic(msglist));
            void testQ() => list_Q.Add(ts.testQ(msglist));
            void testCDic() => list_CDic.Add(ts.testCDic(msglist));
            void testCQ() => list_CQ.Add(ts.testCQ(msglist));

        }

        private void sendbtn_Click(object sender, RoutedEventArgs e)
        {
            Client.Write(viewbox.Text);
        }
    }
}