using hTrixxPics.Models;
using System.Web.Mvc;
using System;
using System.IO;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace hTrixxPics.Controllers
{
    public class HomeController : Controller
    {
        hrtrixxpicsEntities context = new hrtrixxpicsEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetPictures()
        {
            try
            {
                var data = context.Pictures.Select(p => new
                {
                    id=p.Id,
                    title = p.Title,
                    userId = p.UserId,
                    description = p.Descriptinon,
                    fileLocation = p.FileLocation
                });
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        [HttpPost]
        public ActionResult AddImage(Pictures imgModel)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var usr = User.Identity.GetUserId();
                    string filename = Path.GetFileNameWithoutExtension(imgModel.ImageFile.FileName);
                    string extension = Path.GetExtension(imgModel.ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    imgModel.FileLocation = "/Images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                    imgModel.ImageFile.SaveAs(filename);
                    imgModel.Title = imgModel.Title;
                    imgModel.Descriptinon = imgModel.Descriptinon;
                    imgModel.UserId = usr;
                    context.Pictures.Add(imgModel);
                    context.SaveChanges();
                }
                return RedirectToAction("Upload", "Home");
            }
            catch(Exception ex)
            {
                throw;
            }
            
            
        }
        

    }
}