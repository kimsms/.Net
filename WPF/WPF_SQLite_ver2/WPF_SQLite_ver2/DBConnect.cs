using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace WPF_SQLite_ver2
{

    class DBConnect
    {
        private string sql = "";
        public static string nextfilepath;


        SQLiteConnection conn = null;

        //MainWindow main = (MainWindow)System.Windows.Application.Current.MainWindow;

        // Access the main window object
        private static MainWindow mainSet()
        {
            return (MainWindow)System.Windows.Application.Current.MainWindow;
        }


        // Execute SQL
        public void StartCommand(string sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();
        }

        // DB connection
        public void DBConnection(string filepath)
        {
            conn = null;
            string path = "Data Source=" + filepath;

            conn = new SQLiteConnection(path);
            conn.Open();
            //MessageBox.Show("DB연결성공");
            nextfilepath = filepath;
            TableNameView();
            TableDataView();
        }

        // Show table list
        public void TableNameView()
        {
            sql = "SELECT name FROM sqlite_master WHERE type = 'table'";
            SQLiteCommand com = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = com.ExecuteReader();
            MainWindow main = mainSet();
            main.tbcombox.Items.Clear();
            while (rdr.Read())
            {
                main.tbcombox.Items.Add(rdr["name"]);
            }

            if (main.tbcombox.Items.Count == 0)
            {
                main.tbcombox.Items.Add("테이블이 없음");
            }
            main.tbcombox.SelectedIndex = 0;
        }



        // table data display
        public void TableDataView()
        {
            MainWindow main = mainSet();
            try
            {
                sql = "select name, age from " + main.tbcombox.SelectedItem;
                SQLiteCommand com = new SQLiteCommand(sql, conn);
                SQLiteDataReader rdr = com.ExecuteReader();

                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                dt.Columns.Add(new DataColumn("NameGrid"));
                dt.Columns.Add(new DataColumn("AgeGrid"));

                while (rdr.Read())
                {
                    dt.Rows.Add(new string[] { (string)(dr["NameGrid"] = rdr["name"]), (string)(dr["AgeGrid"] = rdr["age"]) });
                }

                main.gridview.ItemsSource = dt.DefaultView;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        // Search for files in a folder
        public void SelectFolder()
        {
            MainWindow main = mainSet();
            FolderBrowserDialog folderpath = new FolderBrowserDialog();
            if (folderpath.ShowDialog().ToString() == "OK")
            {
                nextfilepath = "";

                nextfilepath = folderpath.SelectedPath;
                if (string.IsNullOrWhiteSpace(main.fileName.Text))
                {
                    nextfilepath = nextfilepath + "\\test.db";
                    MessageBox.Show("파일명이 비어있어 test로 지정되었습니다.");
                    main.fileName.Text = "test";
                }
                else
                {
                    nextfilepath = nextfilepath + "\\" + main.fileName.Text + ".db";
                }

                DBConnection(nextfilepath);
                TableNameView();
            }

        }

        // Load selected file
        public void selectFile()
        {
            MainWindow main = mainSet();
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "DB파일 (*.db)|*.db|모든 파일 (*.*)|*.*";

            if (openfile.ShowDialog().ToString() == "OK")
            {
                nextfilepath = openfile.FileName;
                main.fileName.Text = System.IO.Path.GetFileNameWithoutExtension(openfile.FileName);

                DBConnection(nextfilepath);

                TableNameView();
            }
        }

        // create table
        public void createtable()
        {
            MainWindow main = mainSet();
            if (string.IsNullOrWhiteSpace(main.tablename.Text))
            {
                MessageBox.Show("테이블 명을 입력하세요");
                return;
            }
            try
            {
                sql = "create table " + main.tablename.Text + " (name varchar(20), age varchar(20))";
                StartCommand(sql);
                MessageBox.Show(main.tablename.Text + "테이블이 생성됨");
                main.tablename.Clear();
                TableNameView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("테이블이 이미 존재함");
                main.tablename.Focus();
                MessageBox.Show(ex.ToString());
            }
        }

        // data entry
        public void insertValTable()
        {
            MainWindow main = mainSet();
            bool chkInputVal()
            {
                if (main.tbcombox.Text == "테이블이 없음")
                {
                    MessageBox.Show("테이블을 생성하세요");
                    main.tbcombox.Focus();
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(main.namebox.Text))
                {
                    MessageBox.Show("이름을 입력하세요");
                    main.namebox.Focus();
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(main.agebox.Text))
                {
                    MessageBox.Show("나이를 입력하세요");
                    main.agebox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            if (chkInputVal() == true)
            {
                sql = "insert into " + main.tbcombox.Text + " values ('" + main.namebox.Text + "', " + main.agebox.Text + ")";
                StartCommand(sql);
                MessageBox.Show(main.tbcombox.Text + "테이블에 " + main.namebox.Text + ", " + main.agebox.Text + "가 입력되었습니다.");
                main.namebox.Clear();
                main.agebox.Clear();

                TableNameView();
            }
        }

        //  Delete data
        public void deleteVal()
        {
            MainWindow main = mainSet();
            sql = "delete from " + main.tbcombox.Text + " where name ='" + main.namebox.Text + "' and age =" + main.agebox.Text;
            if (main.agebox.Text == "*")
                sql = "delete from " + main.tbcombox.Text + " where name ='" + main.namebox.Text + "'";
            if (main.namebox.Text == "*")
                sql = "delete from " + main.tbcombox.Text + " where age =" + main.agebox.Text;
            StartCommand(sql);

            TableNameView();

            MessageBox.Show(main.tbcombox.Text + "테이블에서 " + main.namebox.Text + ", " + main.agebox.Text + "를 삭제했습니다.");

            main.namebox.Clear();
            main.agebox.Clear();

        }

        // drop table
        public void deleteTable()
        {
            MainWindow main = mainSet();
            if (main.tbcombox.Text == "테이블이 없음")
            {
                MessageBox.Show("테이블이 없습니다.");
                return;
            }
            sql = "drop table " + main.tablename.Text;
            StartCommand(sql);
            TableNameView();
            MessageBox.Show(main.tablename.Text + " 테이블 삭제");
        }


    }
}
