using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPEK2.Models
{
    public class Korisnik
    {
        int idKorisnik;
        string userName;
        string password;
        string ime;
        string prezime;
        Boolean admin;

        public int IdKorisnik { get => idKorisnik; set => idKorisnik = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public bool Admin { get => admin; set => admin = value; }
    }
}