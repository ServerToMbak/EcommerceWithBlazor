using E_CommerceBlazor.Shared.Model;

namespace E_CommerceBlazor.Server.Repossitory.Abstract
{
    public interface IPaymentService
    {
        Task<Response> CreatePaymentRequest(string basketId, Iyzipay.Model.PaymentCard card);
    }
}
