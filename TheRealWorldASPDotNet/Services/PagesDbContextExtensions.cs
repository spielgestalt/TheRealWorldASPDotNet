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
            context.SaveChanges();
        }
    }
}
