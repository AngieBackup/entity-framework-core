using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BdEntityFramework.Data.Repositories;
using BdEntityFramework.Models;
using System.Linq;

namespace BdEntityFramework.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TeachersController : ControllerBase
  {
    IRepository<Teacher> _repository = null;

    public TeachersController(IRepository<Teacher> repository)
    {
      this._repository = repository;
    }

    // GET api/teachers
    [HttpGet]
    public ActionResult<IEnumerable<Teacher>> Get() =>
      _repository.GetAll().ToList();

    // GET api/teachers/5
    [HttpGet("{id}")]
    public ActionResult<Teacher> Get(int id) =>
      _repository.GetById(id);

    // POST api/teachers
    [HttpPost]
    public void Post([FromBody] Teacher value)
    {
    _repository.Insert(value);
      _repository.Save();
    }

    // PUT api/teachers/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Teacher teacher)
    {
      // Update the teacher properties.
      Teacher modified = _repository.GetById(id);
      modified.Firstname = teacher.Firstname;
      modified.Lastname = teacher.Lastname;
      modified.Subjects = teacher.Subjects;

      // Save the changes.
      _repository.Update(modified);
      _repository.Save();
    }

    // DELETE api/teachers/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Teacher match = _repository.GetById(id);
      _repository.Delete(match);
      _repository.Save();
    }
  }
}
