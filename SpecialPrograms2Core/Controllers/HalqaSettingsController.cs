using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpecialPrograms2Core.Data;
using SpecialPrograms2Core.Models;
using System.Linq;
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

        // HalqaProgram Actions

        // GET: HalqaProgram
        public async Task<IActionResult> HalqaProgramIndex()
        {
            return View(await _context.HalqaPrograms.ToListAsync());
        }

        // GET: HalqaProgram/Create
        public IActionResult HalqaProgramCreate()
        {
            return View();
        }

        // POST: HalqaProgram/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HalqaProgramCreate([Bind("Id,Name,Description")] HalqaProgram halqaProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(halqaProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(HalqaProgramIndex));
            }
            return View(halqaProgram);
        }

        // GET: HalqaProgram/Edit/5
        public async Task<IActionResult> HalqaProgramEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var halqaProgram = await _context.HalqaPrograms.FindAsync(id);
            if (halqaProgram == null)
            {
                return NotFound();
            }
            return View(halqaProgram);
        }

        // POST: HalqaProgram/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HalqaProgramEdit(int id, [Bind("Id,Name,Description")] HalqaProgram halqaProgram)
        {
            if (id != halqaProgram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(halqaProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HalqaProgramExists(halqaProgram.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(HalqaProgramIndex));
            }
            return View(halqaProgram);
        }

        // GET: HalqaProgram/Delete/5
        public async Task<IActionResult> HalqaProgramDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var halqaProgram = await _context.HalqaPrograms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (halqaProgram == null)
            {
                return NotFound();
            }

            return View(halqaProgram);
        }

        // POST: HalqaProgram/Delete/5
        [HttpPost, ActionName("HalqaProgramDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HalqaProgramDeleteConfirmed(int id)
        {
            var halqaProgram = await _context.HalqaPrograms.FindAsync(id);
          if (!_context.SpecialHalqas.Any(h => h.ProgramId == id))
            {
                _context.HalqaPrograms.Remove(halqaProgram);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(HalqaProgramIndex));
        }

        private bool HalqaProgramExists(int id)
        {
            return _context.HalqaPrograms.Any(e => e.Id == id);
        }

        // SessionTime Actions

        // GET: SessionTime
        public async Task<IActionResult> SessionTimeIndex()
        {
            return View(await _context.SessionTimes.ToListAsync());
        }

        // GET: SessionTime/Create
        public IActionResult SessionTimeCreate()
        {
            return View();
        }

        // POST: SessionTime/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SessionTimeCreate([Bind("Id,Time")] SessionTime sessionTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessionTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SessionTimeIndex));
            }
            return View(sessionTime);
        }

        // GET: SessionTime/Edit/5
        public async Task<IActionResult> SessionTimeEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionTime = await _context.SessionTimes.FindAsync(id);
            if (sessionTime == null)
            {
                return NotFound();
            }
            return View(sessionTime);
        }

        // POST: SessionTime/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SessionTimeEdit(int id, [Bind("Id,Time")] SessionTime sessionTime)
        {
            if (id != sessionTime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessionTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionTimeExists(sessionTime.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SessionTimeIndex));
            }
            return View(sessionTime);
        }

        // GET: SessionTime/Delete/5
        public async Task<IActionResult> SessionTimeDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionTime = await _context.SessionTimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessionTime == null)
            {
                return NotFound();
            }

            return View(sessionTime);
        }

        // POST: SessionTime/Delete/5
        [HttpPost, ActionName("SessionTimeDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SessionTimeDeleteConfirmed(int id)
        {
            var sessionTime = await _context.SessionTimes.FindAsync(id);
            if (!_context.SpecialHalqas.Any(h => h.SessionTimeId == id))
            {
                _context.SessionTimes.Remove(sessionTime);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(SessionTimeIndex));
        }

        private bool SessionTimeExists(int id)
        {
            return _context.SessionTimes.Any(e => e.Id == id);
        }

        // SessionType Actions

        // GET: SessionType
        public async Task<IActionResult> SessionTypeIndex()
        {
            return View(await _context.SessionTypes.ToListAsync());
        }

        // GET: SessionType/Create
        public IActionResult SessionTypeCreate()
        {
            return View();
        }

        // POST: SessionType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SessionTypeCreate([Bind("Id,Name")] SessionType sessionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sessionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SessionTypeIndex));
            }
            return View(sessionType);
        }

        // GET: SessionType/Edit/5
        public async Task<IActionResult> SessionTypeEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionType = await _context.SessionTypes.FindAsync(id);
            if (sessionType == null)
            {
                return NotFound();
            }
            return View(sessionType);
        }

        // POST: SessionType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SessionTypeEdit(int id, [Bind("Id,Name")] SessionType sessionType)
        {
            if (id != sessionType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sessionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionTypeExists(sessionType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SessionTypeIndex));
            }
            return View(sessionType);
        }

        // GET: SessionType/Delete/5
        public async Task<IActionResult> SessionTypeDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sessionType = await _context.SessionTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sessionType == null)
            {
                return NotFound();
            }

            return View(sessionType);
        }

        // POST: SessionType/Delete/5
        [HttpPost, ActionName("SessionTypeDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SessionTypeDeleteConfirmed(int id)
        {
            var sessionType = await _context.SessionTypes.FindAsync(id);
            if (!_context.SpecialHalqas.Any(h => h.SessionTypeId == id))
            {
                _context.SessionTypes.Remove(sessionType);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(SessionTypeIndex));
        }

        private bool SessionTypeExists(int id)
        {
            return _context.SessionTypes.Any(e => e.Id == id);
        }
    }
}