using Microsoft.AspNetCore.Mvc;
using gregslist_again.Models;
using gregslist_again.services;

namespace gregslist_again.Controllers
{
    [ApiController]
    [Route("controller")]
    public class HouseController : ControllerBase
    {
        private readonly HouseService _service;

        public HouseController(HouseService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<House> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<House> Edit([FromBody] House editHouse, int id)
        {
            try
            {
                editHouse.Id = id;
                return Ok(_service.Edit(editHouse));

            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }
}