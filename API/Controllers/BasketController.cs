using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepositary _basketRepositary;
        public BasketController(IBasketRepositary basketRepositary)
        {
            _basketRepositary = basketRepositary;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepositary.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        } 
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updatedBasket = await _basketRepositary.UpdateBasketAsync(basket);
            return Ok(updatedBasket);
        }
        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepositary.DeleteBasketAsync(id);
        }
    }
}