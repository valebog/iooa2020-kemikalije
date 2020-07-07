using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPEK2.Models
{
    public class Dashboard
    {
        int idDeshBoard;
        string note;
        Date date;
        int idPrijava;
        string imeIpre;
        public int IdDeshBoard { get => idDeshBoard; set => idDeshBoard = value; }
        public string Note { get => note; set => note = value; }
        public Date Date { get => date; set => date = value; }
        public int IdPrijava { get => idPrijava; set => idPrijava = value; }
        public string ImeIpre { get => imeIpre; set => imeIpre = value; }
    }
}