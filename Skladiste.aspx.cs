using APPEK2.DB;
using APPEK2.Models;
using Microsoft.OData.Edm;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APPEK2
{
	public partial class Skladiste : System.Web.UI.Page
	{
        dbSkladiste skladiste;
        DBConnect dbConnect;
        List<dbSkladiste> listSkladiste;
            
		protected void Page_Load(object sender, EventArgs e)
		{
            dbConnect = new DBConnect();
            listSkladiste = new List<dbSkladiste>();

            podaci.HeaderRow.Cells[0].Text = "Označi";
            podaci.HeaderRow.Cells[1].Text = "ID kemikalije";
            podaci.HeaderRow.Cells[2].Text = "Naziv kemikalije";
            podaci.HeaderRow.Cells[3].Text = "Količina";
            podaci.HeaderRow.Cells[4].Text = "Opis";
            podaci.HeaderRow.Cells[5].Text = "Datum isteka";
            podaci.HeaderRow.Cells[6].Text = "Datum zaprimanja";
        }

		public IQueryable<APPEK2.Models.dbSkladiste> podaci_GetData()
		{
            MySqlDataReader data = dbConnect.Select("SELECT * FROM Skladiste");

            while (data.Read())
            {
                skladiste = new dbSkladiste();

                skladiste.ID_chemical1 = int.Parse(data["ID_chemical"].ToString());
                skladiste.ChemName1 = data["chemName"].ToString();
                skladiste.Quantity = int.Parse(data["quantity"].ToString());
                skladiste.Description = data["description"].ToString();
                skladiste.ExpDate = DateTime.Parse(Date.Parse(data["expDate"].ToString()).ToString());
                skladiste.RecDate = DateTime.Parse(Date.Parse(data["recDate"].ToString()).ToString());

                listSkladiste.Add(skladiste);
            }

            dbConnect.CloseConnection();

            return listSkladiste.AsQueryable();
        }

		protected void podaci_SelectedIndexChanged(object sender, EventArgs e)
		{
            int id = podaci.SelectedIndex;
            listSkladiste = podaci_GetData().ToList<dbSkladiste>();
            skladiste = listSkladiste[id];
            Session["kemikalija"] = skladiste;

            txtNaziv.Text = skladiste.ChemName1;
            txtKolicina.Text = skladiste.Quantity.ToString();
            txtOpis.Text = skladiste.Description;
            dateExp.SelectedDate = skladiste.ExpDate;
            dateRec.SelectedDate = skladiste.RecDate;
        }

        protected void btnPovratak_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void dateExp_SelectionChanged(object sender, EventArgs e)
        {
            DateTime date = dateExp.SelectedDate;
            Session["dateExp"] = date;
        }

        protected void dateRec_SelectionChanged(object sender, EventArgs e)
        {
            DateTime date = dateRec.SelectedDate;
            Session["dateRec"] = date;
        }

        protected void btnPohrani_Click(object sender, EventArgs e)
        {
            dbConnect.Insert(String.Format("INSERT INTO Skladiste (chemName, quantity, description, expDate, recDate)" +
                                            "VALUES ('{0}', {1}, '{2}', '{3}', '{4}')", 
                                            txtNaziv.Text, 
                                            txtKolicina.Text, 
                                            txtOpis.Text,
                                            FormatDateForMySQL((DateTime)Session["dateExp"]),
                                            FormatDateForMySQL((DateTime)Session["dateRec"])));

            Response.Redirect("Skladiste.aspx", false);
        }

        protected void btnOcisti_Click(object sender, EventArgs e)
        {
            txtNaziv.Text = "";
            txtKolicina.Text = "";
            txtOpis.Text = "";
            dateExp.SelectedDates.Clear();
            dateRec.SelectedDates.Clear();
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            skladiste = (dbSkladiste)Session["kemikalija"];

            dbConnect.Update(String.Format("UPDATE Skladiste SET chemName = '{0}', quantity = {1}, description = {2}, expDate = '{3}', recDate = '{4}' WHERE ID_chemical = {5}",
                                           txtNaziv.Text, 
                                           txtKolicina.Text, 
                                           txtOpis.Text, 
                                           FormatDateForMySQL((DateTime)Session["dateExp"]),
                                           FormatDateForMySQL((DateTime)Session["dateRec"]),
                                           skladiste.ID_chemical1));

            Response.Redirect("Skladiste.aspx", false);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            skladiste = (dbSkladiste)Session["kemikalija"];

            dbConnect.Delete("DELETE FROM Skladiste WHERE ID_chemical = " + skladiste.ID_chemical1);

            Response.Redirect("Skladiste.aspx", false);
        }

        private string FormatDateForMySQL(DateTime input)
        {
            string output = "";

            output += input.Year + "-";
            output += input.Month + "-";
            output += input.Day;

            return output;
        }
    }
}