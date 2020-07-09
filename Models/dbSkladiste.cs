using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPEK2.Models
{
    public class dbSkladiste
    {

        int ID_chemical;
        string ChemName;
        int quantity;
        string description;
        DateTime expDate;
        DateTime recDate;

        public int ID_chemical1 { get => ID_chemical; set => ID_chemical = value; }
        public string ChemName1 { get => ChemName; set => ChemName = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Description { get => description; set => description = value; }
        public DateTime ExpDate { get => expDate; set => expDate = value; }
        public DateTime RecDate { get => recDate; set => recDate = value; }
    }
}