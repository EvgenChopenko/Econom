using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econom
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
       private static string[] Months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
       private static  int[] Years = { 2016, 2017, 2018, 2019, 2020, 2021 };
        [STAThread]
        static void Main()
        {
            

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            Application.Run(new Home());
         


        }
        public static int[] GETYERS()
        {
            return Years;
        }
        public static string[] GETMonths()
        {
            return Months;
        }

    }
}
