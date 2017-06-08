using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Habito
{
    public partial class Principal : Form
    {
        int atividades = 0;
        List<string> lista = new List<string>();

        public Principal()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            foreach(Control c in Controls)
            {
                c.Visible = false;
            }
            button1.Visible = true;
            label2.Visible = true;
            dataGridView1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                c.Visible = true;
            }
            button1.Visible = false;
            dataGridView1.Visible = false;
            lblRecompensa.Visible = false;
            lblRecop.Visible = false;
            label1.Visible = false;
            btnOk.Visible = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(txtAtividade.Text != "")
            {
                int i = atividades + 1;
                dataGridView1.Rows.Insert(atividades++, i, txtAtividade.Text, dateTimePicker1.Text);
                txtAtividade.Text = "";
                dateTimePicker1.Text = "08:00:00";
                timer1.Start();
                lista.Add("Chocolate");
                lista.Add("Sorvete");
                lista.Add("Doce");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {
                if (dataGridView1.Rows.Count > 1)
                {
                    string horario = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                    string horario_salvo = dataGridView1.Rows[j].Cells[2].Value.ToString();
                    horario_salvo = horario_salvo.Substring(0, 5);
                    if (horario.Equals(horario_salvo))
                    {
                        label1.Text = "Você deve: \n" + dataGridView1.Rows[j].Cells[1].Value.ToString();
                        lblRecompensa.Visible = true;
                        label1.Visible = true;
                        lblRecop.Text = lista[j];
                        lblRecop.Visible = true;
                        playSound();

                        txtAtividade.Visible = false;
                        dateTimePicker1.Visible = false;
                        btnCadastrar.Visible = false;
                        btnListar.Visible = false;
                        btnCancelar.Visible = false;
                        lblAlarme.Visible = false;
                        lblAtividade.Visible = false;
                        btnOk.Visible = true;
                        timer1.Stop();
                    }
                }
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(0);
            atividades--;
            timer1.Stop();
            foreach (Control c in Controls)
            {
                c.Visible = false;
            }
            label2.Visible = true;
            lblAtividade.Visible = true;
            lblAlarme.Visible = true;
            txtAtividade.Visible = true;
            dateTimePicker1.Visible = true;
            btnCadastrar.Visible = true;
            btnCancelar.Visible = true;
            btnListar.Visible = true;
        }

        private void playSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"..\..\img\Alarme_Despertador.wav");
            simpleSound.Play();
        }
    }
}
