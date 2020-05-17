using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1
{
    public class MoniteurDAO
    {
        private MySqlConnection conn;
        public MoniteurDAO()
        {
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;pwd=;database=api;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }
        public List<Moniteur> getAllMoniteur()
        {
            List<Moniteur> lesMoniteurs = new List<Moniteur>();
            string requete = "select * from moniteur";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Moniteur m = new Moniteur(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString(),
               rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString());
                lesMoniteurs.Add(m);
            }
            rdr.Close();
            return lesMoniteurs;
        }

        public void AddMoniteur(int id, string nom, string prenom, string email, string tel, string mdp)
        {
            string sql = "INSERT INTO moniteur (id, nom, prenom, email, tel, mdp) VALUES (" + id + ",'" + nom + "','" + prenom + "','" + email + "','" + tel + "','" + mdp + "' )";
            MySqlCommand maReq = new MySqlCommand(sql, conn);
            maReq.ExecuteNonQuery();
        }

        public void UpdateMoniteur(string nom, int id)
        {
            string sql = "UPDATE moniteur SET id=" + id + "AND nom='" + nom + "'WHERE id = " + id;


            MySqlCommand maReq = new MySqlCommand(sql, conn);
            maReq.ExecuteNonQuery();
        }

        public void ReadCategorie(Moniteur m)
        {
            string sql = "SELECT * FROM moniteur WHERE id=" + m.Id;
            MySqlCommand maReq = new MySqlCommand(sql, conn);
            MySqlDataReader resultats = maReq.ExecuteReader();
            while (resultats.Read())
            {
                resultats[2].ToString();
            }
        }

        public void SupprimerMoniteur(int id)
        {
            string sql = "DELETE FROM moniteur WHERE id=" + id;
            MySqlCommand maReq = new MySqlCommand(sql, conn);
            maReq.ExecuteNonQuery();
        }
    }

}