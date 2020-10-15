using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BdEntityFramework.Models
{
  public class Teacher : Entity
  {
    [MaxLength(500)]
    public string Firstname { get; set; }

    [MaxLength(800)]
    public string Lastname { get; set; }
    
    public List<Subject> Subjects { get; set; }
  }
}