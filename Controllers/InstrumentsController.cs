using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BdEntityFramework.Data.Repositories;
using BdEntityFramework.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BdEntityFramework.Controllers
{
  [Route("api/instruments")]
  [ApiController]
  public class InstrumentsControler : ControllerBase
  {
    IRepository<Instrument> _repository = null;

    public InstrumentsControler(IRepository<Instrument> repository)
    {
      this._repository = repository;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Instrument>> Get() =>
      _repository.GetAll().ToList();

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Instrument> Get(int id) =>
      _repository.GetById(id);

    // POST api/values
    [HttpPost]
    public void Post([FromBody] Instrument value)
    {
      _repository.Insert(value);
      _repository.Save();
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Instrument instrument)
    {
      // Update the instrument properties.
      Instrument modified = _repository.GetById(id);
      modified.Name = instrument.Name;
      modified.Name = instrument.Name;

      // Save the changes.
      _repository.Update(modified);
      _repository.Save();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Instrument match = _repository.GetById(id);
      _repository.Delete(match);
      _repository.Save();
    }
  }
}
