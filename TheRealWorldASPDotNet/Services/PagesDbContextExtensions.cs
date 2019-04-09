using System;
using System.Collections.Generic;
using System.Linq;
using TheRealWorldASPDotNet.Models;
namespace TheRealWorldASPDotNet.Services
{
    public static class PagesDbContextExtensions
    {
        public static void CreateSeedData(this PagesDbContext context) { 
            if (context.Pages.Any()) {
                return;
            }
            var pages = new List<Page>() { 
                new Page() {
                    Title = "Home"
                },
                new Page() {
                    Title = "impress"
                }
            };


            context.AddRange(pages);
            Page homePage = pages.First();
            var contents = new List<Content>()
            {
                new Content() {
                    Page = homePage,
                    TextContent = "Lorem ipum 1"
                },
                new Content() {
                    Page = homePage,
                    TextContent = "Something with Homepage"
                }
            };
            context.AddRange(contents);
            context.SaveChanges();
        }
    }
}
