using Core.Entities;
using DataAccess.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Teams
{
    public class GetTeamsListModel: PaginationModel
    {
        public List<Team> Teams { get; set; }
    }
}
