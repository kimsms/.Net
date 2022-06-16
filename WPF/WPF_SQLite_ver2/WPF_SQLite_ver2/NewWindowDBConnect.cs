using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Threading;

namespace WPF_SQLite_ver2
{
    class NewWindowDBConnect
    {

        private SQLiteConnection conn = null;
        private SQLiteDataReader rdr;
        //private List<string> Vals = new List<string>();
        public ObservableCollection<string> Vals = new ObservableCollection<string>();

        private string sql;


        // DB connection
        public void DBConnection(string filepath)
        {
            conn = null;
            string path = "Data Source=" + filepath;

            conn = new SQLiteConnection(path);
            conn.Open();
        }

        // Show table list
        public ObservableCollection<string> TableNameView() //TODO 객체를 LIST에서 OBServableCollection으로 변경
        {
            string sql = "SELECT name FROM sqlite_master WHERE type = 'table'";
            rdr = DataReadCommand(sql, conn);

            while (rdr.Read())
            {
                Vals.Add((string)rdr["name"]);
            }
            return Vals;
        }

        // View Search Values
        public DataTable ViewSelectVal(string selTB, string selVal)
        {
            try
            {
                Vals.Clear();
                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                dt.Columns.Add(new DataColumn("TableGrid"));
                dt.Columns.Add(new DataColumn("NameGrid"));
                dt.Columns.Add(new DataColumn("AgeGrid"));

                if (selTB == "모든 테이블")
                {
                    sql = "select name from sqlite_master WHERE type = 'table'";

                    rdr = DataReadCommand(sql, conn);
                    while (rdr.Read())
                    {
                        Vals.Add((string)rdr["name"]);
                    }
                    for (int i = 0; i < Vals.Count; i++)
                    {
                        sql = "select name, age from " + Vals[i] + " where name like '%" + selVal + "%'";
                        rdr = DataReadCommand(sql, conn);
                        while (rdr.Read())
                        {
                            dt.Rows.Add(new string[] { ((string)(dr["TableGrid"] = Vals[i])), (string)(dr["NameGrid"] = rdr["name"]), (string)(dr["AgeGrid"] = rdr["age"]) });
                        }
                    }
                    return dt;
                }
                else
                {
                    sql = "select name, age from " + selTB + " where name like '%" + selVal + "%'";

                    rdr = DataReadCommand(sql, conn);
                    while (rdr.Read())
                    {
                        dt.Rows.Add(new string[] {(string)(dr["TableGrid"] = selTB), (string)(dr["NameGrid"] = rdr["name"]), (string)(dr["AgeGrid"] = rdr["age"]) });
                    }
                    return dt;
                }
            }
            catch (Exception)
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }

        // Receive execution result data
        public SQLiteDataReader DataReadCommand(string sql, SQLiteConnection conn)
        {
            SQLiteCommand com = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = com.ExecuteReader();

            return rdr;
        }

    }
}
