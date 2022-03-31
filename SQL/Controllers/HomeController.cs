using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SQL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SQL.Controllers
{
    public class HomeController : Controller
    {
        
        private IBowlersRepository _repo { get; set; }
        

        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
         
        }

        public IActionResult Index()
        {
            ViewBag.Teams = _repo.Teams.ToList();
            var yeet = _repo.Bowlers.Include(x => x.Teambowler).ToList();
            return View(yeet);
        }

        public IActionResult Teams (int id)
        {
            ViewBag.Team = _repo.Teams.Single(x => x.TeamID == id);
            ViewBag.Teams = _repo.Teams.ToList();
            var players = _repo.Bowlers.Where(x => x.TeamID == id).ToList();
            return View(players);
        }
        
        [HttpGet]
        public IActionResult AddBowler()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            _repo.AddBowler(b);
            _repo.SaveChanges(b);
            return View("BowlerAdded", b);
        }

        [HttpGet]
        public IActionResult EditBowler(int BowlerID)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == BowlerID);
            return View(bowler);
        }
        [HttpPost]
        public IActionResult EditBowler(Bowler b)
        {

            _repo.UpdateBowler(b);
            
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int BowlerID)
        {
            
            _repo.DeleteBowler(BowlerID);
            return View();
        }
    }
}
