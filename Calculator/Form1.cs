using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class calculator : Form
    {
        //this holds whats on the screen
        string screen = "";

        //these two variables store the value entered
        decimal? value1 = null;
        decimal? value2 = null;

        //this stores the arithmetic operator; a space means empty
        char arithmeticOp = ' ';

        //this method display the numbers, the sign, and the decimal...
        //...on the screen
        private void Render(char character)
        {
            screen += character;
            txtScreen.Text = screen;
        }

        public calculator()
        {
            InitializeComponent();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            Render('0');
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Render('1');
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Render('2');
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Render('3');
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Render('4');
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Render('5');
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Render('6');
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Render('7');
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Render('8');
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Render('9');
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            screen = "";
            txtScreen.Text = screen;
            value1 = null;
            value2 = null;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string newString = "";
            for(int counter = 0; counter < (screen.Length - 1); counter++)
            {
                newString += screen[counter];
            }
            screen = newString;
            txtScreen.Text = screen;
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            string screenText = txtScreen.Text;
            if(screenText.IndexOf(".") == -1)
            {
                Render('.');
            }
            
        }

        private void btnChangeSign_Click(object sender, EventArgs e)
        {
            decimal number;
            if(Decimal.TryParse(txtScreen.Text, out number))
            {
                number *= -1;
                screen = Convert.ToString(number);
                txtScreen.Text = screen;
            }
            else
            {
                MessageBox.Show("Must enter a number", "Entry Error");
            }
            
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            value1 = Convert.ToDecimal(screen); //turn the string
                                                //into a decimal
            arithmeticOp = '/';

            screen = "";
            txtScreen.Text = screen;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            value1 = Convert.ToDecimal(screen); //turn the string
                                                //into a decimal
            arithmeticOp = '*';

            screen = "";
            txtScreen.Text = screen;
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            value1 = Convert.ToDecimal(screen); //turn the string
                                                //into a decimal
            arithmeticOp = '-';

            screen = "";
            txtScreen.Text = screen;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            value1 = Convert.ToDecimal(screen); //turn the string
                                                //into a decimal
            arithmeticOp = '+';

            screen = "";
            txtScreen.Text = screen;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                //this checks if there is a value in value1 or not
                value2 = Convert.ToDecimal(screen);

                //this determines what arithmetic operation was selected
                switch (arithmeticOp)
                {
                    case '+':
                        value1 += value2;
                        break;
                    case '-':
                        value1 -= value2;
                        break;
                    case '*':
                        value1 *= value2;
                        break;
                    case '/':
                        value1 /= value2;
                        break;
                }

                //this converts value1 to a string and then displays it
                screen = Convert.ToString(value1);
                txtScreen.Text = screen;
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Can not divide by 0", "Arithmetic Error");
            }
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(screen);
            txtScreen.Text = Convert.ToString(Math.Sqrt(number));
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            decimal number = Convert.ToDecimal(screen);
            decimal reciprocal = 1 / number;
            txtScreen.Text = Convert.ToString(reciprocal);
        }
    }
}
