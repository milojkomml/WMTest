using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Kategorija { get; set; }
        public string Proizvođač { get; set; }
        public string Dobavljač { get; set; }
        public float Cena { get; set; }
    }
}
