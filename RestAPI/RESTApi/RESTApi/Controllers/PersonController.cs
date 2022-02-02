using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTApi.Model;
using RESTApi.Services.Implementations;

namespace RESTApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPerson _personRepo;
        public PersonController(IPerson personRepo)
        {
            _personRepo = personRepo;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_personRepo.FindAll().ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var person = _personRepo.FindById(id);

            if(person == null)
                return NotFound();
            return Ok(person);
        }


        [HttpPut("{id}")]
        public ActionResult Edit(int id, Person person)
        {
            if (person.Id != id)
                return BadRequest();

            //var p = _personRepo.FindById(id).AsNoTracking();
            //if (p == null)
            //    return NotFound();

            _personRepo.Update(person);
            _personRepo.Commit();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _personRepo.FindById(id);
            if (p == null)
                return NotFound();

            _personRepo.Delete(p);
            _personRepo.Commit();
            return Ok(p);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        public ActionResult Create(Person person)
        {
            _personRepo.Create(person);
            _personRepo.Commit();

            return Ok();
        }
    }
}
