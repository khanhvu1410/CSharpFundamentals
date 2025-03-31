using Microsoft.AspNetCore.Mvc;
using MvcAssignment.Data;
using MvcAssignment.Enums;
using OfficeOpenXml;

namespace MvcAssignment.Controllers
{
    public class RookiesController : Controller
    {
        private readonly IRookiesDbContext _context;

        public RookiesController(IRookiesDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rookies = _context.Persons;
            return View(rookies);
        }

        public IActionResult GetMaleRookies()
        {
            var rookies = _context.Persons.Where(p => p.Gender == Gender.Male).ToList();
            return View(rookies);
        }

        public IActionResult GetOldestRooky()
        {
            var oldestRooky = _context.Persons.OrderBy(x => x.DateOfBirth).FirstOrDefault();
            return View(oldestRooky);
        }

        public IActionResult GetFullNames()
        {
            var fullNames = _context.Persons.Select(p => $"{p.LastName} {p.FirstName}").ToList();
            return View(fullNames);
        }

        public IActionResult GetRookiesBirthYear2000(int birthYear)
        {
            var rookies = _context.Persons.Where(p => p.DateOfBirth.Year == birthYear).ToList();
            
            if (rookies.Count == 0)
            {
                return View("NotFound");
            }
            
            return View(rookies);
        }

        public IActionResult GetRookiesBirthYearGreater2000(int birthYear)
        {
            var rookies = _context.Persons.Where(p => p.DateOfBirth.Year > birthYear).ToList();

            if (rookies.Count == 0)
            {
                return View("NotFound");
            }

            return View(rookies);
        }

        public IActionResult GetRookiesBirthYearLess2000(int birthYear)
        {
            var rookies = _context.Persons.Where(p => p.DateOfBirth.Year < birthYear).ToList();

            if (rookies.Count == 0)
            {
                return View("NotFound");
            }

            return View(rookies);
        }

        public IActionResult GetRookiesExcelFile()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Khanh Vu");
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Rookies");
                worksheet.Cells[1, 1].Value = "First name";
                worksheet.Cells[1, 2].Value = "Last name";
                worksheet.Cells[1, 3].Value = "Gender";
                worksheet.Cells[1, 4].Value = "Date of birth";
                worksheet.Cells[1, 5].Value = "Phone number";
                worksheet.Cells[1, 6].Value = "Birth place";
                worksheet.Cells[1, 7].Value = "Is graduated";

                var rookies = _context.Persons;

                for (int i = 0; i < rookies.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = rookies[i].FirstName;
                    worksheet.Cells[i + 2, 2].Value = rookies[i].LastName;
                    worksheet.Cells[i + 2, 3].Value = rookies[i].Gender;
                    worksheet.Cells[i + 2, 4].Value = rookies[i].DateOfBirth.ToString("dd/MM/yyyy");
                    worksheet.Cells[i + 2, 5].Value = rookies[i].PhoneNumber;
                    worksheet.Cells[i + 2, 6].Value = rookies[i].BirthPlace;
                    worksheet.Cells[i + 2, 7].Value = rookies[i].IsGraduated;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Rookies.xlsx");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}