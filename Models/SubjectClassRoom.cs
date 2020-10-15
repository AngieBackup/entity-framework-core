namespace BdEntityFramework.Models
{
  public class SubjectClassroom : Entity
  {
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public int ClassroomId { get; set; }
    public Classroom Classroom { get; set; }
    
  }
}