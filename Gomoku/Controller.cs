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
       
        private Random _rand = new Random();
        public Controller()
        {
        }

        public void Run()
        {
            // Create Players
            List<IPlayer> players = CreatePlayers();

            // Play Game
            PlayGame(players);
        }

        public List<IPlayer> CreatePlayers()
        {
            List<IPlayer> players = new List<IPlayer>();
            ConsoleIO.Display("Welcome to Gomoku");
            ConsoleIO.Display("=================");
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
            // CREATE BOARD
            char [,] board = new char [16,16];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i,j] = '_';
                }
            }
            // RANDOMLY CHOOSE FIRST PLAYER
            ConsoleIO.Warn("\n(Randomizing)\n");
            int firstTurn = _rand.Next(0, 2);

            // CREATE GAME
            GomokuEngine Game = new GomokuEngine(players[0], players[1]);
            bool draw = false;
            // GAME STARTS, LOOPS TILL END
            ConsoleIO.Display($"{Game.Current.Name} goes first.");
            while (!Game.IsOver)
            {
                ConsoleIO.Display($"\n\n{Game.Current.Name}'s Turn\n");

                Stone nextStone = GetNewStone(Game, board);
                Result res = Game.Place(nextStone);
                //if (!res.IsSuccess)
                //{
                //    ConsoleIO.Error(res.Message);

                //}
                //if (res.IsSuccess)
                //{
                //    ConsoleIO.Error(res.Message);
                //}

                board[nextStone.Row, nextStone.Column] = nextStone.IsBlack ? 'X' : 'O';
                ConsoleIO.PrintBoard(board);
            }

            // GAME OVER
            
            ConsoleIO.Warn($"\n\nGame over, the Winner is {Game.Winner.Name}");
            if (ConsoleIO.GetYesOrNo("Play Again [y/n]: "))
            {
                Run();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public Stone GetNewStone(GomokuEngine Game, char[,] board)
        {
            Stone nextStone;
            while (true)
            {
                nextStone = Game.Current.GenerateMove(Game.Stones);
                //new Stone(ConsoleIO.GetRow(), ConsoleIO.GetColumn(), Game.IsBlacksTurn);
                if (board[nextStone.Row, nextStone.Column] == 'X' | board[nextStone.Row, nextStone.Column] == 'O' )
                {
                    ConsoleIO.Error("\n[Error]: Duplicate move.\n");
                }
                else
                {
                    ConsoleIO.Error($"\n{Game.Current.Name} played a stone on ({nextStone.Row}, {nextStone.Column})\n");
                    return nextStone;
                }
            }
        }
        
        public IPlayer SetPlayerType(int playerNumber)
        {
            while (true)
            {
                switch (PlayerMenuSelect(playerNumber))
                {
                    case 1:
                        HumanPlayer human = new HumanPlayer(ConsoleIO.GetName(playerNumber));
                        return human;
                    case 2:
                        RandomPlayer random = new RandomPlayer();
                        return random;
                    default:
                        break;
                }
            }
        }
        private int PlayerMenuSelect(int playerNumber)
        {
            ConsoleIO.Display($"Player {playerNumber} is:\n" +
                "1. Human\n" +
                "2. Random Player\n");
            return ConsoleIO.GetInt("Select [1-2]");
        }
    }
}
