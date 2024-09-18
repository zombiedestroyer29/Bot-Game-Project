namespace ConnectFour
{
    internal abstract class Match
    {
        protected Board GameBoard = new Board();

        protected bool P1sTurn = true;

        protected virtual void Player1Turn()
        {
            Console.WriteLine("Player 1, it is your turn to play.\nPlease pick which column to insert your piece into (1-7).\n");
            int column = -1;
            while(true)
            {
                try
                {
                    column = int.Parse(Console.ReadLine()) - 1;
                    if (!GameBoard.InsertSlot(column, SlotState.P1))
                    {
                        Console.WriteLine("You cannot place a piece there! Please try again.\n");
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("You did not enter a valid value! Please try again.\n");
                }
            }
            P1sTurn = false;
        }

        protected virtual void Player2Turn()
        {
            throw new NotImplementedException();
        }

        internal void Play()
        {
            while (!GameBoard.AreFourConnected())
            {
                GameBoard.Display();
                if (P1sTurn)
                {
                    Player1Turn();
                }
                else
                {
                    Player2Turn();
                }
                Console.Clear();
            }
            GameBoard.Display();
            string winner = GameBoard.GetWinner() == SlotState.P1 ? "Player 1" : "Player 2";
            Console.WriteLine($"{winner} has won the game!");
        }
    }
}