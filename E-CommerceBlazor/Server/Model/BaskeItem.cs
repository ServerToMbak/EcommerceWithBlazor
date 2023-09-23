﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_CommerceBlazor.Server.Model
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
    }
}