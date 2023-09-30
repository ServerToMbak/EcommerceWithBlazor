using E_CommerceBlazor.Server.Repossitory.Abstract;
using Iyzipay.Model;
using Microsoft.AspNetCore.Mvc;
using E_CommerceBlazor.Shared.Model;
namespace E_ommerceBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PaymentController :ControllerBase
    {
        private IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost]
        public async Task<ActionResult> MakeThePayment(string basketId, Iyzipay.Model.PaymentCard card)
        {
          var response = await _paymentService.CreatePaymentRequest(basketId, card);
            return Ok(response);
        }    
    }
}
