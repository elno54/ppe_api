using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Seance
    {
        private int id;
        private string jour;
        private string descriptif;
        private DateTime debut;
        private DateTime fin;
        private int la_categorie;

        public Seance(int id, string jour, string descriptif, DateTime debut, DateTime fin, int la_categorie)
        {
            this.id = id;
            this.jour = jour;
            this.descriptif = descriptif;
            this.debut = debut;
            this.fin = fin;
            this.la_categorie = la_categorie;
        }

        public int Id { get => id; set => id = value; }
        public string Jour { get => jour; set => jour = value; }
        public string Descriptif { get => descriptif; set => descriptif = value; }
        public DateTime Debut { get => debut; set => debut = value; }
        public DateTime Fin { get => fin; set => fin = value; }
        public int La_categorie { get => la_categorie; set => la_categorie = value; }
    }
}