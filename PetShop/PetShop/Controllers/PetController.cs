using Microsoft.AspNetCore.Mvc;
using PetShop.BL.Interfaces;
using PetShop.Models.Models;
using System.Reflection.Metadata.Ecma335;

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

        [HttpGet("GetAll")]

        public List<Pet> GetAll()
        {
            return _petService.GetAll();
        }

        [HttpGet("GetById")]

        public ActionResult<Pet> GetById(int id)
        {
            var pet = _petService.GetById(id);

            if(pet == null)
            {
                return NotFound("Pet not found!");
            }
            return pet;
        }

        [HttpPost("Add")]

        public ActionResult<Pet> Add([FromBody]Pet pet)
        {
            _petService.Add(pet);
            return CreatedAtAction(nameof(GetById), new {id = pet.Id}, pet);
        }

        [HttpPut("Update")]

        public IActionResult Update([FromBody]Pet pet)
        {
            if(pet == null || pet.Id <= 0)
            {
                return BadRequest("Inavalid input. Please provide a valid pet object!");
            }

            var existingPet = _petService.GetById(pet.Id);
            if(existingPet == null)
            {
                return NotFound("Pet not found!");
            }

            _petService.Update(pet);

            return NoContent();
        }

        [HttpDelete("Delete")]
        
        public IActionResult Delete(int id)
        {
            var result = _petService.Delete(id);

            if(result)
            {
                return NoContent();
            }
            else
            {
                return NotFound("Pet not found!");
            }
        }
    }
}
