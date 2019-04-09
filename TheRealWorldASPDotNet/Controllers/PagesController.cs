using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheRealWorldASPDotNet.Services;
using TheRealWorldASPDotNet.Models;

namespace TheRealWorldASPDotNet.Controllers {
    [Route("api/[controller]")]
    public class PagesController : Controller {
        private PagesDbContext _context;

        public PagesController(PagesDbContext context) {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult GetPages()
        {

            return Ok(_context.Pages);
        }
    }
}