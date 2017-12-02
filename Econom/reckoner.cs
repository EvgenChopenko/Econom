using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econom
{
    class reckoner
    {
        private int year = 0;
        private string months = "";
        private int doc = 0;

        /// ////////////////////////////////////////

        private decimal spbobr = 0;
        private decimal loobr = 0;
        private decimal spbloobr = 0;

        /// //////////////////////////////////////////

        private decimal spbpos = 0;
        private decimal lopos = 0;
        private decimal spblopos = 0;

        /// ////////////////////////////////////////////

        private decimal spbsum = 0;
        private decimal losum = 0;
        private decimal spblosum = 0;
        /// 

        private TextBox a = null;
        private TextBox b = null;
        private TextBox c = null;
        private TextBox d = null;

        private decimal A;
        private decimal B;
        private decimal C;
        private decimal D;





        public reckoner()
        {

        }

        public reckoner(int Year, string Months, int Doc)
        {
            this.Year = Year;
            this.Months = Months;
            this.Doc = Doc;
        }
        public reckoner(int Year, string Months, int Doc, decimal totalpos, decimal totalobr, decimal totalsum)
        {
            this.Year = Year;
            this.Months = Months;
            this.Doc = Doc;
            this.Spbloobr = totalobr;
            this.Spblopos = totalpos;
            this.Spblosum = totalsum;
        }

        public int Year { get => year; set => year = value; }
        public string Months { get => months; set => months = value; }
        public int Doc { get => doc; set => doc = value; }
        public decimal Spbobr { get => spbobr; set => spbobr = value; }
        public decimal Loobr { get => loobr; set => loobr = value; }
        public decimal Spbloobr { get => spbloobr; set => spbloobr = value; }
        public decimal Spbpos { get => spbpos; set => spbpos = value; }
        public decimal Lopos { get => lopos; set => lopos = value; }
        public decimal Spblopos { get => spblopos; set => spblopos = value; }
        public decimal Spbsum { get => spbsum; set => spbsum = value; }
        public decimal Losum { get => losum; set => losum = value; }
        public decimal Spblosum { get => spblosum; set => spblosum = value; }


        private void parsestodec(string a, string b, string c)
        {
            try {
                this.C = decimal.Parse(c);
                this.A = decimal.Parse(a);
                this.B = decimal.Parse(b);
            }
            catch
            {
                MessageBox.Show("Введены не числа");
            }


        }

        private void parsestodec(string a, string b)
        {
            try
            {
                this.B = decimal.Parse(b);
                this.A = decimal.Parse(a);
             
            }
            catch
            {
                MessageBox.Show("Введены не числа");
            }


        }

        private void parsestodec(string a, string b, string c, string d)
        {
            try
            {
                this.C = decimal.Parse(c);
                this.A = decimal.Parse(a);
                this.B = decimal.Parse(b);
                this.D = decimal.Parse(d);
            }
            catch
            {
                MessageBox.Show("Введены не числа");
            }


        }


        public void InTEXBOX(TextBox a, TextBox b, TextBox c)
        {


            this.a = a;
            this.b = b;
            this.c = c;

            //parse
            parsestodec(a.Text, b.Text, c.Text);
            ///

            //a + b=c
            if ((this.c.Text is null) || (this.C == 0) || (this.c.Text == ""))
            {
                if (this.A != 0 || this.B != 0)
                {
                    this.C = this.A + this.B;
                }

            }

            //a =c-b
            if ((this.a.Text is null) || (A == 0) || (this.a.Text == ""))
            {
                if (C != 0 || B != 0)
                {
                    A = C - B;
                }

            }

            //b=c-a
            if ((this.b.Text is null) || (B == 0) || (this.b.Text == ""))
            {
                if (C != 0 || A != 0)
                {
                    B = C - A;
                }

            }

            // проверку на целосность 

            if ((C != A + B) || (A != C - B) || (B != C - A))
            {
                C = A + B;
                B = C - A;
                A = C - B;

            }

            this.a.Text = A.ToString();
            this.b.Text = B.ToString();
            this.c.Text = C.ToString();


        }

        public bool indispsto(TextBox a, TextBox b, TextBox c,TextBox d,bool chek)
            {

                if (chek)
            {

                //new a =(a*b + c*d)/(b+d)
                this.a = a;
                this.b = b;
                this.c = c;
                this.d = d;

                parsestodec(a.Text, b.Text, c.Text, d.Text);

                if (((B + D) != 0))
                {
                    if ((A != C)||(B!=D)){


                        C = (A * B + C * D) / (B + D);
                      
                            this.c.Text = C.ToString();
                            this.a.Text = C.ToString();
                        this.d.Text = (B + D).ToString();
                        this.b.Text = (B + D).ToString();
                        return true;




                    }
                    else
                    {
                        this.c.Text = C.ToString();
                        this.a.Text = A.ToString();
                        this.d.Text = this.b.Text;
                        this.b.Text = this.b.Text;
                        return false;
                    }

                    

                }
                else
                {
                    this.c.Text = "0";
                    return false;
                }


            }
            return false;
                
           

        }

        public decimal insumMonts(TextBox a, TextBox b)
        {

            parsestodec(a.Text, b.Text);

            if (A!=0 && B != 0){
                return A * B;
            }
           


            return 0;
        }

        public decimal insum(TextBox a,TextBox b)
        {
            parsestodec(a.Text, b.Text);

            if (A != 0 && B != 0)
            {
                return A + B;
            }



            return 0;
        }

        }


    }

    
  

