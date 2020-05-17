using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1
{
    public class ContactDAO
    {
        private MySqlConnection conn;
        public ContactDAO()
        {
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;pwd=;database=planning_ligue;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }

        public List<Licencie> getAllLicencie()
        {
            List<Licencie> lesLicencie = new List<Licencie>();
            string requete = "select * from licencie";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Licencie l = new Licencie(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString(),
               rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString(), rdr[5].ToString());
                lesLicencie.Add(l);
            }
            rdr.Close();
            return lesLicencie;
        }


        public void AddLicencie(int id, string nom, string prenom, string email, string tel, string mdp)
        {
            string sql = "INSERT INTO licencie (id, nom, prenom, email, tel, mdp) VALUES (" + id + ",'" + nom + "','" + prenom + "','" + email + "','" + tel + "','" + mdp + "' )";
            MySqlCommand maReq = new MySqlCommand(sql, conn);
            maReq.ExecuteNonQuery();
        }

        public void UpdateLicencie(string nom, int id)
        {
            string sql = "UPDATE licencie SET id=" + id + "AND nom='" + nom + "'WHERE id = " + id;


            MySqlCommand maReq = new MySqlCommand(sql, conn);
            maReq.ExecuteNonQuery();
        }

        public void ReadLicencie(Licencie l)
        {
            string sql = "SELECT * FROM licencie WHERE id=" + l.Id;
            MySqlCommand maReq = new MySqlCommand(sql, conn);
            MySqlDataReader resultats = maReq.ExecuteReader();
            while (resultats.Read())
            {
                resultats[2].ToString();
            }
        }

        public void SupprimerLicencie(int id)
        {
            string sql = "DELETE FROM licencie WHERE id=" + id;
            MySqlCommand maReq = new MySqlCommand(sql, conn);
            maReq.ExecuteNonQuery();
        }











    }

}