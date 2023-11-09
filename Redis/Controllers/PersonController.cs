using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Redis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        private readonly AppDbContext _context;

        public PersonController(ICacheService cacheService , AppDbContext dbContext)
        {
            _cacheService = cacheService;
            _context = dbContext;
        }

        [HttpGet]

        public ActionResult<List<Person>> GetAll()
        {
            // check data in the cache 

            var data = _cacheService.GetData<List<Person>>("People");

            if (data is not null && data.Count > 0)
                return Ok(data);

            data = _context.People.ToList();

            var expireTime = DateTimeOffset.Now.AddSeconds(30);

            _cacheService.SetData("People", data, expireTime);

            return Ok(data);
        }



    }
}
