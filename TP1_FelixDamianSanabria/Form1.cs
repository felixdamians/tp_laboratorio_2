using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_FelixDamianSanabria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(textBox1.Text);
            Numero numero2 = new Numero(textBox2.Text);
            Calculadora calcular = new Calculadora();

            label1.Text = Calculadora.operar(numero1, numero2, comboBox1.Text).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            label1.Text = "";
            comboBox1.Text = "";
          
        }
    }
}
