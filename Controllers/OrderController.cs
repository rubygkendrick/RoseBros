using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoseBros.Data;
using RoseBros.Models;
using RoseBros.Models.DTOs;


namespace RoseBros.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private RoseBrosDbContext _dbContext;

    public OrderController(RoseBrosDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost("/newOrder")]
    [Authorize]
    public IActionResult CreateOrder(OrderRose orderRose, [FromQuery] int userId)
    {
        var user = _dbContext.UserProfiles.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return NotFound("User doesn't exist in the system");
        }

        var existingOrder = _dbContext.Orders
            .SingleOrDefault(o => o.IsActive && o.UserProfileId == userId);

        if (existingOrder == null)
        {
            // Create a new order and new OrderRose
            var newOrder = new Order
            {
                UserProfileId = userId,
                PurchaseDate = DateTime.Now,
                IsFulfilled = false,
                IsActive = true,
            };

            _dbContext.Orders.Add(newOrder);
            _dbContext.SaveChanges(); // Save to get the new Order ID

            var newOrderRose = new OrderRose
            {
                OrderId = newOrder.Id, // Use the generated ID
                RoseId = orderRose.RoseId,
                Quantity = orderRose.Quantity
            };

            _dbContext.OrderRoses.Add(newOrderRose);
            _dbContext.SaveChanges();

            return NoContent();
        }
        else
        {
            var newOrderRose = new OrderRose
            {
                OrderId = existingOrder.Id,
                RoseId = orderRose.RoseId,
                Quantity = orderRose.Quantity
            };

            _dbContext.OrderRoses.Add(newOrderRose);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }




}