using Gomoku.Game;

namespace Gomoku.Players
{
    public class HumanPlayer : IPlayer
    {
        public string Name { get; private set; }       
        
        public HumanPlayer(string name)
        {
            Name = name;
        }

        public Stone GenerateMove(Stone[] previousMoves)
        {
            bool isBlack = true;
            if (previousMoves != null && previousMoves.Length > 0)
            {
                Stone lastMove = previousMoves[previousMoves.Length - 1];
                isBlack = !lastMove.IsBlack;
            }

            int row = ConsoleIO.GetRow();
            int column = ConsoleIO.GetColumn();
            return new Stone(row, column, isBlack);
        }
    }
}
