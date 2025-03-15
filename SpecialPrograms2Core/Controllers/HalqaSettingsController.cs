using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpecialPrograms2Core.Data;
using SpecialPrograms2Core.Models;
using SpecialPrograms2Core.Models;
using System.Threading.Tasks;

namespace SpecialPrograms2Core.Controllers
{
    public class HalqaSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HalqaSettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // عرض القيم في الصفحة الرئيسية
        public async Task<IActionResult> Index()
        {
            ViewBag.Programs = await _context.HalqaPrograms.ToListAsync();
            ViewBag.SessionTypes = await _context.SessionTypes.ToListAsync();
            ViewBag.SessionTimes = await _context.SessionTimes.ToListAsync();
            return View();
        }

        // إضافة برنامج جديد
        [HttpPost]
        public async Task<IActionResult> AddProgram(string programName)
        {
            if (!string.IsNullOrEmpty(programName))
            {
                var newProgram = new HalqaProgram { ProgramName = programName, IsActive = true };
                _context.HalqaPrograms.Add(newProgram);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // إضافة نوع جلسة جديد
        [HttpPost]
        public async Task<IActionResult> AddSessionType(string typeName)
        {
            if (!string.IsNullOrEmpty(typeName))
            {
                var newType = new SessionType { TypeName = typeName, IsActive = true };
                _context.SessionTypes.Add(newType);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // إضافة وقت جلسة جديد
        [HttpPost]
        public async Task<IActionResult> AddSessionTime(string timeName)
        {
            if (!string.IsNullOrEmpty(timeName))
            {
                var newTime = new SessionTime { TimeName = timeName, IsActive = true };
                _context.SessionTimes.Add(newTime);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // تعطيل أو استرجاع قيمة
        [HttpPost]
        public async Task<IActionResult> ToggleStatus(string type, int id)
        {
            if (type == "program")
            {
                var program = await _context.HalqaPrograms.FindAsync(id);
                if (program != null) program.IsActive = !program.IsActive;
            }
            else if (type == "sessionType")
            {
                var sessionType = await _context.SessionTypes.FindAsync(id);
                if (sessionType != null) sessionType.IsActive = !sessionType.IsActive;
            }
            else if (type == "sessionTime")
            {
                var sessionTime = await _context.SessionTimes.FindAsync(id);
                if (sessionTime != null) sessionTime.IsActive = !sessionTime.IsActive;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}