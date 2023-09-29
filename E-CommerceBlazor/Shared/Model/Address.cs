using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBlazor.Shared.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Address")]
        public string Description { get; set; }
        public string ZipCode { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
