using System;
using System.Collections.Generic;
using System.Data;
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

namespace study_list_binding
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //-----------------------------------------
            List<string> list = new List<string>();

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("name"));
            //dt_Products.Columns.Add(new DataColumn("Price"));

            DataRow dr = dt.NewRow();
            /*list.Add("apple");
            list.Add("banana");
            foreach (string i in list)
            {
                MessageBox.Show(i);
            };
            

            dr["name"] = list;*/
            dt.Rows.Add(new string[] { (string)(dr["name"] = "apple") });
            dt.Rows.Add(new string[] { (string)(dr["name"] = "banana") });
            //dr["Price"] = "1000";

            gridview.ItemsSource = dt.DefaultView;
            //gridview.ItemsSource = dt.DefaultView;
        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            var data = new { Test1 = "Test1", Test2 = "Test2" };

            gridview.Items.Add(data);
            //dr["Price"] = "1000";


        }
    }
}
