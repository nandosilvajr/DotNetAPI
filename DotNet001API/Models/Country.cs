﻿namespace DotNet001API.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string CountryCode { get; set; } = string.Empty;
    }
}
