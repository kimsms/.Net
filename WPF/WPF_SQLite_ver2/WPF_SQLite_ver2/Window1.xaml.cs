using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;

namespace WPF_SQLite_ver2
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        NewWindowDBConnect NWDBC = new NewWindowDBConnect();

        public Window1()
        {
            InitializeComponent();
        }


        // data retrieval
        private void selectbtn_Click(object sender, RoutedEventArgs e)
        {
            ViewGrid.ItemsSource = NWDBC.ViewSelectVal(combox1.Text, sqlbox.Text).DefaultView;
        }

        // run with enter
        private void sqlbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                selectbtn_Click(sender, e);
            }
        }

        // load data on load
        private void Grid_Loaded_1(object sender, RoutedEventArgs e)
        {
            NWDBC.DBConnection(DBConnect.nextfilepath);
            combox1.Items.Add("모든 테이블");
            ObservableCollection<string> Vals = NWDBC.TableNameView();
            for (int i = 0; i < Vals.Count; i++)
            {
                combox1.Items.Add(Vals[i]);
            }
        }

        private void testbtn_Click(object sender, RoutedEventArgs e)
        {

        }

    }

}