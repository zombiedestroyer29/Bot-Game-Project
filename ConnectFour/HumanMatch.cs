namespace ConnectFour
{
    internal class HumanMatch : Match
    {
        protected override void Player2Turn()
        {
            Console.WriteLine("Player 2, it is your turn to play.\nPlease pick which column to insert your piece into (1-7).\n");
            int column = -1;
            while (true)
            {
                try
                {
                    column = int.Parse(Console.ReadLine()) - 1;
                    if (!GameBoard.InsertSlot(column, SlotState.P2))
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
            P1sTurn = true;
        }
    }
}
