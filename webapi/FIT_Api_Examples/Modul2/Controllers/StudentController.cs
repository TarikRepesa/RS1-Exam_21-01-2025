using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAll(int? filterDatumRodjenja, bool? prikaziSakrijObrisane)
        {
            KorisnickiNalog logiraniKorisnik = HttpContext.GetLoginInfo().korisnickiNalog;

            if (logiraniKorisnik != null)
            {
                //primjer kako preuzet informacije o logiranom korisniku
            }

            var data = _dbContext.Student
                .Include(s => s.opstina_rodjenja.drzava)
                .Where(x => filterDatumRodjenja == null || x.DatumRodjenja.Year >= filterDatumRodjenja && x.DatumRodjenja.Year <= filterDatumRodjenja + 1)
                .Where(x => prikaziSakrijObrisane == null || prikaziSakrijObrisane == true || prikaziSakrijObrisane == false && x.Obrisan == false)
                .OrderByDescending(s => s.id)
                .AsQueryable();
            return data.Take(100).ToList();
        }

    }
}


