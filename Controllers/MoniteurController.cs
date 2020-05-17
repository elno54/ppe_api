using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MoniteurController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddLicencie([FromBody] Moniteur m)
        {
            MoniteurDAO dao = new MoniteurDAO();
            dao.AddMoniteur(m.Id, m.Nom, m.Prenom, m.Email, m.Tel, m.Mdp);

            if (m != null)
                return Request.CreateResponse(HttpStatusCode.Created, m);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, m);
        }
        [HttpGet]
        public Moniteur GetById(long id)
        {
            MoniteurDAO dao = new MoniteurDAO();
            List<Moniteur> lesMoniteur = dao.getAllMoniteur();
            return lesMoniteur.ElementAt(0);
        }
        [HttpGet]
        public IEnumerable<Moniteur> GetAll()
        {
            MoniteurDAO dao = new MoniteurDAO();
            List<Moniteur> lesMoniteur = dao.getAllMoniteur();
            return lesMoniteur.ToList();
        }
        [HttpDelete]
        public string DeleteMoniteur(int id)
        {
            MoniteurDAO dao = new MoniteurDAO();
            dao.SupprimerMoniteur(id);
            return "Contact supprimé id " + id;
        }
        [HttpPut]
        public string UpdateMoniteur(string nom, int id)
        {
            MoniteurDAO dao = new MoniteurDAO();
            dao.UpdateMoniteur(nom, id);
            return "Mise à jour du moniteur avec le nom " + nom + " and Id " + id;
        }


    }
}
