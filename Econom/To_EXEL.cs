using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Econom
{
    class TO_EXEL
    {

        public TO_EXEL(string name, DataGridView dataGridView)
        {
            DataGridView data = dataGridView;
            Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            //ap = dataGridView1.DataSource
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorkSheet.Name = name;
            for (int i = 1; i < data.Columns.Count + 1; i++)
            {
                ExcelWorkSheet.Cells[1, i] = data.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < data.Rows.Count - 1; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    ExcelWorkSheet.Cells[i + 2, j + 1] = data.Rows[i].Cells[j].Value.ToString();
                }
            }

            ExcelApp.Visible = true;
        }

    }
}