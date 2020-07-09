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
using System.Windows.Forms;

namespace APPEK2
{
    public partial class Labos : System.Web.UI.Page
    {

        Korisnik korisnik;
        Laboratorij laboratorij;
        dbSkladiste skladiste;
        DBConnect dbConnect;
        List<Laboratorij> listLabos;
        List<dbSkladiste> listSkladiste;

        protected void Page_Load(object sender, EventArgs e)
        {
            korisnik = new Korisnik();
            dbConnect = new DBConnect();
            listLabos = new List<Laboratorij>();
            listSkladiste = new List<dbSkladiste>();
            korisnik = (Korisnik)Session["user"];


            podaci.HeaderRow.Cells[0].Text = "Označi";
            podaci.HeaderRow.Cells[1].Text = "ID korisnika";
            podaci.HeaderRow.Cells[2].Text = "ID kemikalije";
            podaci.HeaderRow.Cells[3].Text = "Količina";
            podaci.HeaderRow.Cells[4].Text = "Korisnik";
            podaci.HeaderRow.Cells[5].Text = "Naziv Kemikalije";

            chemSkladiste.HeaderRow.Cells[0].Text = "Označi";
            chemSkladiste.HeaderRow.Cells[1].Text = "ID kemikalije";
            chemSkladiste.HeaderRow.Cells[2].Text = "Naziv Kemikalije";
            chemSkladiste.HeaderRow.Cells[3].Text = "Količina";
            chemSkladiste.HeaderRow.Cells[4].Text = "Opis";
            chemSkladiste.HeaderRow.Cells[5].Text = "Datum isteka";
            chemSkladiste.HeaderRow.Cells[6].Text = "Datum zaprimanja";
        }

        protected void btnPovratak_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }


        public IQueryable<APPEK2.Models.Laboratorij> podaci_GetData()
        {
            MySqlDataReader data = dbConnect.Select("SELECT * FROM " + Session["odabraniLab"].ToString());

            while (data.Read())
            {
                laboratorij = new Laboratorij();
                laboratorij.IdPrijava = int.Parse(data["ID_prijava"].ToString());
                laboratorij.IdKemikalija = int.Parse(data["ID_chemical"].ToString());
                laboratorij.Transfer = DateTime.Parse(Date.Parse(data["transferDate"].ToString()).ToString());
                laboratorij.Kolicina = int.Parse(data["quantity"].ToString());
                laboratorij.Korisnik = DohvatiKorisnika(laboratorij.IdPrijava);
                laboratorij.ImeKemikalije = DohvatiNaziv(laboratorij.IdKemikalija);

                listLabos.Add(laboratorij);
            }
            dbConnect.CloseConnection();

            return listLabos.AsQueryable();
        }

        public string DohvatiKorisnika(int serial)
        {
            DBConnect connect = new DBConnect();

            MySqlDataReader imePre = connect.Select("SELECT ime, prezime FROM Prijava WHERE ID_prijava = " + serial);

            string naziv;
            if (imePre.Read())
                naziv = String.Format("{0} {1}", imePre["ime"], imePre["prezime"]);
            
            else
                naziv = "";

            connect.CloseConnection();

            return naziv;

        }
        public string DohvatiNaziv(int serial)
        {
            DBConnect connectNaziv = new DBConnect();
            string naziv;

            MySqlDataReader kemikalija = connectNaziv.Select("SELECT chemName FROM Skladiste WHERE ID_chemical = " + serial);

            if (kemikalija.Read())
                naziv = kemikalija["chemName"].ToString();

            else
                naziv = "";

            connectNaziv.CloseConnection();

            return naziv;
        }

        protected void podaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = podaci.SelectedIndex;
            listLabos = podaci_GetData().ToList<Laboratorij>();
            Session["idChem"] = listLabos[id].IdKemikalija;
            Session["quantity"] = listLabos[id].Kolicina;
        }

        protected void btnUzmi_Click(object sender, EventArgs e)
        {
            int novoStanje = int.Parse(Session["quantity"].ToString()) - int.Parse(txtKom.Text);

            if (novoStanje < 0)
                MessageBox.Show("U labosu nema dovoljno resursa!");

            else
                dbConnect.Update(String.Format("UPDATE {0} SET quantity = {1} WHERE ID_chemical = {2}", Session["odabraniLab"].ToString(), novoStanje, Session["idChem"]));
            
            Response.Redirect("Labos.aspx", false);
        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            int novoStanje = int.Parse(Session["quantity"].ToString()) + int.Parse(txtKom.Text);

            dbConnect.Update(String.Format("UPDATE {0} SET quantity = {1} WHERE ID_chemical = {2}", Session["odabraniLab"].ToString(), novoStanje, Session["idChem"]));
            
            MessageBox.Show("zalihe labosa su obnovljene!");

            Response.Redirect("Labos.aspx", false);
        }

        protected void btnDonesi_Click(object sender, EventArgs e)
        {
            skladistePano.Visible = true;
        }

        public IQueryable<APPEK2.Models.dbSkladiste> chemSkladiste_GetData()
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

        protected void chemSkladiste_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = chemSkladiste.SelectedIndex;
            listSkladiste = chemSkladiste_GetData().ToList<dbSkladiste>();
            Session["idChemSkaldiste"] = listSkladiste[id].ID_chemical1;
            Session["quantitySkladiste"] = listSkladiste[id].Quantity;
        }

        protected void btnPrenesi_Click(object sender, EventArgs e)
        {
            int idChemSkl = int.Parse(Session["idChemSkaldiste"].ToString());
            int quantitySkl = int.Parse(Session["quantitySkladiste"].ToString());
            int quantity = int.Parse(txtPrenesi.Text);
            if (quantitySkl - quantity < 0)
                MessageBox.Show("Nema dovoljno zaliha u skladištu");

            else
            {
                dbConnect.Update(String.Format("UPDATE Skladiste SET quantity = {0} WHERE ID_chemical = {1}", quantitySkl - quantity, idChemSkl));

                listLabos = podaci_GetData().ToList<Laboratorij>();
                bool postoji = false;
                int quantityLab = 0;
                string nazivChem = "";

                foreach(Laboratorij lab in listLabos)
                    if (lab.IdKemikalija.Equals(idChemSkl))
                    {
                        postoji = true;
                        quantityLab = lab.Kolicina;
                        nazivChem = lab.ImeKemikalije;
                    }

                if (postoji)
                {
                    dbConnect.Update(String.Format("UPDATE {0} SET quantity = {1} WHERE ID_chemical = {2}", 
                                                    Session["odabraniLab"].ToString(), quantityLab+quantity, idChemSkl));
                    MessageBox.Show("Dodano je još " + quantity + " mjernih jedinica " + nazivChem);

                    dbConnect.Insert(String.Format("INSERT INTO Dashboard (note, date, ID_prijava) VALUES ('{0}', '{1}', {2})",
                                                    "Preneseno je " + quantity + " komada " + nazivChem + " u " + Session["OdabraniLab"] + " ",
                                                    FormatDateForMySQL(DateTime.Now),
                                                    korisnik.IdKorisnik));
                }
                else
                {
                    dbConnect.Insert(String.Format("INSERT INTO {0} VALUES ({1}, {2}, '{3}', {4})", 
                                                    Session["odabraniLab"].ToString(), korisnik.IdKorisnik, idChemSkl, 
                                                    FormatDateForMySQL(DateTime.Now), quantity));
                    MessageBox.Show("U labos je pohranjena nova kemikalija");

                    dbConnect.Insert(String.Format("INSERT INTO Dashboard (note, date, ID_prijava) VALUES ('{0}', '{1}', {2})",
                                                    "Donesena je nova kemikalija,  " + quantity + " komada " + nazivChem + " u " + Session["OdabraniLab"],
                                                    FormatDateForMySQL(DateTime.Now),
                                                    korisnik.IdKorisnik));
                }
            }

            Response.Redirect("Labos.aspx");
        }

        private string FormatDateForMySQL(DateTime input)
        {
            string output = "";

            output += input.Year + "-";
            output += input.Month + "-";
            output += input.Day;

            return output;
        }

        protected void btnSkaldiste_Click(object sender, EventArgs e)
        {
            Response.Redirect("Skladiste.aspx");
        }

        protected void btnSakrij_Click(object sender, EventArgs e)
        {
            skladistePano.Visible = false;
        }
    }
}