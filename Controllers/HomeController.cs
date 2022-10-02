using hw5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Services;
using Intercom.Core;
using hw5.ViewModel;

namespace hw5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //instantiate class used
        private ServiceClass dataService = ServiceClass.getInstance();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

      


       
        //GET SEARCH FUNCTIONS
        [HttpGet]
        public IActionResult Index(int bookId)
        {
            List<IndexView> stuview = dataService.GetBooksDeets(bookId);
            return View();
        }
        [HttpPost]
        public IActionResult Index(string bname, string tname, string aname)
        {
            ViewData["BookN"] = bname;
            ViewData["TypeN"] = tname;
            ViewData["AuthorN"] = aname;
            try
            {
                if (bname!=null)
                {
                    //book search
                    var nameB = new List<Books>();
                    var namesB = from s in nameB
                                 where s.name.Contains(bname)
                                 select s;
                    foreach (var book in namesB)
                    {
                        return View(book.ToString());
                    }

                }
                else if (tname != null)
                {
                    //type search
                    var tameB = new List<Types>();
                    var tamesB = from t in tameB
                                 where t.name.Contains(tname)
                                 select t;
                    foreach (var type in tamesB)
                    {
                        return View(type.ToString());
                    }
                }
                else if (aname != null)
                {
                    //author search
                    var aameB = new List<Authors>();
                    var aamesB = from a in aameB
                                 where a.surname.Contains(aname)
                                 select a;
                    foreach (var author in aamesB)
                    {
                        return View(author.ToString());
                    }
                }
           

                return View("Index");
            }
            catch
            {
                return View();
            }

        }
        public String connectionString;
        public void setConnectionString(String someConnStr)
        {
            connectionString = someConnStr;
        }

        public static List<IndexView> bookList = new List<IndexView>();

        //alt search
        public ActionResult multi(int bookId)
        {
            try
            {  using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand multi;
                multi = new SqlCommand("select * from books,type,borrows,author join books on books.authorId=author.authorId join types on type.typeId=book.typeId ");


                SqlDataReader myReader = multi.ExecuteReader();
                bookList.Clear();
                while (myReader.Read())
                {
                    //INDEX MODEL
                    long id = Convert.ToInt64(myReader["bookId"]);
                    long authorId = Convert.ToInt64(myReader["authorId"]);
                    long typeId = Convert.ToInt64(myReader["typeId"]);

                    IndexView item = new IndexView
                    { //double check this, it feels like copy-pasting service class vm
                        //ID = id,
                        //Summary = getBooksById(bookId),
                        //Title = getAuthorById(authorId),
                        //Genre = getTypeById(typeId)
                    };

                }
            //  bookList.Add(item);
            //}
            //catch ()
            //{
            //}
            finally
            {
                //connection.Close();
            }
            return View("Index", bookList);
        }



        //status
        public IActionResult Index(string status)
        {
            try
            {
                ViewData["Status"] = status;

                if (status == null)
                {
                    //book search
                    var stat = new List<Borrows>();
                    //get broughtDate
                    if (stat.Count>0)
                    {
                        var statu = from p in stat
                                    where p.broughtDate.ToString() != null
                                    select p;
                        foreach(var statuss in statu)
                        {
                            var state = "Available";
                            return View(state.ToString());
                        }
                    }
                    else if (stat.Count > 0)
                    {
                        var statu = from p in stat
                                    where p.broughtDate.ToString() == null
                                    select p;
                        foreach (var statuss in statu)
                        {
                            var state = "Out";
                            return View(state.ToString());
                        }
                    }
                  
                }

                return View("Index");
            }
            catch
            {
                return View();
            }

        }




        public IActionResult BookDetails()
        {
            return View();
        }

        //get for list
        public ActionResult BookDetails(int borrowId, int bout)
        {
            List<BookView> bookview = dataService.getBorrowDeets(borrowId);

            //??count borrows?
              ViewData["NoOut"] = bout;
            try
            {if (bout==0)
                {
                    //book search
                    var countB = new List<Borrows>();
                    var namesC = from U in countB
                                 //if null must count==not returned
                                 where U.broughtDate.ToString() == null
                                 select U;
                    foreach (var counted in namesC)
                    {

                        return View(counted.ToString());
                    }

                }return View("BookDetails");
            }
            catch
            {
                return View(bookview);
            }
            
        }



        public IActionResult ViewStudents()
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
