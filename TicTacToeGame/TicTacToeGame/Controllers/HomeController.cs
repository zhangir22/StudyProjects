using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicTacToeGame.Models;

namespace TicTacToeGame.Controllers
{
    public class HomeController : Controller
    {
        public TicTacToe game = new TicTacToe();
        public ActionResult Index()
        {
           
            return View();
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Game()
        {
            
            return View();

        }
       
        [Authorize]
        [HttpPost]
        public ActionResult Game(int[,] data) 
        {
            
            return View(data);

        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}