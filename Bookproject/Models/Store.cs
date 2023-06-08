﻿using System.Collections.Generic;

namespace LookProject.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Address { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<BookStore> Book { get; set; }

    }
}
