using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BdEntityFramework.Data.Repositories;
using BdEntityFramework.Models;
using System.Linq;

namespace BdEntityFramework.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ClassroomsControler : ControllerBase
  {
    IRepository<Classroom> _repository = null;

    public ClassroomsControler(IRepository<Classroom> repository)
    {
      this._repository = repository;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Classroom>> Get() =>
      _repository.GetAll().ToList();

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Classroom> Get(int id) =>
      _repository.GetById(id);

    // POST api/values
    [HttpPost]
    public void Post([FromBody] Classroom value)
    {
      _repository.Insert(value);
      _repository.Save();
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Classroom classroom)
    {
      // Update the classroom properties.
      Classroom modified = _repository.GetById(id);
      modified.Subjects = classroom.Subjects;

      // Save the changes.
      _repository.Update(modified);
      _repository.Save();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Classroom match = _repository.GetById(id);
      _repository.Delete(match);
      _repository.Save();
    }
  }
}
