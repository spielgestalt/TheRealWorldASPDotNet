using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheRealWorldASPDotNet.Services;
using TheRealWorldASPDotNet.Models;
using System.Net;
using System.Web;
using System.Linq;
using System;

[Serializable]
public class PageModel { 
    public string Title { get; set; }
    public string Parent { get; set; }
}
namespace TheRealWorldASPDotNet.Controllers {
    [Route("api/[controller]")]
    public class PagesController : Controller {
        private PagesDbContext _context;

        public PagesController(PagesDbContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetPages()
        {

            return Ok(_context.Pages);
        }
        // GET api
        [HttpGet("{id}")]
        public ActionResult GetPage(Guid id) {
            var result = _context.Pages.Find(id);
            if (result == null) {
                return BadRequest(this.BuildJsonError("not found", $"The {id.ToString()} could not be found."));
            }
            //_context.Entry(result).Reference(b => b.Parent).Load();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult PutPage(Guid id, [FromBody] PageModel page) {
            Page result = _context.Pages.Find(id);

            if (result == null) {
                return BadRequest(this.BuildJsonError("not found", $"The {id.ToString()} could not be found."));
            }
            if (page.Parent != null)
            {
                Guid parentId = Guid.Parse(page.Parent);
                Page parentPage = _context.Pages.Single(b => b.Id == parentId);
                result.Parent = parentPage;
            } else {
                result.Parent = null;
            }
            result.Title = page.Title;
            _context.SaveChanges();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePage(Guid id) {
            Page result = _context.Pages.Find(id);
            if (result == null)
            {
                return BadRequest(this.BuildJsonError("not found", $"The {id.ToString()} could not be found."));
            }
            _context.Remove(result);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public ActionResult PostPage([FromBody] PageModel page) {
            if (page.Title != null ) {
                try {
                    Guid parentGuid = Guid.Parse(page.Parent);
                    if (_context.Pages.Where(b => b.Title == page.Title).ToList().Count > 0) {

                        return BadRequest(this.BuildJsonError("duplicate entry", $"Title {page.Title} already exists"));
                    }

                    Page parentPage = _context.Pages.Single(b => b.Id == parentGuid);
                    Page newPage = new Page()
                    {
                        Title = page.Title,
                        Parent = parentPage

                    };
                    _context.Add(newPage);
                    _context.SaveChanges();
                    return Ok();
                } catch {
                    return BadRequest();
                }

            } 
            return BadRequest(this.BuildJsonError("no title", "title has to be provided"));
        }
    }
}