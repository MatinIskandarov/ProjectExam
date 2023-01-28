using DataAccess.Models.Teams;
using DataAccess.Abstract.Teams;
using DataAccess.Models.Teams;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;

namespace AdminPanel.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeam _team;
        private readonly IConfiguration _configuration;

        public TeamController(ITeam team, IConfiguration configuration)
        {
            _team = team;
            _configuration = configuration;
        }

        public IActionResult Index(int page)
        {
            if (page == 0)
            {
                page = 1;
            }

            var model = _team.GetTeams(page);

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AdminPanel.Models.Teams.CreateModel model)
        {
            if (ModelState.IsValid)
            {
                bool isUpload = false;
                string path = "";
                string savedName = "";
                if (model.Image.Length > 0)
                {
                    path = Path.GetFullPath(_configuration["ImageUploadDir"]);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    savedName = model.Image.Name + Guid.NewGuid().ToString().Substring(0, 8)+ Path.GetExtension(model.Image.FileName);
                    using (var fileStream = new FileStream(Path.Combine(path, savedName), FileMode.Create))
                    {
                        model.Image.CopyTo(fileStream);
                    }
                    isUpload = true;
                }
                if (isUpload)
                {
                    CreateModel createModel = new()
                    {
                        Description = model.Description,
                        Fullname = model.Fullname,
                        Image = savedName,
                        Position = model.Position
                    };
                    _team.Create(createModel);
                }
            }

            return RedirectToAction("Index", "Team");
        }
        [HttpGet]
        public IActionResult Detail(int Id)
        {
            var model = _team.GetTeamById(Id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        //update
        public IActionResult Detail(int Id, AdminPanel.Models.Teams.UpdateModel model, IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                bool isUpload = false;
                string path = "";
                string savedName = "";
                if (Img.Length > 0)
                {
                    path = Path.GetFullPath(_configuration["ImageUploadDir"]);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    savedName = Img.Name + Guid.NewGuid().ToString().Substring(0, 8) + Path.GetExtension(Img.FileName);
                    using (var fileStream = new FileStream(Path.Combine(path, savedName), FileMode.Create))
                    {
                        Img.CopyTo(fileStream);
                    }
                    isUpload = true;
                }
                if (isUpload)
                {
                    UpdateModel teamModel = new()
                    {
                        Description = model.Description,
                        Fullname = model.Fullname,
                        Image = savedName,
                        Position = model.Position
                    };
                    _team.Update(teamModel,Id);
                }
            }

            return RedirectToAction("Index", "Team");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var model = _team.GetTeamById(Id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            var model = _team.GetTeamById(Id);
            if (model == null)
            {
                return NotFound();
            }
            _team.Delete(Id);

            return RedirectToAction("Index", "Team");
        }
    }
}
