using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.AdminWeb.Models;
using ZSZ.CommonMVC;
using ZSZ.IService;

namespace ZSZ.AdminWeb.Controllers
{
    public class PermissionController : Controller
    {

        public IPermissionService PermissionSerivce { get; set; }
        // GET: Permission
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var permissionList = PermissionSerivce.GetAllPermission();
            return View(permissionList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(PermissionAddViewModel viewModel)
        {
            PermissionSerivce.AddPermission(new DTO.PermissionDTO() { Name = viewModel.Name, Description = viewModel.Description });
            return Json(new AjaxResult<string> { Status = "ok" });
        }

        [HttpPost]
        public ActionResult Del(long id)
        {
            PermissionSerivce.DeletePermission(id);
            return Json(new AjaxResult<string> { Status = "ok" });
        }


        [HttpGet]
        public ActionResult Edit(long id)
        {
            var permissionDTO = PermissionSerivce.GetById(id);
            return View(permissionDTO);
        }

        [HttpPost]
        public ActionResult Edit(long id, string name, string description)
        {
            PermissionSerivce.Update(id, name, description);
            return Json(new AjaxResult<string> { Status = "ok" });

        }
        

    }
}