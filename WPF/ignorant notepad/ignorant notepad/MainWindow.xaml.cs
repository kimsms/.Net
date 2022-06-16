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

namespace ignorant_notepad
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        example ex = new example();
        Random ran = new Random();
        List<string> list = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            list = ex.list;
        }

        private void notepad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                notepad.Clear();
                notepad.AppendText(list[ran.Next(0, list.Count)]);
                notepad.SelectionStart = notepad.Text.Length;
                notepad.ScrollToEnd();
            }
            else if (e.Key == Key.Escape) 
            {
                Close();
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            notepad.Focus();
        }
    }
}
