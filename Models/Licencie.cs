using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Licencie
    {
        private int id;
        private string nom;
        private string prenom;
        private string email;
        private string tel;
        private string mdp;

        public Licencie(int id, string nom, string prenom, string email, string tel, string mdp)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.tel = tel;
            this.mdp = mdp;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Mdp { get => mdp; set => mdp = value; }
    }
}