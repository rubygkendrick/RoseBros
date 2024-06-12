

namespace RoseBros.Models.DTOs;

public class OrderDTO
{

    public int Id { get; set; }

    public int UserProfileId { get; set; }

    public UserProfile UserProfile { get; set; }

    public DateTime PurchaseDate { get; set; }
    public bool IsFulfilled { get; set; }
    public bool IsActive { get; set; }

    public List<OrderRose>? OrderRoses { get; set; }

    public decimal Total
    {
        get
        {
            if (OrderRoses == null)
            {
                return 0;
            }
            
           return OrderRoses.Sum(or => (or.Rose?.PricePerUnit ?? 0) * or.Quantity);
        }
    }


}