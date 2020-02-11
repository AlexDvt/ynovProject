using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplicationYnov.Models;
using WebApplicationYnov.ViewModel;

namespace WebApplicationYnov.Controllers
{
    public class UserController : ApiController
    {
        public YNOVEntities2 Context { get; set; }
        public UserController()
        {
            Context = new YNOVEntities2();
            Context.Configuration.ProxyCreationEnabled = false;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }

        //GET 
        [Route("api/user/{login}/{mdp}")]
        public IHttpActionResult Get(string login, string pwd)
        {
            var errors = new List<string>();
            // Comparer les logins et mdp
            var res = Context.Users.Where(u => u.user_mail == login && u.user_password == pwd).Select(e => new UserVM { IdUser = e.id_user, MailUser = e.user_mail });
            try
            {
                // Verifier si login et password sont bons
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("api/user/{id}")]
        public IHttpActionResult GetUserId(int id)
        {
            var errors = new List<string>();
            // chercher le user selon son id
            var res = Context.Users.Where(u => u.id_user == id).Select(u => u.user_mail);
            try
            {
                // Verifier si l'id existe
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // POST
        [Route("api/user/create")]
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User utilisateur)
        {
            try
            {
                var errors = new List<string>();
                if (utilisateur.user_password == null) errors.Add("Aucun mot de passe renseigné");
                if (utilisateur.user_last_name == null) errors.Add("Aucun nom renseigné");
                if (utilisateur.user_first_name == null) errors.Add("Aucun prenom renseigné");
                if (utilisateur.user_mail == null) errors.Add("Aucun email renseigné");
                if (errors.Count() < 1)
                {
                    utilisateur.user_role = false;
                    Context.Users.Add(utilisateur);
                    Context.SaveChanges();
                    return Ok(utilisateur);
                }
                else
                {
                    return Ok(errors);
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
