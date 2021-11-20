using AutoMapper;
using Hotel_Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_5.BLL.DTO;
using Task_5.BLL.Interfaces;
using Task_5.DAL.Enteties;

namespace Hotel_PL.Controllers
{
    public class AccountController : Controller
    {

        IMapper mapper;
        IUserService userService;
        SignInManager<User> signInManager;
        UserManager<User> userManager;
        RoleManager<IdentityRole<Guid>> roleManager;

        public AccountController(IUserService userService, SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            mapper = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<RegisterViewModel, User>();
                    cfg.CreateMap<UserDTO, User>();
                }).CreateMapper();

            this.userService = userService;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost("Registration")]
        public async Task Register(RegisterViewModel regModel)
        {
            var user = mapper.Map<RegisterViewModel, User>(regModel);
            user.UserName = regModel.PhoneNumber;

            var result = await userManager.CreateAsync(user, regModel.Password);

            var UserRoles = from r in roleManager.Roles.ToList()
                            where r.Name == "Customer"
                            select r.Name;

            var result2 = await userManager.AddToRolesAsync(user, UserRoles);

            if (result.Succeeded && result2.Succeeded)
            {

            }
            else
            {
                throw new ArgumentException();
            }
        }


        [HttpPost("Login")]
        public async Task Login([FromBody] LoginViewModel loginModel)
        {

             var result = await signInManager.PasswordSignInAsync(loginModel.PhoneNumber, loginModel.Password, loginModel.RememberMe, false);

             if (result.Succeeded)
             {

             }
             else
             {
                  throw new ArgumentException();
             }
         
        }

        [HttpPost("AddRole")]
        public async Task AddRole(string name)
        {
            IdentityRole<Guid> role = new IdentityRole<Guid>(name);
            var result = await roleManager.CreateAsync(role);

            if (result.Succeeded)
            {

            }
            else
            {
                throw new ArgumentException();
            }
        }


        [HttpGet]
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

    }
}
