using System.ComponentModel.DataAnnotations;

namespace BdEntityFramework.Models
{
  public class Student : Entity
  {
    [MaxLength(500)]
    public string Firstname { get; set; }

    [MaxLength(800)]
    public string Lastname { get; set; }
    
    public Instrument Instrument { get; set; }
  }
}