using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;


namespace WPF_SQLite_ver2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        DBConnect DBC = new DBConnect();
        DataSource DS = new DataSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Enter data into table
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            DBC.insertValTable();
        }

        // create table
        private void createTBbtn_Click(object sender, RoutedEventArgs e)
        {
            DBC.createtable();
        }

        // Delete data
        private void delvalbtn_Click(object sender, RoutedEventArgs e)
        {
            DBC.deleteVal();
        }

        // Open search bar
        private void ShowSelectPage_Click(object sender, RoutedEventArgs e)
        {
            if (tbcombox.Text != "테이블이 없음")
            {
                WPF_SQLite_ver2.Window1 window1 = new WPF_SQLite_ver2.Window1();

                window1.ShowDialog();
            }
            else
            {
                MessageBox.Show("데이터베이스 연결 필요", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // drop table
        private void DelTableBtn_Click(object sender, RoutedEventArgs e)
        {
            DBC.deleteTable();
        }

        // DB file specification
        private void selectFile_Click(object sender, RoutedEventArgs e)
        {
            DBC.selectFile();
        }

        // DB folder designation
        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {

            DBC.SelectFolder();
        }

        // data refresh
        private void tbcombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DBC.TableDataView();
        }

        private void testbtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DBConnect.nextfilepath);
        }


    }
}
