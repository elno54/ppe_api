using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1
{
    public class CategorieDAO
    {
        private MySqlConnection conn;
        public CategorieDAO()
        {
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;pwd=;database=api;";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }
        public List<Categorie> getAllCategorie()
        {
            List<Categorie> lesCategories = new List<Categorie>();
            string requete = "select * from categorie";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Categorie c = new Categorie(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString());
                lesCategories.Add(c);
            }
            rdr.Close();
            return lesCategories;
        }

        public void AddCategorie(int id, string descriptif)
        {
            string sql = "INSERT INTO categorie (id, descriptif) VALUES (" + id + ",'" + descriptif + "' )";
            MySqlCommand maReq = new MySqlCommand(sql, conn);
            maReq.ExecuteNonQuery();
        }

        public void UpdateCategorie(string descriptif, int id)
        {
            string sql = "UPDATE categorie SET id=" + id + "AND descriptif='" + descriptif + "'WHERE id = " + id;


            MySqlCommand maReq = new MySqlCommand(sql, conn);
            maReq.ExecuteNonQuery();
        }

        public void ReadCategorie(Categorie c)
        {
            string sql = "SELECT * FROM categorie WHERE id=" + c.Id;
            MySqlCommand maReq = new MySqlCommand(sql, conn);
            MySqlDataReader resultats = maReq.ExecuteReader();
            while (resultats.Read())
            {
                resultats[2].ToString();
            }
        }

        public void SupprimerCategorie(int id)
        {
            string sql = "DELETE FROM categorie WHERE id=" + id;
            MySqlCommand maReq = new MySqlCommand(sql, conn);
            maReq.ExecuteNonQuery();
        }
    }

}