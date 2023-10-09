using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBlazor.Shared.Dto
{
    public class CouponCreateDTO
    {
        public string Code { get; set; }
        public int Discount { get; set; }
    }
}
