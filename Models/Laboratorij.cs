using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPEK2.Models
{
    public class Laboratorij
    {
        int idPrijava;
        int idKemikalija;
        Date transfer;
        int kolicina;

        public int IdPrijava { get => idPrijava; set => idPrijava = value; }
        public int IdKemikalija { get => idKemikalija; set => idKemikalija = value; }
        public Date Transfer { get => transfer; set => transfer = value; }
        public int Kolicina { get => kolicina; set => kolicina = value; }
    }
}