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

namespace WPF_SQLite
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        string filepath = @"C:\Users\김성민\Desktop\test.db";
        SQLiteConnection conn = null;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        public void command(string sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();
        }

        private void CreateDB_Click(object sender, RoutedEventArgs e)   // DB파일 생성
        {
            SQLiteConnection.CreateFile(filepath);
            IngLabel.Content = "파일생성";
        }

        private void DBConnect_Click(object sender, RoutedEventArgs e)
        {
            string path = "Data Source=" + filepath;
            conn = new SQLiteConnection(path);
            conn.Open();
            IngLabel.Content = "DB연결";
        }

        private void CreateTB_Click_1(object sender, RoutedEventArgs e)
        {
            string sql = "create table member (name varchar(20), age int)";

            /*SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();*/
            command(sql);
            IngLabel.Content = "테이블 생성";
        }

        private void InsertVal_Click(object sender, RoutedEventArgs e)
        {
            string sql = "insert into member values ('홍길동', 19)";
            command(sql);
            IngLabel.Content = "값 넣기";
        }

        private void SelectVal_Click(object sender, RoutedEventArgs e)
        {
            string sql = "select name, age from member";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            string All = "";
            while (rdr.Read()){
                //All += "이름:" + rdr["name"] + " " + " 나이:" + rdr["age"] + "\n";
                viewBox.AppendText("이름:" + rdr["name"]);
                Viewbox2.AppendText("나이:" + rdr["age"]);
            }
            //viewBox.AppendText(All);
            IngLabel.Content = "값 불러오기";
        }

        private void DeleteTB_Click(object sender, RoutedEventArgs e)
        {
            string sql = "drop table member";
            command(sql);
            IngLabel.Content = "테이블 삭제";
        }
    }
}
