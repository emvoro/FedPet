using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;
using FedPet.Objects;
using Microsoft.EntityFrameworkCore;
using FedPet.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Proxies;

namespace FedPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        DatabaseContext db;
        public OwnersController(DatabaseContext context)
        {
            db = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<OwnerObject>>> GetAll()
        {
            return await db.Owners.Select(x => new OwnerObject(x)).ToListAsync();
        }

        // GET api/owners/emvoro
        [HttpGet("GetUser/{login}")]
        public async Task<ActionResult<OwnerObject>> GetUser(string login)
        {
            List<Owner> owners = await db.Owners.ToListAsync();
            OwnerObject owner = owners.Select(x => new OwnerObject(x)).Where(x => x.Login == login).FirstOrDefault();
            if (owner == null)
                return NotFound();
            return new ObjectResult(owner);
        }

        //GET api/owners/getpets/emvoro
        [HttpGet("GetPets/{login}")]
        public async Task<ActionResult<PetObject>> GetPets(string login)
        {
            List<Owner> owners = await db.Owners.ToListAsync();
            Owner owner = owners.Where(x => x.Login == login).FirstOrDefault();
            List<Pet> pets = await db.Pets.ToListAsync();
            IEnumerable<PetObject> petObjects = pets.Select(x => new PetObject(x));
            
            if (petObjects == null)
                return NotFound();
            return new ObjectResult(petObjects.Where(x => x.Owner_Login == login).AsEnumerable());
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthenticationModel model)
        {
            if (ModelState.IsValid)
            {
                Owner owner = await db.Owners.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == GetHashString(model.Password));
                if (owner != null)
                {
                    await Authenticate(model.Login); // аутентификация
                    if (owner.Pets == null)
                    {
                        return RedirectToAction("AddPet", "Pets");
                    } 
                    else return RedirectToAction("GetPets", "Owners", new { owner.Login });
                }
                ModelState.AddModelError("", "Incorrect login and/or password!");
            }
            return RedirectToAction("Login", "Owners");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(AuthenticationModel model)
        {
            if (ModelState.IsValid)
            {
                Owner owner = await db.Owners.FirstOrDefaultAsync(u => u.Login == model.Login);
                if (owner == null)
                {
                    // добавляем пользователя в бд
                    db.Owners.Add(new Owner { Login = model.Login, Password = GetHashString(model.Password) });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Login); // аутентификация

                    return Ok(model);
                    //return RedirectToAction("Login", "Owners");
                }
                else
                ModelState.AddModelError("", "Incorrect login and/or password!");
            }
            return RedirectToAction("Register", "Owners");
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Owners");
        }

        // PUT api/owners/
        [HttpPut]
        public async Task<ActionResult<Owner>> Put(Owner owner)
        {
            if (owner == null)
            {
                return BadRequest();
            }
            if (!db.Owners.Any(x => x.Login == owner.Login))
            {
                return NotFound();
            }

            db.Update(owner);
            await db.SaveChangesAsync();
            return Ok(owner);
        }

        // DELETE api/users/kolyan
        [HttpDelete("{login}")]
        public async Task<ActionResult<Owner>> Delete(string login)
        {
            Owner owner = db.Owners.FirstOrDefault(x => x.Login == login);
            if (owner == null)
            {
                return NotFound();
            }
            db.Owners.Remove(owner);
            await db.SaveChangesAsync();
            return Ok(owner);
        }

        public string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}
