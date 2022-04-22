using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebGroup.Models;

namespace WebGroup.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Models.GolovinContext db = new GolovinContext();
        private int blockid = 0;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Feedback> lfb = db.Feedbacks.ToList();
            List<AuthorFeedback> laf = db.AuthorFeedbacks.ToList();
            List<StatusStudent> lss = db.StatusStudents.ToList(); 
            List<Project> lp = db.Projects.ToList();
            List<Member> lmo = db.Members.ToList();
            List<TypeProject> ltp = db.TypeProjects.ToList();

            return View(Tuple.Create(lfb, lss, laf, lp, lmo));
        }


        public IActionResult AboutCollege()
        {
            return View();
        }
        public IActionResult Team()
        {
            List<Member> mem = db.Members.Where(c => c.Status != 9).ToList();
            List<StatusStudent> lstatus = db.StatusStudents.ToList();
             
            return View(Tuple.Create(mem, lstatus));
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetRequest(string LastName, string FirstName, string Email, string Phone, string Text)
        {
            ContactPerson cp = new ContactPerson
            {
                FirstName = FirstName,
                LastName = LastName,
                Text = Text,
                Email = Email,
                Phone = Phone
            };
            db.ContactPeople.Add(cp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult NewsSingle(int id)
        {
            Models.News n = db.News.SingleOrDefault(c => c.Id == id);
            Member m = db.Members.SingleOrDefault(c => c.Id == n.Author);

            return View(Tuple.Create(n,m));
        }
        public IActionResult Achievement()
        {
            List<Models.Achievement> la = db.Achievements.ToList();
            List<Member> lm = db.Members.ToList();
            return View(Tuple.Create(la, lm));
        }
        public IActionResult Project()
        {
            List<Project> lp = db.Projects.ToList();
            List<TypeProject> ltp = db.TypeProjects.ToList();
            List<Member> lm = db.Members.ToList();
            return View(Tuple.Create(lp, ltp, lm));
        }
        public IActionResult News()
        {
            List<News> lnews = db.News.ToList();
            List<Member> lmem = db.Members.ToList();

            return View(Tuple.Create(lnews, lmem));
        }
        [HttpPost]
        public IActionResult SendComment(int? id, int idBlog, string LastName, string FirstName, string Text)
        {
            AuthorFeedback au =
                db.AuthorFeedbacks.SingleOrDefault(c => c.FirstName == FirstName && c.LastName == LastName);
            if (au is null)
            {
                au = new AuthorFeedback
                {
                    LastName = LastName,
                    FirstName = FirstName
                };
                db.AuthorFeedbacks.Add(au);
                db.SaveChanges();
            }

            Comment com = new Comment
            {
                Author = au.Id,
                Date = DateTime.Now,
                Text = Text,
                Publication = idBlog
            };
            if (id != null)
            {
                com.OwnerComment = id;
            }

            
            db.Comments.Add(com);
            db.SaveChanges();
            
            return RedirectToAction("BlockSingle", new { id = idBlog });
        }

        public IActionResult FeedBacks()
        {
            List<Feedback> lfb = db.Feedbacks.ToList();
            List<AuthorFeedback> laf = db.AuthorFeedbacks.ToList();
            return View(Tuple.Create(lfb, laf));
        }
        [HttpPost]
        public IActionResult SendFeedback(string LastName, string FirstName, string Post, string Text)
        {
            AuthorFeedback au =
                db.AuthorFeedbacks.SingleOrDefault(c => c.FirstName == FirstName && c.LastName == LastName);
            if (au is null)
            {
                au = new AuthorFeedback
                {
                    LastName = LastName,
                    FirstName = FirstName
                };
                db.AuthorFeedbacks.Add(au);
                db.SaveChanges();
            }
            Feedback fb = new Feedback
            {
                Author = au.Id,
                Post = Post,
                Text = Text
            };
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return RedirectToAction("FeedBacks");
        }
        public IActionResult BlockSingle(int id)
        {
            
            
            Blog bl = db.Blogs.SingleOrDefault(c => c.Id == id);
            if (bl is null)
                return RedirectToAction("Error");
            Member mem = db.Members.SingleOrDefault(c => c.Id == bl.Author);
            List<Comment> lcom = db.Comments.Where(c => c.Publication == bl.Id && c.OwnerComment == null).ToList();
            List<Commentor> lcoment = new List<Commentor>();
            foreach (var item in lcom)
            {
                Commentor com = new Commentor();
                AuthorFeedback au = db.AuthorFeedbacks.SingleOrDefault(c => c.Id == item.Author);
                com.Author = au.FirstName + " " + au.LastName;
                com.Text = item.Text;
                com.Date = item.Date;
                com.Id = item.Id;
                List<Comment> lc = db.Comments.Where(c => c.OwnerComment == item.Id).ToList();
                List<ChildCommentor> lcc = new List<ChildCommentor>();
                foreach (var VARIABLE in lc)
                {
                    AuthorFeedback au2 = db.AuthorFeedbacks.SingleOrDefault(c => c.Id == VARIABLE.Author);
                    ChildCommentor cc = new ChildCommentor
                    {
                        Comment = VARIABLE,
                        Author = au2.FirstName + " " + au2.LastName
                    };
                    lcc.Add(cc);
                }

                com.Children = lcc;
                lcoment.Add(com);
            }
            
            List<Blog> lblock = db.Blogs.ToList();
            List<Comment> lcomall = db.Comments.ToList();
            return View(Tuple.Create(bl, mem, lcoment, lblock, lcomall));
        }
        public IActionResult BlogAll(int page)
        {
            
            List<Blog> lbc = db.Blogs.ToList();
            int g = 0;
            int h = 6;
            if (lbc.Count % h == 0)
                g = lbc.Count / h;
            else
            {
                g = lbc.Count / h + 1;
            }
            if (page > g)
                return RedirectToAction("Error");
            List<Blog> lb = new List<Blog>();
            for (int i = page*h; i < page * h+h; i++)
            {
                if (i <= lbc.Count - 1)
                {
                    lb.Add(lbc[i]);
                }
            }
            List<Member> lm = db.Members.ToList();
            List<int> pages;
            if (page == 0)
            {
                pages = new List<int>
                {
                    1,2,g
                };
            }
            else
            {
                if (page + 2 <= g)
                {
                    pages = new List<int>
                    {
                        page+1, page, page+2
                    };
                }
                else
                {
                    pages = new List<int>
                    {
                        page+1, page, 1
                    };
                }
                
            }
            return View(Tuple.Create(lb, lm, pages));
        }
        public IActionResult About()
        {
            List<int> f = new List<int>();
            DateTime date1 = DateTime.Parse("01.09.2019");
            DateTime date2 = DateTime.Parse("05.07.2022");
            
            int days1 = (date2 - DateTime.Now).Days;
            int days2 = (DateTime.Now - date1).Days;

            List<Project> lp = db.Projects.ToList();

            f = new List<int>{days1, days2, lp.Count};
            List<Member> lm = db.Members.ToList();
            Random rnd = new Random();
            lm = lm.GetRange(rnd.Next(lm.Count - 7), 6);
            
            List<StatusStudent> lss = db.StatusStudents.ToList();
            return View(Tuple.Create(f, lm, lss));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
