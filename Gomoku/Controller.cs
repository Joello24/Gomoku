using Gomoku.Game;
using Gomoku.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    internal class Controller
    {
        public static ConsoleIO UI;
        private Random _rand = new Random();
        public Controller(ConsoleIO ui)
        {
            UI = ui;
        }

        public void Run()
        {
            // Create Game
            List<IPlayer> players = CreateGame();

            // Play Game
            PlayGame(players);
        }

        public List<IPlayer> CreateGame()
        {
            List<IPlayer> players = new List<IPlayer>();
            UI.Display("Welcome to Gomoku");
            UI.Display("=================");
            int p1 = 1;
            int p2 = 2;
            IPlayer player1 = SetPlayerType(p1);
            IPlayer player2 = SetPlayerType(p2);
            players.Add(player1);
            players.Add(player2);
            return players;
        }

        public void PlayGame(List<IPlayer> players)
        {
            char [,] board = new char [16,16];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i,j] = '_';
                }
            }
            UI.Warn("(Randomizing)");
            int firstTurn = _rand.Next(0, 2);
            GomokuEngine Game = new GomokuEngine(players[0], players[1]);
            bool isBlack = true;
            UI.Display($"{Game.Current.Name} goes first.");
            while (!Game.IsOver)
            {
                UI.Error($"\n{Game.Current.Name}'s Turn");
                Stone nextStone = new Stone(UI.GetRow(), UI.GetColumn(), isBlack);
                Game.Place(nextStone);
                board[nextStone.Row, nextStone.Column] = nextStone.IsBlack ? 'X' : 'O';
                UI.PrintBoard(board);
            }
        }
        
        public static IPlayer SetPlayerType(int playerNumber)
        {
            while (true)
            {
                switch (PlayerMenuSelect(playerNumber))
                {
                    case 1:
                        HumanPlayer human = new HumanPlayer(UI.GetName(playerNumber));
                        return human;
                    case 2:
                        RandomPlayer random = new RandomPlayer();
                        return random;
                    default:
                        break;
                }
            }
        }
        private static int PlayerMenuSelect(int playerNumber)
        {
            UI.Display($"Player {playerNumber} is:\n" +
                "1. Human\n" +
                "2. Random Player\n");
            return UI.GetInt("Select [1-2]: ");
        }
    }
}
