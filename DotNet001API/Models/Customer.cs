﻿namespace DotNet001API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get;  set; }

        public ICollection<Order> Orders { get; set; }

    }
}
