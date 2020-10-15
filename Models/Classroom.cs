using System.Collections.Generic;

namespace BdEntityFramework.Models
{
  public class Classroom : Entity
  {
    public List<Subject> Subjects { get; set; }
  }
}