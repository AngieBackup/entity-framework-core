using System.ComponentModel.DataAnnotations;

namespace BdEntityFramework.Models
{
  public class Instrument: Entity
  {
    [MaxLength(500)]
    public string Name { get; set; }
    public double Price { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
  }
}