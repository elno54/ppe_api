using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategorieController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddCategorie([FromBody] Categorie c)
        {
            CategorieDAO dao = new CategorieDAO();
            dao.AddCategorie(c.Id, c.Descriptif);

            if (c != null)
                return Request.CreateResponse(HttpStatusCode.Created, c);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, c);
        }
        [HttpGet]
        public Categorie GetById(long id)
        {
            CategorieDAO dao = new CategorieDAO();
            List<Categorie> lesCategorie = dao.getAllCategorie();
            return lesCategorie.ElementAt(0);
        }
        [HttpGet]
        public IEnumerable<Categorie> GetAll()
        {
            CategorieDAO dao = new CategorieDAO();
            List<Categorie> lesCategorie = dao.getAllCategorie();
            return lesCategorie.ToList();
        }
        [HttpDelete]
        public string DeleteContact(int id)
        {
            CategorieDAO dao = new CategorieDAO();
            dao.SupprimerCategorie(id);
            return "Categorie supprimé id " + id;
        }
        [HttpPut]
        public string UpdateContact(string descriptif, int id)
        {
            CategorieDAO dao = new CategorieDAO();
            dao.UpdateCategorie(descriptif, id);
            return "Mise à jour categorie avec le descriptif " + descriptif + " and Id " + id;
        }


    }
}
