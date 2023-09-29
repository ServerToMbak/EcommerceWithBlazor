using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBlazor.Shared.Model
{
    public class PaymentCard
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireYear { get; set; }
        public string ExpireMonth { get; set; }
        public string Cvc { get; set; }
        public int? RegisterCard { get; set; }
        public string CardAlias { get; set; }
        public string CardToken { get; set; }
        public string CardUserKey { get; set; }    
    }
}
