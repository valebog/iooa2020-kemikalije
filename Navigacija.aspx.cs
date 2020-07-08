using APPEK2.DB;
using APPEK2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms.VisualStyles;

namespace APPEK2
{
    public partial class Navigacija : System.Web.UI.Page
    {
        Korisnik korisnik;
        DBConnect baza;

        protected void Page_Load(object sender, EventArgs e)
        {
            korisnik = (Korisnik)Session["user"];
            baza = new DBConnect();

            if (!korisnik.Admin)
                rbNavigacija.Items[0].Enabled = false;
        }

        protected void btnUlazak_Click(object sender, EventArgs e)
        {
            if (rbNavigacija.SelectedIndex == 0)
            {
                Session["admin"] = true;
                Response.Redirect("index.aspx");
            }

            else if (rbNavigacija.SelectedIndex == 1)
            {
                Session["admin"] = false;

                MySqlDataReader data = baza.Select("SELECT free FROM Laboratorij WHERE ID_laboratorij = 1");

                if (data.Read())
                    if (!bool.Parse(data["free"].ToString()))
                        lblZauzet.Text = "Laboratorij je zauzet!";
                    else
                    {
                        baza.CloseConnection();
                        Session["odabraniLab"] = "Lab1";
                        Response.Redirect("index.aspx");

                        //MySqlDataReader lab1 = baza.Select("SELECT * FROM Lab1");

                        //while (lab1.Read())
                        //{
                        //    labos.IdPrijava = int.Parse(lab1["ID_prijava"].ToString());
                        //    labos.IdKemikalija = int.Parse(lab1["ID_chemical"].ToString());
                        //    labos.Transfer = DateTime.Parse(lab1["transferDate"].ToString());
                        //    labos.Kolicina = int.Parse(lab1["quantity"].ToString());
                        //}

                    }
            }

            else
            {
                Session["admin"] = false;
                MySqlDataReader data = baza.Select("SELECT free FROM Laboratorij WHERE ID_laboratorij = 2");

                if (data.Read())
                    if (!bool.Parse(data["free"].ToString()))
                        lblZauzet.Text = "Laboratorij je zauzet!";
                    else
                    {
                        baza.CloseConnection();
                        Session["odabraniLab"] = "Lab2";
                        Response.Redirect("index.aspx");
                    }
            }

        }
    }
}