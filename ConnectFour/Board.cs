namespace ConnectFour
{
    internal enum SlotState
    { 
        EMPTY = 0,
        P1 = 1,
        P2 = 2
    }

    internal class Board
    {
        SlotState[][] Slots;

        SlotState Winner;

        internal Board()
        {
            List<SlotState[]> slots = new List<SlotState[]>();
            for (int i = 0; i < 7; i++)
            {
                slots.Add(new SlotState[] { SlotState.EMPTY, SlotState.EMPTY, SlotState.EMPTY, SlotState.EMPTY, SlotState.EMPTY, SlotState.EMPTY });
            }
            Slots = slots.ToArray();
            Winner = SlotState.EMPTY;
        }

        internal void Display()
        {
            Console.WriteLine("\nCurrent Board:");
            Console.WriteLine("1 2 3 4 5 6 7");
            for (int r = 0; r < Slots[0].Length; r++)
            {
                for (int c = 0; c < Slots.Length; c++)
                {
                    char marker = '-';
                    switch (Slots[c][r])
                    {
                        case SlotState.P1:
                            marker = 'X';
                            break;

                        case SlotState.P2:
                            marker = 'O';
                            break;
                    }
                    Console.Write($"{marker} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal bool InsertSlot(int column, SlotState state)
        {
            if (state == SlotState.EMPTY || column < 0 || column >= Slots.Length || Slots[column].All(slot => slot == SlotState.P1) || Slots[column].All(slot => slot == SlotState.P2))
            {
                return false;
            }

            int row = 0;
            while (row < 6 && Slots[column][row] == 0)
            {
                row++;
            }
            row--;

            Slots[column][row] = state;

            return true;
        }

        internal bool AreFourConnected()
        {
            for (int column = 0; column < Slots.Length; column++)
            {
                for (int row = 0; row < Slots[column].Length; row++)
                {
                    if (Slots[column][row] != 0)
                    {
                        SlotState match = Slots[column][row];
                        if (column < 4) //Check right
                        {
                            bool isConnected = true;
                            for (int right = 1; right < 4; right++)
                            {
                                if (Slots[column + right][row] != match)
                                {
                                    isConnected = false;
                                }
                            }
                            if (isConnected)
                            {
                                Winner = match;
                                return true;
                            }
                        }
                        if (row < 3) //Check bottom
                        {
                            bool isConnected = true;
                            for (int below = 1; below < 4; below++)
                            {
                                if (Slots[column][row + below] != match)
                                {
                                    isConnected = false;
                                }
                            }
                            if (isConnected)
                            {
                                Winner = match;
                                return true;
                            }
                        }
                        if (column < 4 && row < 3) //Check bottom right
                        {
                            bool isConnected = true;
                            for (int br = 1; br < 4; br++)
                            {
                                if (Slots[column + br][row + br] != match)
                                {
                                    isConnected = false;
                                }
                            }
                            if (isConnected)
                            {
                                Winner = match;
                                return true;
                            }
                        }
                        if (column > 2 && row < 3) //Check bottom left
                        {
                            bool isConnected = true;
                            for (int bl = 1; bl < 4; bl ++)
                            {
                                if (Slots[column - bl][row + bl] != match)
                                {
                                    isConnected = false;
                                }
                            }
                            if (isConnected)
                            {
                                Winner = match;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        internal SlotState GetWinner()
        {
            return Winner;
        }
    }
}
