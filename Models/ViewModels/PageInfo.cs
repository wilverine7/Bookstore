﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        //calculates number of pages needed casts to decimal and then back to int
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);


    }
}
