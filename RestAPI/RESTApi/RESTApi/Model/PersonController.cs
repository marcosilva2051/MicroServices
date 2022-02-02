using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTApi.Services.Implementations;

namespace RESTApi.Model
{
    public class PersonController : Controller
    {
        private readonly IPerson _iperson;
        public PersonController(IPerson iperson)
        {
            _iperson = iperson; 
        }
        // GET: PersonController
        
        [HttpGet("{id}")]
        public ActionResult GetPersonById(int id)
        {
            return Ok(_iperson.FindById(id));
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_iperson.FindAll());
        }      
    }
}
