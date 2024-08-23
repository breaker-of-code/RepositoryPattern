using System;
using System.Collections.Generic;

namespace Repository
{
    public class DataManager
    {
        private IRepository<Player> _playerRepository;
        private IRepository<Team> _teamRepository;

        private void Start()
        {
            _playerRepository = new PlayerRepository();
            _teamRepository = new TeamRepository();
            
            AddPlayers();
            AddPlayersToTeam(new List<Player>
                { _playerRepository.GetById(1), _playerRepository.GetById(2), _playerRepository.GetById(3) });
            
            UpdatePlayer(_playerRepository.GetById(1));
            DeletePlayer(3);
            ShowPlayersStats();
        }

        private void AddPlayers()
        {
            var player1 = new Player { Id = 1, Name = "Player1", Score = 100 };
            var player2 = new Player { Id = 2, Name = "Player2", Score = 150 };
            var player3 = new Player { Id = 3, Name = "Player3", Score = 90 };
            
            _playerRepository.Add(player1);
            _playerRepository.Add(player2);
            _playerRepository.Add(player3);
        }

        private void AddPlayersToTeam(List<Player> players)
        {
            var team = new Team { Id = 1, Name = "Team1" };

            foreach (var player in players)
            {
                team.Players.Add(player);
            }
            
            _teamRepository.Add(team);
        }

        private void ShowPlayersStats()
        {
            var players = _playerRepository.GetAll();
            foreach (var player in players)
            {
                Console.WriteLine($"Player: {player.Name}, Score: {player.Score}");
            }
        }

        private void UpdatePlayer(Player playerToUpdate)
        {
            if (playerToUpdate != null)
            {
                playerToUpdate.Score = 200;
                _playerRepository.Update(playerToUpdate);
            }
        }
        
        private void DeletePlayer(int id) => _playerRepository.Delete(id);
    }
}