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
    public partial class FormSucces : Form
    {
        FormTen formTen;
        public FormSucces(FormTen f)
        {
            formTen = f;
            InitializeComponent();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            formTen.newquestion();
            this.Close();
        }

        private void FormSucces_Load(object sender, EventArgs e)
        {
            this.Left = formTen.Left + (formTen.Right - formTen.Left) / 2 - 150;
            this.Top = formTen.Top + (formTen.Bottom - formTen.Top) / 2 - 75;
        }

        private void againButton_Click(object sender, EventArgs e)
        {
            formTen.createButtons();
            formTen.ClearArea();
            this.Close();
        }
    }
}
