using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBlazor.Shared.Model
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
    }
}
