using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using APS.net_Entity_.Models;
using Microsoft.AspNetCore.Authorization;

namespace APS.net_Entity_.Pages_Blog
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly APS.net_Entity_.Models.MyBlogContext _context;

        public IndexModel(APS.net_Entity_.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; } = default!;

        public const int ITEMS_PER_PAGE = 3;
        [BindProperty(SupportsGet =true, Name ="p")]
        public int currentPage { get; set; }
        public int countPages { get; set; }

        public async Task OnGetAsync(string SearchString)
        {
            if (_context.articles != null)
            {
                int totalArticle = await _context.articles.CountAsync();
                countPages = (int)Math.Ceiling((double)totalArticle / ITEMS_PER_PAGE);

                if (currentPage < 1)
                    currentPage = 1;
                if (currentPage > countPages)
                    currentPage = countPages;

                //Article = await _context.articles.ToListAsync();
                var qr = (from a in _context.articles
                         orderby a.Created descending
                         select a).Skip((currentPage -1)*3)
                         .Take(ITEMS_PER_PAGE);
                if (!string.IsNullOrEmpty(SearchString))
                {
                    Article = qr.Where(a => a.Title.Contains(SearchString)).ToList();
                }
                else
                {
                    Article = await qr.ToListAsync();
                }

            }

        }
    }
}
