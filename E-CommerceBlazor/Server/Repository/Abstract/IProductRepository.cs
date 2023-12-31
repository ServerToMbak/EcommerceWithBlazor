﻿using E_CommerceBlazor.Shared.Model;
using E_CommerceBlazor.Shared.Dto;

namespace E_CommerceBlazor.Server.Repository.Abstract
{
    public interface IProductRepository
    {
        Task<Response> Add (Product product);
        Task<Response> Delete(int id);
        Task<DataResponse<ProductReadDTO>> GetById(int id);
        Task<DataResponse<List<ProductReadDTO>>> GetAll();
    }
}
