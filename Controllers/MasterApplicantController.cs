using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspDotNetCore_MasterDetails.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace AspDotNetCore_MasterDetails.Controllers
{
    public class MasterApplicantController : Controller
    {
        private readonly AspDotNetCore_MasterDetailsContext _context;
        private readonly IWebHostEnvironment _webHost;

        public MasterApplicantController(AspDotNetCore_MasterDetailsContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            List<Applicant> applicants;
            applicants = _context.Applicant.ToList();
            return View(applicants);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();
            applicant.Experience.Add(new Experience() { ExperienceId = 1 });
            return View(applicant);
        }
        [HttpPost]
        public IActionResult Create(Applicant applicants)
        {
            string uniqueFileName = GetUploadedFileName(applicants);
            applicants.PhotoUrl = uniqueFileName;
            _context.Add(applicants);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        private string GetUploadedFileName(Applicant applicant)
        {
            string uniqueFileName = null;
            if (applicant.ProfilePhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + applicant.ProfilePhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    applicant.ProfilePhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Applicant applicant = _context.Applicant
         .Include(e => e.Experience)
         .FirstOrDefault(a => a.Id == id);

            return View(applicant);
        }
        private bool ApplicantsExists(int id)
        {
            return _context.Applicant.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (applicant.ProfilePhoto != null)
                    {
                        string uniqueFileName = GetUploadedFileName(applicant);
                        applicant.PhotoUrl = uniqueFileName;
                    }

                    _context.Update(applicant);

                    foreach (var experience in applicant.Experience)
                    {
                        _context.Update(experience);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantsExists(applicant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicant);
        }
        public IActionResult Details(int id)
        {
            Applicant applicant = _context.Applicant
                .Include(e => e.Experience)
                .Where(a => a.Id == id).FirstOrDefault();
            return View(applicant);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Applicant applicant = _context.Applicant
                .Include(e => e.Experience)
                .Where(a => a.Id == id).FirstOrDefault();
            return View(applicant);
        }
        [HttpPost]
        public IActionResult Delete(Applicant applicant)
        {
            _context.Attach(applicant);
            _context.Entry(applicant).State= EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}