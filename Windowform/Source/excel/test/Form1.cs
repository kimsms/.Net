using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Insert(0, "홍길동", "19");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void ExportToExcel()
        {

            //DataGridView에 불러온 Data가 아무것도 없을 경우
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("데이터가 없습니다.");
                return;
            }

            bool IsExport = false;

            // Creating a Excel object.

            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                for (int col = 0; col < dataGridView1.Columns.Count; col++)
                {
                    if (cellRowIndex == 1)
                    {
                        worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Columns[col].HeaderText;
                    }
                    cellColumnIndex++;
                }
                cellColumnIndex = 1;
                cellRowIndex++;
                //for (int row = 0; row < dataGridView1.Rows.Count; row++)
                for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                {
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Rows[row].Cells[col].Value.ToString();
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                SaveFileDialog saveFileDialog = GetExcelSave();

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("저장되었습니다.");
                    IsExport = true;
                }

                //Export 성공 했으면 객체들 해제
                if (IsExport)
                {
                    workbook.Close();
                    excel.Quit();
                    workbook = null;
                    excel = null;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private SaveFileDialog GetExcelSave()
        {
            //Getting the location and file name of the excel to save from user.
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.CheckPathExists = true;
            saveDialog.AddExtension = true;
            saveDialog.ValidateNames = true;
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveDialog.DefaultExt = ".xlsx";
            saveDialog.Filter = "Microsoft Excel Workbook (*.xls)|*.xlsx";

            return saveDialog;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }
}
