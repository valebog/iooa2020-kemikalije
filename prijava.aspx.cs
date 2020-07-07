using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms.VisualStyles;
using APPEK2.DB;
using APPEK2.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.X.XDevAPI.Common;

namespace APPEK2
{
    public partial class prijava : System.Web.UI.Page
    {

        Korisnik korisnik;
        DBConnect baza;

        protected void Page_Load(object sender, EventArgs e)
        {
            korisnik = new Korisnik();
            baza = new DBConnect();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            lblKorisnik.Text = "";
        }

        protected void Btn(object sender, EventArgs e)
        {
            string user = txtKorIme.Text;
            string pass = txtLozinka.Text;

            MySqlDataReader data = baza.Select("SELECT * FROM Prijava where username = '"+user+"' ");

            if(data.Read())
            {
                if (data["password"].ToString() == pass)
                {
                    korisnik.IdKorisnik = int.Parse(data["ID_prijava"].ToString());

                    korisnik.UserName = data["username"].ToString();
                    korisnik.Password = data["password"].ToString();
                    korisnik.Ime = data["ime"].ToString();
                    korisnik.Prezime = data["prezime"].ToString();
                    korisnik.Admin = bool.Parse(data["admin"].ToString());

                    baza.CloseConnection();

                    Session["user"] = korisnik;
                    Response.Redirect("Navigacija.aspx");
                }

                else
                    lblLozinka.Text = "Lozinka nije isprana";

            }
            else
                lblKorisnik.Text = "Korisnik nije u bazi";
        }
    }
}