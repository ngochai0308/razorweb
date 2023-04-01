using APS.net_Entity_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APS.net_Entity_.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyBlogContext _blogContext;    

        public IndexModel(ILogger<IndexModel> logger,MyBlogContext myBlogContext)
        {
            _logger = logger;
            _blogContext = myBlogContext;
        }

        public void OnGet()
        {
            var posts = (from a in _blogContext.articles
                         orderby a.Created descending
                         select a).ToList();
            ViewData["post"]=posts;
        }
    }
}