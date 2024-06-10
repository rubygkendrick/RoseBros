
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace RoseBros.Models;

public class Order
{
   
    public int Id { get; set; }

    [Required]
    public int UserProfileId {get; set;}

    public UserProfile UserProfile {get; set;}

    [Required]
    public DateTime PurchaseDate {get; set;}
    [Required]
    public bool IsFulfilled {get; set; }

    public List <OrderRose>? OrderRoses {get; set;}

    [NotMapped]
    public decimal Total 
    {
        get 
        {
            return OrderRoses.Sum(or => or.Rose.PricePerUnit * or.Quantity);
        }
    }
 

}