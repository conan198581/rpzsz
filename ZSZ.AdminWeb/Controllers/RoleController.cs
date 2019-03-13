using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.IService;

namespace ZSZ.AdminWeb.Controllers
{
    public class RoleController : Controller
    {
        public IRoleService RoleService { get; set; }
        public IPermissionService PermissionService { get; set; }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var datalist = RoleService.GetAll();
            return View(datalist);
        }


        [HttpGet]
        public ActionResult Add()
        {
            var permissionList = PermissionService.GetAllPermission();
            return View(permissionList);
        }
    }
}