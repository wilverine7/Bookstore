﻿using Bookstore.Infastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //either goes and gets the session info that already exists or creates a new session
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            //assigns the session info that was found to the instances of session.
            cart.Session = session;

            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }


        public override void AddItem(Books book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(Books book)
        {
            base.RemoveItem(book);
            Session.SetJson("Cart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }


    }
}
