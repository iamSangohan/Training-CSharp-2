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
            if (TxtHT.Text == "")
            {
                MessageBox.Show("Il faut saisir une note");
                e.Cancel = true;
            }
            else
            {
                // min 500
                if (int.Parse(TxtHT.Text) < 500)
                {
                    MessageBox.Show("La note doit être supérieure ou égale à 500");
                    e.Cancel = true;
                }
            }
        }

        private void TxtTech_Validating(object sender, CancelEventArgs e)
        {
            if (TxtTVA.Text == "")
            {
                MessageBox.Show("Il faut saisir la TVA");
                e.Cancel = true;
            }
            else
            {
                // entre 0 et 22
                if ((int.Parse(TxtTVA.Text) < 0) || (int.Parse(TxtTVA.Text) > 22))
                {
                    MessageBox.Show("La TVA doit être comprise entre 0 et 22");
                    e.Cancel = true;
                }
            }
        }

        private void BtnGen_Click(object sender, EventArgs e)
        {
            int x;
            Random alea = new Random();
            x = alea.Next(0, 30);
            TxtChance.Text = x.ToString();
        }

        private void BtnInit_Click(object sender, EventArgs e)
        {
            TxtCode.Text = "";
            TxtNom.Text = "";
            TxtPrenom.Text = "";
            TxtHT.Text = "0";
            TxtTVA.Text = "0";
            TxtChance.Text = "0";
            TxtTel.Text = "";
            TxtScore.Text = "0";

            ChkImpr.Checked = false;
            ChkScan.Checked = false;
            ChkWeb.Checked = false;

            Rd19.Checked = false;
            Rd17.Checked = false;

            CmbMode.SelectedIndex = -1;

            BtnAjout.Enabled = false;
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            if ((TxtCode.Text == "") || TxtHT.Text == "" || TxtNom.Text == "" || TxtPrenom.Text == "" || TxtTVA.Text == "" || TxtTel.Text == "")
{
                MessageBox.Show("Il faut saisir toutes les informations");
                return;
            }

            int prix, ecran, bonus, chance;
            double mode, total;
            prix = int.Parse(TxtHT.Text) + int.Parse(TxtTVA.Text);
            ecran = (Rd17.Checked) ? 200 : 310;
            bonus = (ChkImpr.Checked) ? 120 : 0;
            bonus += (ChkScan.Checked) ? 60 : 0;
            bonus += (ChkWeb.Checked) ? 40 : 0;
            chance = int.Parse(TxtChance.Text);

            switch (CmbMode.SelectedIndex)
            {
                case 0:
                    mode = 0.95; break;
                case 1:
                    mode = 1.05; break;
                case 2:
                    mode = 1.2; break;
                case 3:
                    mode = 1.4; break;
                default:
                    mode = 0; break;
            }

            total = prix + ecran + bonus + chance;
            total *= mode;
            TxtScore.Text = total.ToString();
            BtnAjout.Enabled = true;
        }

        private void BtnAjout_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(TxtCode.Text);
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
