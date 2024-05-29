using PageDrift.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PageDrift.Controllers
{
    public class BooksController : Controller
    {
        #region Connection String
        BookStoreDBContext dc = new BookStoreDBContext();
        #endregion

        #region Display All Books
        public ViewResult DisplayBooks()
        {
            return View(dc.books);
        }
        #endregion

        #region Display Videos
        [Authorize]
        public ViewResult DisplayVideos()
        {
            return View(dc.books);
        }

        #endregion

        #region Display Mp3
        [Authorize]
        public ViewResult DisplayBhajan()
        {
            return View(dc.books);
        }
        #endregion

        #region Add Books
        [Authorize(Roles ="admin")]
       

        [HttpGet]
        public ViewResult AddBooks()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public RedirectToRouteResult AddBooks(Books books,HttpPostedFileBase Img,HttpPostedFileBase file)
        {
            try
            {
                if (Img != null)
                {
                    //Checking whether the folder "Uploads" is exists or not and creating it if not exists
                    string PhysicalPath = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(PhysicalPath))
                    {
                        Directory.CreateDirectory(PhysicalPath);
                    }
                    Img.SaveAs(PhysicalPath + Img.FileName);
                    books.Img = Img.FileName;
                }

                if (file != null)
                {
                    //Checking whether the folder "Uploads" is exists or not and creating it if not exists
                    string PhysicalPath = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(PhysicalPath))
                    {
                        Directory.CreateDirectory(PhysicalPath);
                    }
                    file.SaveAs(PhysicalPath + file.FileName);
                    books.File = file.FileName;
                }

                dc.books.Add(books);
                dc.SaveChanges();

                 return RedirectToAction("DisplayBooks");
            }
            catch
            {
                return RedirectToAction("DisplayBooks");
            }
        }
        #endregion

        #region Display Book
        [Authorize]
        public ViewResult DisplayBook(int id)
        {
            return View(dc.books.Find(id)); 
        }
        #endregion


        #region Read Book

        public ViewResult ReadBook(int id)
        {
            return View(dc.books.Find(id));
        }

        #endregion

        #region Edit 

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ViewResult Edit(int id)
        {
            return View(dc.books.Find(id));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public RedirectToRouteResult Edit(Books Book, HttpPostedFileBase Img, HttpPostedFileBase file)
        {
            var old = dc.books.Find(Book.BookId);

            if (Img != null)
            {
                //Checking whether the folder "Uploads" is exists or not and creating it if not exists
                string PhysicalPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(PhysicalPath))
                {
                    Directory.CreateDirectory(PhysicalPath);
                }
                Img.SaveAs(PhysicalPath + Img.FileName);
                Book.Img = Img.FileName;
                old.Img = Book.Img;
            }

            if (file != null)
            {
                //Checking whether the folder "Uploads" is exists or not and creating it if not exists
                string PhysicalPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(PhysicalPath))
                {
                    Directory.CreateDirectory(PhysicalPath);
                }
                file.SaveAs(PhysicalPath + file.FileName);
                Book.File = file.FileName;
                old.File=Book.File;
            }



            dc.Entry(old).State = EntityState.Modified;
            dc.SaveChanges();

            return RedirectToAction("DisplayBooks");
        }
        #endregion


        #region delete
        [Authorize(Roles = "admin")]
        public RedirectToRouteResult Delete(int id)
        {

            dc.books.Remove(dc.books.Find(id));

            dc.SaveChanges();
            return RedirectToAction("DisplayBooks");
        }


        #endregion

        #region admin access
        [Authorize(Roles ="admin")]
        public ViewResult Admin()
        {
            return View(dc.books);
        }
        #endregion


    }
}