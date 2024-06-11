using System.ComponentModel.DataAnnotations;

namespace RoseBros.Models;

public class OrderRose
{

    [Required]
    public int OrderId {get; set;}
    public Order? Order {get; set;}

    [Required]
    public int RoseId {get; set;}
    public Rose? Rose {get; set;}

    public decimal Quantity {get; set;}
 
}