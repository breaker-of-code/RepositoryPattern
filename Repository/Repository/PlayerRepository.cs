using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly List<Player> _players = new List<Player>();

        public IEnumerable<Player> GetAll() => _players;

        public Player GetById(int id) => _players.FirstOrDefault(p => p.Id == id);

        public void Add(Player player) => _players.Add(player);

        public void Update(Player player)
        {
            var existingPlayer = GetById(player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.Name = player.Name;
                existingPlayer.Score = player.Score;
            }
        }

        public void Delete(int id)
        {
            var player = GetById(id);
            if (player != null)
            {
                _players.Remove(player);
            }
        }
    }
}