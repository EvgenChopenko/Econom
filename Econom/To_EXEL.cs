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

        public TO_EXEL(string lo, DataGridView datalov,string spb, DataGridView dataspbv, string spblo
            , DataGridView dataspblov, string svod, DataGridView svodv)
        {
            DataGridView datalo = datalov;
            DataGridView dataspb = dataspbv;
            DataGridView dataspblo = dataspblov;
            DataGridView datasvod = svodv;

            Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet ExcelWorklo;
            Excel.Worksheet ExcelWorkspb;
            Excel.Worksheet ExcelWorkspblo ;
            Excel.Worksheet ExcelWorksvod;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkBook.Sheets.Add();
            ExcelWorklo = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            //ap = dataGridView1.DataSource
           // ExcelWorklo = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorklo.Name = lo;
            for (int i = 1; i < datalo.Columns.Count + 1; i++)
            {
                ExcelWorklo.Cells[1, i] = datalo.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < datalo.Rows.Count - 1; i++)
            {
                for (int j = 0; j < datalo.Columns.Count; j++)
                {
                    ExcelWorklo.Cells[i + 2, j + 1] = datalo.Rows[i].Cells[j].Value.ToString();
                }
            }
           // ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
           // ExcelWorklo= (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            //ap = dataGridView1.DataSource
            ExcelWorkspb = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(2);
            ExcelWorkspb.Name = spb;
            for (int i = 1; i < dataspb.Columns.Count + 1; i++)
            {
                ExcelWorkspb.Cells[1, i] = dataspb.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataspb.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataspb.Columns.Count; j++)
                {
                    ExcelWorkspb.Cells[i + 2, j + 1] = dataspb.Rows[i].Cells[j].Value.ToString();
                }
            }

            ExcelWorkspblo = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(3);
            ExcelWorkspblo.Name = spblo;
            for (int i = 1; i < dataspblo.Columns.Count + 1; i++)
            {
                ExcelWorkspblo.Cells[1, i] = dataspblo.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataspblo.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataspblo.Columns.Count; j++)
                {
                    ExcelWorkspblo.Cells[i + 2, j + 1] = dataspblo.Rows[i].Cells[j].Value.ToString();
                }
            }

            // ExcelWorksvod = (Excel.Worksheet)ExcelWorkBook.Worksheets.
            ExcelWorksvod = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(4);
            ExcelWorksvod.Name = svod;
            for (int i = 1; i < datasvod.Columns.Count + 1; i++)
            {
                ExcelWorksvod.Cells[1, i] = datasvod.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < datasvod.Rows.Count - 1; i++)
            {
                for (int j = 0; j < datasvod.Columns.Count; j++)
                {
                    ExcelWorksvod.Cells[i + 2, j + 1] = datasvod.Rows[i].Cells[j].Value.ToString();
                }
            }
            
            ExcelApp.Visible = true;
        }
    }
    }
