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

    [HttpPut("updateQuantity")]
    [Authorize]
    public IActionResult UpdateQuantity([FromQuery] int qty, [FromQuery] int roseId, [FromQuery] int userId)
    {

        Order activeOrder = _dbContext.Orders
         .Include(o => o.OrderRoses)
         .ThenInclude(or => or.Rose).Where(o => o.IsActive == true)
         .SingleOrDefault(o => o.UserProfileId == userId);

        if (activeOrder == null)
        {
            return NotFound("This order does not exist");
        }

        OrderRose roseToUpdate = activeOrder.OrderRoses.SingleOrDefault(or => or.RoseId == roseId);

        if (roseToUpdate == null)
        {

            return NotFound("This rose doesnt seem to be in your cart");
        }

        roseToUpdate.Quantity = qty;


        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("delete")]
    [Authorize]
    public IActionResult DeleteOrderRose([FromQuery] int roseId, [FromQuery] int orderId)
    {
        Order activeOrder = _dbContext.Orders
          .Include(o => o.OrderRoses)
          .SingleOrDefault(o => o.Id == orderId);

        if (activeOrder == null)
        {
            return NotFound("This order does not exist");
        }

        OrderRose roseToDelete = activeOrder.OrderRoses.SingleOrDefault(or => or.RoseId == roseId);

        if (roseToDelete == null)
        {

            return NotFound("This rose does not seem to be in your cart");
        }


        _dbContext.OrderRoses.Remove(roseToDelete);
        _dbContext.SaveChanges();
       
        if (!activeOrder.OrderRoses.Any())
        {
            _dbContext.Orders.Remove(activeOrder);
        }

        _dbContext.SaveChanges();

        return NoContent();
    }




}




