using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravauxPratiques3
{
    public partial class DevisPC : Form
    {
        public DevisPC()
        {
            InitializeComponent();

            LbDate.Text = "Date : " + DateTime.Now.ToShortDateString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LbHeure.Text = "Heure : " + DateTime.Now.ToLongTimeString();
        }

        private void TxtLang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')))
                e.KeyChar = (char)0;
        }

        private void TxtTech_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')))
                e.KeyChar = (char)0;
        }

        private void TxtLang_Validating(object sender, CancelEventArgs e)
        {
            if (TxtLang.Text == "")
            {
                MessageBox.Show("Il faut saisir une note");
                e.Cancel = true;
            }
            else
            {
                if (int.Parse(TxtLang.Text) > 20)
                {
                    MessageBox.Show("La note doit être entre 0 et 20");
                    TxtLang.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void TxtTech_Validating(object sender, CancelEventArgs e)
        {
            if (TxtLang.Text == "")
            {
                MessageBox.Show("Il faut saisir une note");
                e.Cancel = true;
            }
            else
            {
                if (int.Parse(TxtLang.Text) > 20)
                {
                    MessageBox.Show("La note doit être entre 0 et 20");
                    TxtLang.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void BtnGen_Click(object sender, EventArgs e)
        {
            int x;
            Random alea = new Random();
            x = alea.Next(0, 16);
            TxtChance.Text = x.ToString();
        }

        private void BtnInit_Click(object sender, EventArgs e)
        {
            TxtCNI.Text = "";
            TxtNom.Text = "";
            TxtPrenom.Text = "";
            TxtLang.Text = "0";
            TxtTech.Text = "0";
            TxtChance.Text = "0";
            TxtTel.Text = "";

            ChkExper.Checked = false;
            ChkMotiv.Checked = false;
            ChkDip.Checked = false;

            RdFem.Checked = false;
            RdMas.Checked = false;

            CmbAge.SelectedIndex = -1;

            BtnAjout.Enabled = false;
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            if ((TxtCNI.Text == "") || TxtLang.Text == "" || TxtNom.Text == "" || TxtPrenom.Text == "" || TxtTech.Text == "" || TxtTel.Text == "")
{
                MessageBox.Show("Il faut saisir toutes les informations");
                return;
            }

            int note, sexe, bonus, age, chance, score;
            note = int.Parse(TxtLang.Text) + int.Parse(TxtTech.Text);
            sexe = (RdMas.Checked) ? 7 : 5;
            bonus = (ChkExper.Checked) ? 15 : 0;
            bonus += (ChkMotiv.Checked) ? 10 : 0;
            bonus += (ChkDip.Checked) ? 5 : 0;
            chance = int.Parse(TxtChance.Text);

            switch (CmbAge.SelectedIndex)
            {
                case 0:
                    age = 20; break;
                case 1:
                    age = 10; break;
                case 2:
                    age = 5; break;
                default:
                    age = 0; break;
            }

            score = note + sexe + bonus + age + chance;
            TxtScore.Text = score.ToString();
            BtnAjout.Enabled = true;
        }

        private void BtnAjout_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(TxtCNI.Text);
            listBox2.Items.Add(TxtNom.Text);
            listBox3.Items.Add(TxtPrenom.Text);
            listBox4.Items.Add(TxtScore.Text);
            
            BtnAjout.Enabled = false;
        }

        private void BtnQuitt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
