using APPEK2.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace APPEK2
{
    public partial class REGISTRACIJA : System.Web.UI.Page
    {
        DBConnect baza;
        protected void Page_Load(object sender, EventArgs e)
        {
            baza = new DBConnect();
        }

        protected void btnPrijava_Click(object sender, EventArgs e)
        {
            MySqlDataReader data = baza.Select("SELECT * FROM Prijava where username = '" + txtKorIme.Text + "' ");


            if (data.Read())
            {
                lblkorisnik.Text = "korisnik postoji";
                lblneisloz.Text = "";
            }
            else
            {
                baza.CloseConnection();
                if (check())
                {
                    if (txtLozinka.Text.Equals(txtponovi.Text))
                    {
                        baza.Insert("INSERT into Prijava(username, password, ime, prezime) VALUES ('" + txtKorIme.Text + "', '" + txtLozinka.Text + "', '" + txtIme.Text + "', '" + txtPrezime.Text + "')");
                        MessageBox.Show("Uspješan unos");
                    }
                    else
                        lblneisloz.Text = "Lozinke se moraju podudarati";
                }
                else
                    MessageBox.Show("Popunite sve podatke");

            }
        }

        protected void btnOcisti_Click(object sender, EventArgs e)
        {
            txtIme.Text = string.Empty;
            txtKorIme.Text = string.Empty;
            txtLozinka.Text = string.Empty;
            txtponovi.Text = string.Empty;
            txtPrezime.Text = string.Empty;
        }

        private bool check()
        {
            if (txtIme.Text.Equals(string.Empty))
                return false;

            if (txtPrezime.Text.Equals(string.Empty))
                return false;

            if (txtKorIme.Text.Equals(string.Empty))
                return false;

            if (txtLozinka.Text.Equals(string.Empty))
                return false;

            return true;
        }
    }
}