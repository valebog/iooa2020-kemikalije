using APPEK2.DB;
using APPEK2.Models;
using Microsoft.OData.Edm;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace APPEK2
{
    public partial class index : System.Web.UI.Page
    {
        Korisnik korisnik;
        Dashboard dashboard;
        DBConnect dbConnect;
        List<Dashboard> listBoard;

        protected void Page_Load(object sender, EventArgs e)
        {
            korisnik = new Korisnik();
            dbConnect = new DBConnect();
            listBoard = new List<Dashboard>();
            korisnik = (Korisnik)Session["user"];
            if (!(bool)Session["admin"])
            {
                Unos.Visible = false;
                register.Visible = false;
            }
                

            podaci.HeaderRow.Cells[0].Text = "Označi";
            podaci.HeaderRow.Cells[1].Text = "ID obavijesti";
            podaci.HeaderRow.Cells[2].Text = "Obavijest";
            podaci.HeaderRow.Cells[3].Text = "ID korisnika";
            podaci.HeaderRow.Cells[4].Text = "Ime i prezime";
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

        }

        public string DohvatiIme(int serial)
        {
            DBConnect connect = new DBConnect();

            MySqlDataReader imePre = connect.Select("SELECT ime, prezime FROM Prijava where ID_prijava = "+serial);

            string naziv;
            if (imePre.Read())
            {
                naziv = String.Format("{0} {1}", imePre["ime"], imePre["prezime"]);
                connect.CloseConnection();
            }
            else
                naziv = "";

            return naziv;

        }

        public IQueryable<APPEK2.Models.Dashboard> podaci_GetData()
        {
            MySqlDataReader data = dbConnect.Select("SELECT * FROM Dashboard");

            while (data.Read())
            {
                dashboard = new Dashboard();
                dashboard.IdDeshBoard = int.Parse(data["ID_dashboard"].ToString());
                dashboard.Note = data["note"].ToString();
                dashboard.Date = Date.Parse(data["date"].ToString());
                dashboard.IdPrijava = int.Parse(data["ID_prijava"].ToString());
                dashboard.ImeIpre = DohvatiIme(dashboard.IdPrijava);

                listBoard.Add(dashboard);
            }
            dbConnect.CloseConnection();

            return listBoard.AsQueryable();
        }

        protected void btnObavijest_Click(object sender, EventArgs e)
        {
            dbConnect.Insert(String.Format("INSERT INTO Dashboard (note, date, ID_prijava) " +
                                           "VALUES ('{0}', '{1}', {2})",
                                           txtObavijest.Text.Trim(), 
                                           Date.Now,
                                           korisnik.IdKorisnik));

            Response.Redirect("index.aspx", false);
        }

        protected void btnObrisi_Click(object sender, EventArgs e)
        {
            string id2 = Session["idObavijesti"].ToString();

            dbConnect.Delete("DELETE FROM Dashboard WHERE ID_dashboard = "+id2);

            Response.Redirect("index.aspx", false);
        }

        protected void btnUredi_Click(object sender, EventArgs e)
        {
            dbConnect.Update(String.Format("UPDATE Dashboard " +
                                           "SET note = '{0}' " +
                                           "WHERE ID_dashboard = {1}",
                                           txtObavijest.Text,
                                           Session["idObavijesti"].ToString()));

            Response.Redirect("index.aspx", false);
        }

        protected void podaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = podaci.SelectedIndex;

            listBoard = podaci_GetData().ToList<Dashboard>();

            txtObavijest.Text = listBoard[id].Note;

            Session["idObavijesti"] = listBoard[id].IdDeshBoard;
        }
    }
}