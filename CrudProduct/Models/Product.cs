using System.ComponentModel.DataAnnotations;

namespace CrudProduct.Models;

public class Product
{
    public int id { get; set; }

    [Required, MaxLength(100)]
    public string name { get; set; }

    public string description { get; set; }

    [Required, Range(0.01, double.MaxValue)]
    public decimal price { get; set; }

    public DateTime registrationDate { get; set; } = DateTime.UtcNow;
}
