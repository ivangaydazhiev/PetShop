using Microsoft.AspNetCore.Mvc;
using PetShop.BL.Interfaces;
using PetShop.Models.Models;

namespace PetShop.Controllers
{
    [ApiController]
    [Route("api/pets")]

    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]

        public List<Pet> GetAll()
        {
            return _petService.GetAll();
        }

        [HttpGet("{id}")]

        public ActionResult<Pet> GetById(int id)
        {
            var  pet = _petService.GetById(id);

            if(pet == null)
            {
                return NotFound();
            }
            return pet;
        }

        [HttpPost]

        public ActionResult<Pet> Add(Pet pet)
        {
            _petService.Add(pet);
            return CreatedAtAction(nameof(GetById), new {id = pet.Id }, pet);
        }

        [HttpPost("{id}")]

        public IActionResult Update(int id, Pet pet)
        {
            if(id != pet.Id)
            {
                return BadRequest();
            }
            _petService.Update(pet);
            return NoContent();
        }

        [HttpDelete("{id}")]
        
        public IActionResult Delete(int id)
        {
            _petService.Delete(id);
            return NoContent();
        }
    }
}
