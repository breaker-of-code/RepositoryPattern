using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class TeamRepository : IRepository<Team>
    {
        private readonly List<Team> _teams = new List<Team>();

        public IEnumerable<Team> GetAll() => _teams;

        public Team GetById(int id) => _teams.FirstOrDefault(t => t.Id == id);

        public void Add(Team team) => _teams.Add(team);

        public void Update(Team team)
        {
            var existingTeam = GetById(team.Id);
            if (existingTeam != null)
            {
                existingTeam.Name = team.Name;
                existingTeam.Players = team.Players;
            }
        }

        public void Delete(int id)
        {
            var team = GetById(id);
            if (team != null)
            {
                _teams.Remove(team);
            }
        }
    }
}