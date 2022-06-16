using System.Data.SQLite;

namespace DBSQLite
{
    public class DBConnect
    {
        private SQLiteConnection conn { get; set; }
        //private string sql { get; set; }

        // DB연결(파일경로, 파일이름)
        public DBConnect(string filepath, string filename)
        {
            string path = @"Data Source=" + filepath + @"\" + filename + ".db";

            conn = new SQLiteConnection(path);
            conn.Open();
        }

        // 쿼리문 실행
        public void RunSQL(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        // 퀴리문으로 검색한 데이터 리턴
        public SQLiteDataReader ReadSQL(string sql)
        {
            //this.sql = sql;
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            cmd.Dispose();
            rdr.Close();
            return rdr;
        }

    }
}
