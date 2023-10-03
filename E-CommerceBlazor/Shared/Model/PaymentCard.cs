using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceBlazor.Shared.Model
{
    public class PaymentCard
    {
        [Required(ErrorMessage ="Kart sahibi isim soyisim bilgisi boş bırakılamaz")]
        public string CardHolderName { get; set; }
        [Required(ErrorMessage = "Kart Numarsı boş bırakılamaız")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage ="Yıl boş bırakılamaz")]
        public string ExpireYear { get; set; }
        [Required(ErrorMessage = "Ay boş bırakılamaz")]
        public string ExpireMonth { get; set; }
        [Required(ErrorMessage ="Cvc Zorunludur")]
        public string Cvc { get; set; }
        public int? RegisterCard { get; set; }
        public string? CardAlias { get; set; }
        public string? CardToken { get; set; }
        public string? CardUserKey { get; set; }    
    }
}
