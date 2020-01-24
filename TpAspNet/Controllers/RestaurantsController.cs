using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Data.DB;
using App.Data.Model;
using App.Data.Services;
using Microsoft.AspNetCore.Http;

namespace TpAspNet.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly RestaurantsServices _services;

        public RestaurantsController()
        {
            _services = new RestaurantsServices();
        }

        // GET: Restaurants
        public IActionResult Index()
        {
            return View(_services.getHome());
        }

        // GET: Restaurants/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _services.getDetails(id);
            //var restaurant = await _context.Restaurants
                //.FirstOrDefaultAsync(m => m.id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var r = new Restaurant();
                r.name = collection["name"];
                r.phone = collection["phone"];
                r.comment = collection["comment"];
                r.email = collection["email"];
                r.note = new Note
                {
                    valueNote = int.Parse(collection["note.valueNote"])
                };
                r.address = new Address
                {
                    rue = collection["address.rue"],
                    CP = collection["address.CP"],
                    city = collection["address.city"]
                };
                _services.createAction(r);
                return RedirectToAction(nameof(Index));
            }
            return View(collection);
        }

        // GET: Restaurants/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant =  _services.getEdit(id);

            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, IFormCollection collection)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var r = _services.getDetails(id);
                    r.name = collection["name"];
                    r.phone = collection["phone"];
                    r.comment = collection["comment"];
                    r.email = collection["email"];
                    r.note = new Note 
                    { 
                        valueNote = int.Parse(collection["note.valueNote"]) 
                    };
                    r.address = new Address
                    {
                        rue = collection["address.rue"],
                        CP = collection["address.CP"],
                        city = collection["address.city"]
                    };
                    _services.editAction(r);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists((int)id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_services.getDetails(id));
        }

        // GET: Restaurants/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _services.getDetails(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _services.deleteAction(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _services.restaurantExists(id);
        }
    }
}
