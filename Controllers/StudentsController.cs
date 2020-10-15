using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BdEntityFramework.Data.Repositories;
using BdEntityFramework.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BdEntityFramework.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudentsController : ControllerBase
  {
    IRepository<Student> _repository = null;

    public StudentsController(IRepository<Student> repository)
    {
      this._repository = repository;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Student>> Get() =>
      _repository.GetAll().ToList();

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Student> Get(int id) =>
      _repository.GetById(id);

    // POST api/values
    [HttpPost]
    public void Post([FromBody] Student value)
    {
      _repository.Insert(value);
      _repository.Save();
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Student student)
    {
      // Update the student properties.
      Student modified = _repository.GetById(id);
      modified.Instrument = student.Instrument;
      modified.Lastname = student.Lastname;
      modified.Firstname = student.Firstname;

      // Save the changes.
      _repository.Update(modified);
      _repository.Save();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Student match = _repository.GetById(id);
      _repository.Delete(match);
      _repository.Save();
    }
  }
}
