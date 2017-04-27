using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finalEvent.Models;

namespace finalEvent.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public bool Searcher(String Email)
        {
            using (var context = new DbModel())
              try
                {
                    return context.Users.Any(u => u.Email.Equals (Email));
                    
                }
                catch
                {
                    return false;
                }
            
            
        }

    }
}