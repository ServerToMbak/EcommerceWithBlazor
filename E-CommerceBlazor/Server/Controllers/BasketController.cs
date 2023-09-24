﻿using E_CommerceBlazor.Server.Model;
using E_CommerceBlazor.Server.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBlazor.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpPost("create")]
        public async Task<ActionResult<DataResponse<Basket>>> CreateAndUpdaetDatabase(Basket basket)
        {
            var response = await _basketRepository.UpdateBasket(basket);

            if(response != null) 
            {
                return Ok(response);
            }

            return BadRequest();
            
        }
        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteBasket(string basketId)
        {
            var response = await _basketRepository.DeleteBasketAsync(basketId);
            if(response.Success == false)

            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}