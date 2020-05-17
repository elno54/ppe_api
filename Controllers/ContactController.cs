using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddLicencie([FromBody] Licencie l)
        {
            ContactDAO dao = new ContactDAO();
            dao.AddLicencie(l.Id, l.Nom, l.Prenom, l.Email, l.Tel, l.Mdp);

            if (l != null)
                return Request.CreateResponse(HttpStatusCode.Created, l);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, l);
        }
        [HttpGet]
        public Licencie GetById(long id)
        {
            ContactDAO dao = new ContactDAO();
            List<Licencie> lesLicencie = dao.getAllLicencie();
            return lesLicencie.ElementAt(0);
        }
        [HttpGet]
        public IEnumerable<Licencie> GetAll()
        {
            ContactDAO dao = new ContactDAO();
            List<Licencie> lesContacts = dao.getAllLicencie();
            return lesContacts.ToList();
        }
        [HttpDelete]
        public string DeleteContact(int id)
        {
            ContactDAO dao = new ContactDAO();
            dao.SupprimerLicencie(id);
            return "Contact supprimé id " + id;
        }
        [HttpPut]
        public string UpdateContact(string nom, int id)
        {
            ContactDAO dao = new ContactDAO();
            dao.UpdateLicencie(nom, id);
            return "Mise à jour du contact avec le nom " + nom + " and Id " + id;
        }


    }
}
