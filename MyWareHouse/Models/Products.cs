using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWareHouse.Models
{
    public class Products
    {
        public int Id { get; set; } //this id is to communicate with user or its for database table Id.Not product registering number id

        [Required]
        [StringLength(1024, ErrorMessage ="tha max is 1024", MinimumLength =3)]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "the price can't be less than zero")]
        public int Price { get; set; }
        public string Catagory { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
    }
}