using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Infastructure;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore.Pages
{
    public class CartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public CartModel (IBookstoreRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }
        
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart.AddItem(b, 1);


            return RedirectToPage(new { ReturnUrl = returnUrl });


        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            //calls the remove item method to remove the selected book from the cart
            cart.RemoveItem(cart.Items.First(x=> x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
