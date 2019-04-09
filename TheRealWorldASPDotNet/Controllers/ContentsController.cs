using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheRealWorldASPDotNet.Services;
using TheRealWorldASPDotNet.Models;
using System.Net;
using System.Web;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;

namespace TheRealWorldASPDotNet.Controllers
{
    [Route("api/[controller]")]

    public class ContentsController: Controller
    {
        [Serializable]
        public class ContentElementModel {
            public string Content { get; set; }
            public string Page { get; set; }
        }

        private readonly PagesDbContext _context;
        private readonly ILogger _logger;

        public ContentsController(PagesDbContext contex, ILogger<ContentsController> logger)
        {
            _context = contex;
            _logger = logger;
            foreach ( var element in _context.Contents) {
                var text = element.TextContent;
                var page = element.Page;
                _logger.LogWarning($"text:{text}");

            }
        }

        [HttpGet("{pageId}")]
        public ActionResult GetContentElements(Guid pageId) {
            return Ok(_context.Contents.Where(b => b.Page.Id == pageId));
            /*try {
                IEnumerable<ContentElement> contentElements = _context.ContentElements.Where(b => b.Page.Id == pageId);

                return Ok(contentElements);
            } catch {
                return BadRequest();
            }*/

        }


        private ActionResult postContentElement(Page page, ContentElementModel contentElement) {
            try {
                Content newContentElement = new Content()
                {
                    TextContent = contentElement.Content,
                    Page = page
                };
                _context.Add(newContentElement);
                _context.SaveChanges();
                return Ok(newContentElement);
            } catch {
                return BadRequest();
            }

        }

        [HttpPost]
        public ActionResult PostContentElement([FromBody] ContentElementModel contentElement) {
            if (contentElement.Page == null) {
                return BadRequest(this.BuildJsonError("not found", "No Page id given"));
            }
            Guid pageId = Guid.Parse(contentElement.Page);
            Page page = _context.Pages.Find(pageId);
            return postContentElement(page, contentElement);
        }

        [HttpPost("{pageId}")]
        public ActionResult PostContentElement(Guid pageId, [FromBody] ContentElementModel contentElement)
        {
            Page page = _context.Pages.Find(pageId);
            return postContentElement(page, contentElement);
        }
    }
}
