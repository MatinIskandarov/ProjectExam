using Core.Entities;
using DataAccess.Abstract.Teams;
using DataAccess.Contexts;
using DataAccess.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Teams
{
    public class TeamRepo : ITeam
    {
        private readonly AppDbContext _context;

        public TeamRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Create(CreateModel model)
        {
            Team team = new Team()
            {
                Description = model.Description,
                Fullname = model.Fullname,
                Img = model.Image,
                Position = model.Position

            };
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var team = _context.Teams.FirstOrDefault(x=>x.Id==Id);
            _context.Remove(team);
            _context.SaveChanges();
        }

        public List<Team> GetListTeam()
        {
            return _context.Teams.ToList();
        }

        public Team GetTeamById(int Id)
        {
            return _context.Teams.FirstOrDefault(x => x.Id == Id);
        }

        public GetTeamsListModel GetTeams(int page)
        {
            var teams = _context.Teams.Skip((page - 1) * 10)
                .Take(10).ToList();

            var totalItemCount = _context.Teams.Count();

            int totalPageCount = 0;
            if (totalItemCount > 0)
                totalPageCount = Convert.ToInt32(Math.Ceiling((double)totalItemCount / 10));

            return new GetTeamsListModel
            {
                Teams = teams,
                activePage = page,
                totalItemCount = totalItemCount,
                totalPageCount = totalPageCount
            };
        }

        public void Update(UpdateModel updateModel, int Id)
        {
            var team = _context.Teams.FirstOrDefault(x => x.Id == Id);

            team.Description = updateModel.Description;
            team.Fullname = updateModel.Fullname;
            team.Img = updateModel.Image;
            team.Position = updateModel.Position;

            _context.Teams.Update(team);
            _context.SaveChanges();
        }
    }
}
