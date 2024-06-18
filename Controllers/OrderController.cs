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

    [HttpPost("newOrder")]
    [Authorize]
    public IActionResult CreateOrder([FromQuery] int userId)
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
            var newOrder = new Order
            {
                UserProfileId = userId,
                PurchaseDate = DateTime.Now,
                IsFulfilled = false,
                IsActive = true,
            };

            _dbContext.Orders.Add(newOrder);
            _dbContext.SaveChanges();

            return Ok(newOrder);
        }
        else
        {
            return Ok(existingOrder);
        }

    }

    [HttpGet("active/{userId}")]
    [Authorize]
    public IActionResult GetActiveORderByUserId(int userId)
    {
        Order activeOrder = _dbContext.Orders
         .Include(o => o.OrderRoses)
         .ThenInclude(or => or.Rose).Where(o => o.IsActive == true)
         .SingleOrDefault(o => o.UserProfileId == userId);

        if (activeOrder == null)
        {
            return Ok();
        }

        return Ok(new OrderDTO
        {
            Id = activeOrder.Id,
            UserProfileId = activeOrder.UserProfileId,
            UserProfile = activeOrder.UserProfile,
            IsActive = activeOrder.IsActive,
            IsFulfilled = activeOrder.IsActive,
            OrderRoses = activeOrder.OrderRoses,
        });
    }

    [HttpPut("complete/{orderId}")]
    [Authorize]
    public IActionResult CompleteOrder(int orderId)
    {

        Order orderToComplete = _dbContext.Orders
         .SingleOrDefault(o => o.Id == orderId);

        if (orderToComplete == null)
        {
            return NotFound("This order does not exist");
        }

        orderToComplete.IsActive = false;
        orderToComplete.PurchaseDate = DateTime.Now;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Get()
    {
        var orders = _dbContext.Orders
            .Include(o => o.OrderRoses)
            .ThenInclude(or => or.Rose)
            .Where(o => !o.IsActive)
            .OrderBy(o => o.IsFulfilled)
            .Select(o => new OrderDTO
            {
                Id = o.Id,
                UserProfileId = o.UserProfileId,
                UserProfile = o.UserProfile,
                IsActive = o.IsActive,
                IsFulfilled = o.IsFulfilled,
                PurchaseDate = o.PurchaseDate,
                OrderRoses = o.OrderRoses,
            })
            .ToList();

        return Ok(orders);
    }



}