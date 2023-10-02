using E_CommerceBlazor.Shared.Model;
using Iyzipay.Model;

namespace E_CommerceBlazor.Server.Repossitory.Abstract
{
    public interface IPaymentService
    {
        Task<Response> CreatePaymentRequest(string basketId, Shared.Model.PaymentCard card);
        Task<DataResponse<List<Iyzipay.Model.BasketItem>>> BasketItemForPayment(string basketId);
        Task<DataResponse<Iyzipay.Model.Address>> AddressOperationForPayment(Shared.Model.Address address);
        Task<DataResponse<Iyzipay.Model.Buyer>> BuyerOperationForPayment(User user);
    }
}
