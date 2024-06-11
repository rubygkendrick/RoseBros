using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoseBros.Data;
using RoseBros.Models;
using RoseBros.Models.DTOs;


namespace RoseBros.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderRoseController : ControllerBase
{
    private RoseBrosDbContext _dbContext;

    public OrderRoseController(RoseBrosDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost("newOrderRose")]
    [Authorize]
    public IActionResult CreateOrderRose([FromBody] OrderRose orderRose, [FromQuery] int userId)
    {
        var user = _dbContext.UserProfiles.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return NotFound("User doesn't exist in the system");
        }

        var existingOrderRose = _dbContext.OrderRoses.SingleOrDefault(or => or.RoseId == orderRose.RoseId 
        && or.OrderId == orderRose.OrderId);

        if (existingOrderRose != null)
        {
            return BadRequest("This Rose is already in your cart");
        }


            var newOrderRose = new OrderRose
            {
                OrderId = orderRose.OrderId,
                RoseId = orderRose.RoseId,
                Quantity = orderRose.Quantity
            };

            _dbContext.OrderRoses.Add(newOrderRose);
            _dbContext.SaveChanges();

            return Ok(newOrderRose);

        }
       

    }




