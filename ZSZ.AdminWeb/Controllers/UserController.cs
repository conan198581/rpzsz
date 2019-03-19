using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZSZ.AdminWeb.Models;
using ZSZ.DTO;
using ZSZ.IService;

namespace ZSZ.AdminWeb.Controllers
{
    public class UserController : Controller
    {
        public IAdminUserService AdminUserService { get; set; }
        public ICityService CityService { get; set; }
        public IRoleService RoleService { get; set; }
        
        // GET: User
        public ActionResult List()
        {
            var adminUsers = AdminUserService.GetAll();
            return View(adminUsers);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var cities = CityService.GetAll().ToList();
            var citydto = new CityDTO() { Id = 0, Name = "总部" };
            cities.Insert(0, citydto);
            var roles = RoleService.GetAll().ToList();
            UserAddViewModel viewModel = new UserAddViewModel() { CityDTOs = cities, RoleDTOs = roles };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(string PhoneNum,string Name,string Password,string Passwrod2,string Email,long cityId,long[] permissionIds)
        {
            return View();
        }
    }
}