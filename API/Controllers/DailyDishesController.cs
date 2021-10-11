using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DailyDishes;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers
{
    public class DailyDishesController : BaseApiController
    {
       
        [HttpGet]
        public async Task<ActionResult<List<DailyDish>>> GetDailyDishes()
        {
            return await Mediator.Send(new DishesList.Query());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyDish>> GetDailyDishesByID(Guid id)
        {
            return await Mediator.Send(new DishesDetails.Query{Id = id});
        }
        [HttpPost]
        public async Task<IActionResult> CreateDailyDish(DailyDish dailyDish){
            return Ok(await Mediator.Send(new CreateDish.Command{DailyDish = dailyDish}));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditDailyDish(Guid id, DailyDish dailyDish)
        {
            dailyDish.Id=id;
            return Ok(await Mediator.Send(new EditDish.Command{DailyDish = dailyDish}));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteDish.Command{Id = id}));

        }
    }
}