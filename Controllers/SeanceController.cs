using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SeanceController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddLicencie([FromBody] Seance s)
        {
            SeanceDAO dao = new SeanceDAO();
            dao.AddSeance(s.Id, s.Jour, s.Descriptif, s.Debut, s.Fin, s.La_categorie);

            if (s != null)
                return Request.CreateResponse(HttpStatusCode.Created, s);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, s);
        }
        [HttpGet]
        public Seance GetById(long id)
        {
            SeanceDAO dao = new SeanceDAO();
            List<Seance> lesSeance = dao.getAllSeance();
            return lesSeance.ElementAt(0);
        }
        [HttpGet]
        public IEnumerable<Seance> GetAll()
        {
            SeanceDAO dao = new SeanceDAO();
            List<Seance> lesSeance = dao.getAllSeance();
            return lesSeance.ToList();
        }
        [HttpDelete]
        public string DeleteMoniteur(int id)
        {
            SeanceDAO dao = new SeanceDAO();
            dao.SupprimerSeance(id);
            return "Contact supprimé id " + id;
        }
        [HttpPut]
        public string UpdateMoniteur(string descriptif, int id)
        {
            SeanceDAO dao = new SeanceDAO();
            dao.UpdateSeance(descriptif, id);
            return "Mise à jour de la seance avec le nom " + descriptif + " and Id " + id;
        }


    }
}
