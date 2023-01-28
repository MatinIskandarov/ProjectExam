using DataAccess.Abstract.Teams;
using Microsoft.AspNetCore.Mvc;

namespace LumiaMVC.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private readonly ITeam _team;

        public TeamViewComponent(ITeam team)
        {
            _team = team;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _team.GetListTeam();
            return View(model);
        }

    }
}
