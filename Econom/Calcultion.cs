using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Data;


namespace Econom
{
    class Calcultion
    {
        private DataGridView dataGrid;
        private DataSet ds;
       public Calcultion()
        {
            DataGridView dataGrid = new DataGridView();
            DataSet ds = new DataSet();
        }

        public Calcultion(DataGridView dataGrid,DataSet dataSet)
        {
            this.dataGrid = dataGrid;
            this.ds = dataSet;
        }

        public Calcultion(DataGridView dataGrid)
        {
            this.dataGrid = dataGrid;
        }


       public void sum(string NameTabel,int RowIndex,int ColumnIndex)
        {
            try {
                if (dataGrid[NameTabel, RowIndex].Value is null || (dataGrid[NameTabel, RowIndex].Value.ToString() == ""))
                {
                    dataGrid[NameTabel, RowIndex].Value = dataGrid[ColumnIndex, RowIndex].Value;
                }
                else
                {
                    decimal a = decimal.Parse(dataGrid[NameTabel, RowIndex].Value.ToString());
                    dataGrid[NameTabel, RowIndex].Value = decimal.Parse(dataGrid[ColumnIndex, RowIndex].Value.ToString()) + a;
                }
            } catch (Exception e)
            {
                MessageBox.Show("введенены не коректные значения"+e.Message);
            }

            
         }
    }
}
