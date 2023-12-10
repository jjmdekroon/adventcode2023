namespace AdventCode.Solvers.Q7
{
    public class Hand
    {
        private static int ConvertCard(char cardAsChar)
        {
            return cardAsChar switch
            {
                '2' => 1, '3' => 2, '4' => 3, '5' => 4, '6' => 5, '7' => 6, '8' => 7, '9' => 8,
                'T' => 9, 'J' => 10, 'Q' => 11, 'K' => 12, 'A' => 13,
                _ => 0
            };
        }

        public long HandValue { get; private set; }
        public HandResult Type { get; private set; }
        public int Bid { get; private set; }

        private string _inTheHand = string.Empty;

        public char[] InTheHand => _inTheHand.ToArray();

        public Hand(string inTheHand, int bid)
        {
            _inTheHand = inTheHand;

            Bid = bid;

            Type = HandResultCalculator.GetFiveOfAKind(_inTheHand.ToArray()) ??
                HandResultCalculator.GetFourOfAKind(_inTheHand.ToArray()) ??
                HandResultCalculator.GetFullHouse(_inTheHand.ToArray()) ??
                HandResultCalculator.GetThreeOfAKind(_inTheHand.ToArray()) ??
                HandResultCalculator.GetTwoPair(_inTheHand.ToArray()) ??
                HandResultCalculator.GetOnePair(_inTheHand.ToArray()) ??
                HandResultCalculator.GetHighCard(_inTheHand.ToArray()) ??
                HandResult.Nothing;

            HandValue = CalculateHandValue();
        }

        private long CalculateHandValue()
        {
            // 'T' => 'A', 'J' => 'B', 'Q' => 'C', 'K' => 'D', 'A' => 'E'
            var hexValue = new String(InTheHand);
            hexValue = hexValue
                .Replace('T', 'A')
                .Replace('J', 'B')
                .Replace('Q', 'C')
                .Replace('K', 'D')
                .Replace('A', 'E');

            var handValue = Convert.ToInt32(hexValue, 16);


            return handValue;
        }
    }
}