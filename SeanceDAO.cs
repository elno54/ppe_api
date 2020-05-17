using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1
{
    public class SeanceDAO
    {
        private MySqlConnection conn;
        public SeanceDAO()
        {
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;pwd=;database=api;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }
        public List<Seance> getAllSeance()
        {
            List<Seance> lesSeance = new List<Seance>();
            string requete = "select * from categorie";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Seance s = new Seance(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString(),
               rdr[2].ToString(), Convert.ToDateTime(rdr[3].ToString()), Convert.ToDateTime(rdr[4].ToString()), Convert.ToInt16(rdr[5].ToString()));
                lesSeance.Add(s);
            }
            rdr.Close();
            return lesSeance;
        }

        public void AddSeance(int id, string jour, string descriptif, DateTime debut, DateTime fin, int la_categorie)
        {
            string sql = "INSERT INTO seance (id, jour, descriptif, debut, fin, la_categorie) VALUES  (" + id + ",'" + jour + "','" + descriptif + "','" + debut + "','" + fin + "','" + la_categorie + "' )";
            MySqlCommand maReq = new MySqlCommand(sql, conn);
            maReq.ExecuteNonQuery();
        }

        public void UpdateSeance(string descriptif, int id)
        {
            string sql = "UPDATE seance SET id=" + id + "AND descriptif='" + descriptif + "'WHERE id = " + id;


            MySqlCommand maReq = new MySqlCommand(sql, conn);
            maReq.ExecuteNonQuery();
        }

        public void ReadSeance(Seance s)
        {
            string sql = "SELECT * FROM seance WHERE id=" + s.Id;
            MySqlCommand maReq = new MySqlCommand(sql, conn);
            MySqlDataReader resultats = maReq.ExecuteReader();
            while (resultats.Read())
            {
                resultats[2].ToString();
            }
        }

        public void SupprimerSeance(int id)
        {
            string sql = "DELETE FROM seance WHERE id=" + id;
            MySqlCommand maReq = new MySqlCommand(sql, conn);
            maReq.ExecuteNonQuery();
        }
    }

}