using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BdEntityFramework.Data.Repositories;
using BdEntityFramework.Models;
using System.Linq;

namespace BdEntityFramework.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SubjectsController : ControllerBase
  {
    IRepository<Subject> _repository = null;

    public SubjectsController(IRepository<Subject> repository)
    {
      this._repository = repository;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Subject>> Get() =>
      _repository.GetAll().ToList();

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Subject> Get(int id) =>
      _repository.GetById(id);

    // POST api/values
    [HttpPost]
    public void Post([FromBody] Subject value)
    {
      _repository.Insert(value);
      _repository.Save();
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Subject subject)
    {
      // Update the subject properties.
      Subject modified = _repository.GetById(id);
      modified.Name = subject.Name;
      modified.StartTime = subject.StartTime;
      modified.EndTime = subject.EndTime;
      modified.TeacherId = subject.TeacherId;
      modified.Teacher = subject.Teacher;

      // Save the changes.
      _repository.Update(modified);
      _repository.Save();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Subject match = _repository.GetById(id);
      _repository.Delete(match);
      _repository.Save();
    }
  }
}
