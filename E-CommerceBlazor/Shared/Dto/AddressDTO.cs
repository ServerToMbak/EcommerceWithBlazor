using E_CommerceBlazor.Shared.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBlazor.Shared.Dto
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ZipCode { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
    }
}
