using System;
using System.ComponentModel.DataAnnotations;

namespace BdEntityFramework.Models
{
  public class Subject : Entity
  {
    [MaxLength(500)]
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
  }   
}