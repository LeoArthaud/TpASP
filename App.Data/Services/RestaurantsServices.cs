using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using App.Data.DB;
using App.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Services
{
    public class RestaurantsServices
    {
        private RestaurantsContext _context;

        public RestaurantsServices()
        {
            this._context = new RestaurantsContext();
        }

        public List<Restaurant> getAllResto()
        {

            var allResto = this._context.Restaurants.Include(r => r.address).Include(r => r.note).ToList();
            return allResto;
        }

        public List<Restaurant> getHome()
        {
            return this._context.Restaurants.Include(x => x.address).Include(x => x.note).ToList();
        }

        public List<Restaurant> TopFive()
        {
            return this._context.Restaurants.Include(x => x.address).Include(r => r.note).OrderByDescending(r=>r.note.valueNote).ToList();
        }

        public Restaurant getDetails(int? id)
        {
            return this._context.Restaurants.FirstOrDefault(m => m.id == id);
        }

        public void createAction(Restaurant restaurant)
        {
                _context.Add(restaurant);
                _context.SaveChanges();
            
        }

        public void createActionRange(List<Restaurant> restaurant)
        {
            _context.Restaurants.AddRange(restaurant);
            _context.SaveChanges();
        }

            public Restaurant getEdit(int? id)
        {
            var restaurant = _context.Restaurants.Include(x => x.address).Include(x => x.note).SingleOrDefault(x=>x.id==id);
            return restaurant;
        }

        public void editAction(Restaurant restaurant)
        {
            _context.Update(restaurant);
            _context.SaveChanges();
        }

        public void deleteAction(int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
        }

        public bool restaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.id == id);

        }
    }


    //_context.Restaurants.ToList()
}
