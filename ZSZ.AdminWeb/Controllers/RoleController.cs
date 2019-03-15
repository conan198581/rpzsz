using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.AdminWeb.Models;
using ZSZ.CommonMVC;
using ZSZ.DTO;
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

        [HttpPost]
        public ActionResult Add(string name, long[] permissionIds)
        {
            //RoleService.add
            RoleService.Add(name, permissionIds);
            return Json(new AjaxResult<string> { Status = "ok" });
        }

        
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var roleObj = RoleService.GetById(id);
            var permissionList = PermissionService.GetPermissionByRoleId(id);
            var permissionAllList = PermissionService.GetAllPermission();
            PermissionRoleEditViewModel viewModel = new PermissionRoleEditViewModel();
            viewModel.RoleDTO = roleObj;
            viewModel.PermissionDTOs = permissionAllList;
            viewModel.SelectedPermissionDTOs = permissionList;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(RoleEditViewModel viewModel)
        {
            RoleDTO roleDTO = new RoleDTO() { Id = viewModel.Id, Name = viewModel.Name };
            RoleService.UpdateRole(roleDTO);
            PermissionService.UpdatePermissionsByRoleId(viewModel.Id, viewModel.PermissionIds);
            return Json(new AjaxResult<string> { Status = "ok" });
        }

        public ActionResult Del(long id)
        {
            RoleService.Del(id);
            return Json(new AjaxResult<string> { Status = "ok" });
        }
    }
}