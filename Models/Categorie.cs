using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Categorie
    {
        private int id;
        private string descriptif;

        public Categorie(int id, string descriptif)
        {
            this.id = id;
            this.descriptif = descriptif;
        }

        public int Id { get => id; set => id = value; }
        public string Descriptif { get => descriptif; set => descriptif = value; }
    }
}