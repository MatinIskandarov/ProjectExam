using Core.Entities;
using DataAccess.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Teams
{
    public interface ITeam
    {
        GetTeamsListModel GetTeams(int page);
        List<Team> GetListTeam();
        void Create(CreateModel model);
        Team GetTeamById(int Id);
        void Update(UpdateModel updateModel, int Id);
        void Delete(int Id);
    }
}
