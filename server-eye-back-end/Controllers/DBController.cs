using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_eye_back_end.Models;
using server_eye_back_end.Services.Interfaces;

namespace server_eye_back_end.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DBController : ControllerBase
	{
		private readonly IDBService _service;

		public DBController(IDBService service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult ReadADBs()
		{
			List<DB> dbs = _service.ReadADbs();

			return Ok(dbs);
		}

        [HttpGet("avaiable")]
        public IActionResult ReadADBAvaiable()
        {
            List<DB> dbs = _service.ReadADbAvaiable();

            return Ok(dbs);
        }

        [HttpGet("{id}")]
		public IActionResult ReadDBAsById(int id)
		{
			DB db = _service.ReadDbById(id);

			if (db == null)
			{
				return NotFound();
			}
			return Ok(db);
		}

		[HttpPost]
		public IActionResult AddDb([FromBody] DB dbRecebido)
		{
			DB db = _service.AddDb(dbRecebido);

			if (db == null)
			{
				return BadRequest("Problema ao gravar banco");
			}
			return Ok(db);
		}

        [HttpDelete("{id}")]
        public IActionResult DeleteDb(int id)
        {

            DB db = _service.DeleteDb(id);


            if (db == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDb([FromBody] DB db, int id)
        {
            DB dbUpdated = _service.UpdateDb(db, id);

            if (dbUpdated == null)
            {
                return NotFound();
            }
            return Ok(dbUpdated);
        }
    }
}
