using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string category, int pageNum = 1)
        {
            int resultsNum = 5;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * resultsNum)
                .Take(resultsNum),

                PageInfo = new PageInfo
                {
                    //calculates number of pages based on the category selected not the total of all records
                    TotalNumBooks = (category == null ? repo.Books.Count() : repo.Books.Where(x=> x.Category == category).Count()),
                    BooksPerPage = resultsNum,
                    CurrentPage = pageNum

                }
            };


            return View(x);
        }
    }
}
