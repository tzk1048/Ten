using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ten
{
    public partial class FormTen : Form
    {

        public int num1;
        public int num2;
        public int num3;
        public int num4;
        public int point;
        public bool calcflag;
        public int btn1;
        public int btn2;
        public int btncnt;
        public int calc1;
        public int calc2;
        public int code;
        public int?[] nb1;
        public int?[] nb2;
        public int?[] nb3;
        public int?[] nb4;

        /*public int?[] nb1 = new int?[1];
        public int?[] nb2 = new int?[1];
        public int?[] nb3 = new int?[1];
        public int?[] nb4 = new int?[1];*/
        public int btnindex;
        Random random = new System.Random();

        public FormTen()
        {
            InitializeComponent();
        }

        private void FormTen_Load(object sender, EventArgs e)
        {
            point = 0;
            calcflag = false;
            newquestion();
        }

        private void createNumbers()
        {
            num1 = random.Next(0, 9);
            num2 = random.Next(0, 9);
            num3 = random.Next(0, 9);
            num4 = random.Next(0, 9);

            numberLabel.Text = num1.ToString() + num2.ToString() + num3.ToString() + num4.ToString();
        }

        public void createButtons()
        {
            numButton1.Visible = true;
            numButton2.Visible = true;
            numButton3.Visible = true;
            numButton4.Visible = true;

            nb1 = new int?[1];
            nb2 = new int?[1];
            nb3 = new int?[1];
            nb4 = new int?[1];
            /*Array.Clear(nb1, 0, nb1.Length);
            Array.Clear(nb2, 0, nb2.Length);
            Array.Clear(nb3, 0, nb3.Length);
            Array.Clear(nb4, 0, nb4.Length);*/

            btnindex = 0;

            nb1[0] = num1;
            nb2[0] = num2;
            nb3[0] = num3;
            nb4[0] = num4;

            numButton1.Text = num1.ToString();
            numButton2.Text = num2.ToString();
            numButton3.Text = num3.ToString();
            numButton4.Text = num4.ToString();

            btncnt = 4;
        }

        public void newquestion()
        {
            createNumbers();
            createButtons();
            ClearArea();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            newquestion();
        }

        private void ButtonClick(int btn,string text)
        {
            switch (point)
            {
                case 0:
                    calcNum1Label.Text = text;
                    calc1 = int.Parse(text);
                    btn1 = btn;
                    break ;
                case 1:
                    calccodeLabel.Text = text;
                    code = btn;
                    break ;
                case 2:
                    calcNum2Label.Text = text;
                    calc2 = int.Parse(text);
                    btn2 = btn;
                    break ;
            }

            ChangeArea(point, ++point) ;

            if(point == 3)
            {
                calcflag = true;
            }

            if (calcflag)
            {
                switch (code)
                {
                    case 0: 
                        ansewrLabel.Text = Plus(calc1,calc2);
                        break ;
                    case 1:
                        ansewrLabel.Text = Minus(calc1, calc2);
                        break ;
                    case 2:
                        ansewrLabel.Text = Times(calc1, calc2);
                        break ;
                    case 3:
                        ansewrLabel.Text = Devided(calc1, calc2);
                        break ;
                    case 4:
                        ansewrLabel.Text = Power(calc1, calc2);
                        break ;
                }
            }
        }

        private string Plus(int num1, int num2)
        {
            int result = num1 + num2;
            return result.ToString();
        }

        private string Minus(int num1, int num2)
        {
            int result = num1 - num2;

            if (result < 0)
            {
                return "E";
            }else
            {
                return result.ToString();
            }
        }

        private string Times(int num1,int num2)
        {
            int result = num1 * num2;
            
            if(result < 100)
            {
                return result.ToString();
            }else
            {
                return "E";
            }
        }

        private string Devided(int num1,int num2)
        {

            if(num2 != 0 && num1 >= num2)
            {
                if(num1 % num2 == 0)
                {
                    return (num1 / num2).ToString();
                }else
                {
                    return "E";
                }
            }else
            {
                return "E";
            }
        }

        private string Power(int num1,int num2)
        {
            int result=1;

            if (num2 != 0)
            {
                for (int i = 0; i < num2; i++)
                {
                    result *= num1;
                }
            }else
            {
                result = 1;
            }

            if (result < 100)
            {
                return result.ToString();
            }
            else
            {
                return "E";
            }

        }

        public void ChangeArea(int nowpoint,int nextpoint)
        {
            switch (nowpoint)
            {
                case 0: calcNum1Label.BackColor = SystemColors.Control; break;
                case 1: calccodeLabel.BackColor = SystemColors.Control; break;
                case 2: calcNum2Label.BackColor = SystemColors.Control; break;
                case 3: break;

            }

            switch (nextpoint)
            {
                case 0: calcNum1Label.BackColor = SystemColors.ControlLightLight; break;
                case 1: calccodeLabel.BackColor = SystemColors.ControlLightLight; break;
                case 2: calcNum2Label.BackColor = SystemColors.ControlLightLight; break;
                case 3: break;

            }
        }

        public void ClearArea()
        {
            calcNum1Label.Text = "";
            calccodeLabel.Text = "";
            calcNum2Label.Text = "";
            ansewrLabel.Text = "";
            ChangeArea(point,0);
            point = 0;
            calcflag = false;
        }

        private void numButton1_Click(object sender, EventArgs e)
        {
            if (point != 1)
            {
                ButtonClick(0,numButton1.Text);
            }
        }

        private void numButton2_Click(object sender, EventArgs e)
        {
            if (point != 1)
            {
                ButtonClick(1,numButton2.Text);
            }
        }

        private void numButton3_Click(object sender, EventArgs e)
        {
            if (point != 1)
            {
                ButtonClick(2,numButton3.Text);
            }
        }

        private void numButton4_Click(object sender, EventArgs e)
        {
            if (point != 1)
            {
                ButtonClick(3,numButton4.Text);
            }
        }

        private void plusCalcButton_Click(object sender, EventArgs e)
        {
            if (point == 1)
            {
                ButtonClick(0,plusCalcButton.Text);
            }
        }

        private void MinusCalcButton_Click(object sender, EventArgs e)
        {
            if (point == 1)
            {
                ButtonClick(1,MinusCalcButton.Text);
            }
        }

        private void timesCalcButton_Click(object sender, EventArgs e)
        {
            if (point == 1)
            {
                ButtonClick(2,timesCalcButton.Text);
            }
        }

        private void devideCalcButton_Click(object sender, EventArgs e)
        {
            if (point == 1)
            {
                ButtonClick(3,devideCalcButton.Text);
            }
        }

        private void powerCalcButton_Click(object sender, EventArgs e)
        {
            if (point == 1)
            {
                ButtonClick(4,powerCalcButton.Text);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearArea();
        }

        private void calcNum1Label_Click(object sender, EventArgs e)
        {
            ChangeArea(point, 0);
            point = 0;
        }

        private void calccodeLabel_Click(object sender, EventArgs e)
        {
            ChangeArea(point, 1);
            point = 1;
        }

        private void calcNum2Label_Click(object sender, EventArgs e)
        {
            ChangeArea(point, 2);
            point = 2;
        }

        private void putButton_Click(object sender, EventArgs e)
        {
            if(int.TryParse(ansewrLabel.Text, out int answer))
            {
                if (btnindex == nb1.Length - 1)
                {
                    Array.Resize(ref nb1, nb1.Length + 1);
                    Array.Resize(ref nb2, nb2.Length + 1);
                    Array.Resize(ref nb3, nb3.Length + 1);
                    Array.Resize(ref nb4, nb4.Length + 1);
                    nb1[nb1.Length - 1] = nb1[nb1.Length - 2];
                    nb2[nb2.Length - 1] = nb2[nb2.Length - 2];
                    nb3[nb3.Length - 1] = nb3[nb3.Length - 2];
                    nb4[nb4.Length - 1] = nb4[nb4.Length - 2];
                }

                btnindex++;

                switch (btn1)
                {
                    case 0:
                        numButton1.Text = ansewrLabel.Text;
                        nb1[btnindex] = int.Parse(numButton1.Text);
                        break;
                    case 1:
                        numButton2.Text = ansewrLabel.Text;
                        nb2[btnindex] = int.Parse(numButton2.Text);
                        break;
                    case 2:
                        numButton3.Text = ansewrLabel.Text;
                        nb3[btnindex] = int.Parse(numButton3.Text);
                        break;
                    case 3:
                        numButton4.Text = ansewrLabel.Text;
                        nb4[btnindex] = int.Parse(numButton4.Text);
                        break;
                }

                switch (btn2)
                {
                    case 0:
                        numButton1.Text = "";
                        numButton1.Visible = false;
                        nb1[btnindex] = null;
                        break;
                    case 1:
                        numButton2.Text = "";
                        numButton2.Visible = false;
                        nb2[btnindex] = null;
                        break;
                    case 2:
                        numButton3.Text = "";
                        numButton3.Visible = false;
                        nb3[btnindex] = null;
                        break;
                    case 3:
                        numButton4.Text = "";
                        numButton4.Visible = false;
                        nb4[btnindex] = null;
                        break;
                }

                btncnt--;

                if (btncnt == 1 && int.Parse(ansewrLabel.Text) == 10)
                {
                    Ten.FormSucces formSuccess = new FormSucces(this);
                    formSuccess.Show();
                    //newquestion();
                }
                else if (btncnt == 1)
                {

                }
                else
                {
                    ClearArea();
                }
            }else
            {
                ClearArea();
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            createButtons();
            ClearArea();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if(btnindex !=0)
            {
                if (nb1[btnindex - 1] != null)
                {
                    if (nb1[btnindex] == null)
                    {
                        numButton1.Visible = true;
                        btncnt++;
                    }
                    numButton1.Text = nb1[btnindex - 1].ToString();
                }

                if (nb2[btnindex - 1] != null)
                {
                    if (nb2[btnindex] == null)
                    {
                        numButton2.Visible = true;
                        btncnt++;
                    }
                    numButton2.Text = nb2[btnindex - 1].ToString();
                }

                if (nb3[btnindex - 1] != null)
                {
                    if (nb3[btnindex] == null)
                    {
                        numButton3.Visible = true;
                        btncnt++;
                    }
                    numButton3.Text = nb3[btnindex - 1].ToString();
                }

                if (nb4[btnindex - 1] != null)
                {
                    if (nb4[btnindex] == null)
                    {
                        numButton4.Visible = true;
                        btncnt++;
                    }
                    numButton4.Text = nb4[btnindex - 1].ToString();
                }

                btnindex--;
                ClearArea();
            }
        }
    }
}
