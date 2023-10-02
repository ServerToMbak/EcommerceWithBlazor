using E_CommerceBlazor.Server;
using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Client.Services.Abstract
{
    public interface IPaymentService
    {
        Task<Response> MakeThePayment(string basketId, PaymentCard card);
    }
}
