using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Econom
{
    class TO_EXEL
    {
        private int widtg = 0;
        private int a1 = 0;
        public TO_EXEL(string name, DataGridView dataGridView)
        {
           // DataGridView data = dataGridView;
            Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            //ap = dataGridView1.DataSource
            //  ExcelApp.Visible = true;
            export(ExcelWorkSheet, dataGridView);
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorkSheet.Name = name;
            
            ExcelApp.Visible = true;
        }

        private void export(Excel.Worksheet ExcelWorkSheet,DataGridView data )
        {
            ExcelWorkSheet.Cells.HorizontalAlignment = Excel.Constants.xlCenter;
            ExcelWorkSheet.Cells.VerticalAlignment = Excel.Constants.xlCenter;
            ExcelWorkSheet.Cells.Borders.Color = 3;


            for (int i = 1; i < data.Columns.Count + 1; i++)
            {
                ExcelWorkSheet.Cells[1, i] = data.Columns[i - 1].HeaderText;
                ExcelWorkSheet.Range["A1", ExcelWorkSheet.Cells[1, i]].WrapText = true;
            }
           

            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    try
                    {
                        ExcelWorkSheet.Cells[i + 2, j + 1] = data.Rows[i].Cells[j].Value.ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка передачи данных в эксель");
                       
                    }
                    try
                    {
                        if (ExcelWorkSheet.Cells[i + 2, j + 1].ColumnWidth < data.Rows[i].Cells[j].Value.ToString().Length && widtg< data.Rows[i].Cells[j].Value.ToString().Length)
                        {
                           
                            widtg = data.Rows[i].Cells[j].Value.ToString().Length;
                          
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка задание длины ");

                    }

                    ExcelWorkSheet.Cells[i + 2, j + 1].ColumnWidth = widtg;


                    try
                    {
                        if (j == 0)
                        {
                            if(a1< data.Rows[i].Cells[j].Value.ToString().Length)
                            {
                                a1 = data.Rows[i].Cells[j].Value.ToString().Length;
                            }
                            ExcelWorkSheet.Range["A2", ExcelWorkSheet.Cells[i + 2, j + 1]].ColumnWidth =  a1;
                            ExcelWorkSheet.Range["A2", ExcelWorkSheet.Cells[i + 2, j + 1]].HorizontalAlignment = Excel.Constants.xlLeft;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка выравнивания первого столбца");
                    }
                   


                }
            }
        }

        private void export(Excel.Worksheet ExcelWorkSheet, DataTable data)
        {
            ExcelWorkSheet.Cells.HorizontalAlignment = Excel.Constants.xlCenter;
            ExcelWorkSheet.Cells.VerticalAlignment = Excel.Constants.xlCenter;
            ExcelWorkSheet.Cells.Borders.Color = 3;


            for (int i = 1; i < data.Columns.Count + 1; i++)
            {
                ExcelWorkSheet.Cells[1, i] = data.Columns[i - 1].ToString();
                ExcelWorkSheet.Range["A1", ExcelWorkSheet.Cells[1, i]].WrapText = true;
            }


            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    try
                    {
                        ExcelWorkSheet.Cells[i + 2, j + 1] = data.Rows[i][j].ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка передачи данных в эксель");

                    }
                    try
                    {
                        if (ExcelWorkSheet.Cells[i + 2, j + 1].ColumnWidth < data.Rows[i][j].ToString().Length && widtg < data.Rows[i][j].ToString().Length)
                        {

                            widtg = data.Rows[i][j].ToString().Length;

                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка задание длины ");

                    }

                    ExcelWorkSheet.Cells[i + 2, j + 1].ColumnWidth = widtg;


                    try
                    {
                        if (j == 0)
                        {
                            if (a1 < data.Rows[i][j].ToString().Length)
                            {
                                a1 = data.Rows[i][j].ToString().Length;
                            }
                            ExcelWorkSheet.Range["A2", ExcelWorkSheet.Cells[i + 2, j + 1]].ColumnWidth = a1;
                            ExcelWorkSheet.Range["A2", ExcelWorkSheet.Cells[i + 2, j + 1]].HorizontalAlignment = Excel.Constants.xlLeft;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка выравнивания первого столбца");
                    }



                }
            }
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
            ExcelWorkBook.Sheets.Add();
            ExcelWorklo = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            //ap = dataGridView1.DataSource
           // ExcelWorklo = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorklo.Name = lo;
            export(ExcelWorklo, datalo);

            ExcelWorkspb = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(2);
            ExcelWorkspb.Name = spb;
            export(ExcelWorkspb, dataspb);
           

            ExcelWorkspblo = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(3);
            ExcelWorkspblo.Name = spblo;

            export(ExcelWorkspblo, dataspblo);
            // ExcelWorksvod = (Excel.Worksheet)ExcelWorkBook.Worksheets.
            ExcelWorksvod = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(4);
            ExcelWorksvod.Name = svod;
            export(ExcelWorksvod, datasvod);

            ExcelApp.Visible = true;
        }



        public TO_EXEL(string name, DataTable dv)
        {



           


            Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet ExcelWorkSheet;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            //ap = dataGridView1.DataSource
            //  ExcelApp.Visible = true;
           export(ExcelWorkSheet, dv);
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorkSheet.Name = name;

            ExcelApp.Visible = true;

        }
    }
    }
