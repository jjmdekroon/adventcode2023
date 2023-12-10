namespace AdventCode.Solvers.Q7;

public static class HandResultCalculator
{
    public static HandResult? GetHighCard(Char[] set)
    {
        return set.Distinct().Count() == set.Length
            ? HandResult.HighCard
            : null;
    }

    private static List<char>? GetOnePairCards(Char[] set)
    {
        var step1 = set.Select(x => x).ToList() ?? [];
        var step2 = step1.GroupBy(x => x).ToList() ?? [];
        var step3 = step2.Where(x => x.Count() >= 2);
        var step4 = step3.GroupBy(x => x).ToList();
        var step5 = step4.Select(x => x.Key).ToArray();

        return step5.Select(x => x.Key).ToList();
    }

    public static HandResult? GetOnePair(Char[] set)
    {
        var step1 = set.Select(x => x).ToList() ?? [];
        var step2 = step1.GroupBy(x => x).ToList() ?? [];
        var step3 = step2.FirstOrDefault(x => x.Count() >= 2);

        var onePairs = GetOnePairCards(set) ?? [];

        return onePairs.Count() > 0 
            ? HandResult.OnePair 
            : null;
    }

    public static HandResult? GetTwoPair(Char[] set)
    {
        var step1 = set.Select(x => x).ToList() ?? [];
        var step2 = step1.GroupBy(x => x).ToList() ?? [];
        var step3 = step2.Where(x => x.Count() >= 2);
        var step4 = step3.GroupBy(x => x).ToList();

        return step4.Count() >= 2 
            ? HandResult.TwoPair 
            : null;
    }

    private static List<char> GetNOfAKindCard(Char[] set, int samesame)
    {
        var step1 = set.Select(x => x).ToList() ?? [];
        var step2 = step1.GroupBy(x => x).ToList() ?? [];
        var step3 = step2.Where(x => x.Count() >= samesame);
        var step4 = step3.GroupBy(x => x).ToList();
        var step5 = step4.Select(x => x.Key);

        return step5.Select(x => x.Key).ToList();
    }

    private static List<char> GetThreeOfAKindCard(Char[] set)
    {
        var step1 = set.Select(x => x).ToList() ?? [];
        var step2 = step1.GroupBy(x => x).ToList() ?? [];
        var step3 = step2.Where(x => x.Count() >= 3);        
        var step4 = step3.GroupBy(x => x).ToList();
        var step5 = step4.Select(x => x.Key);

        return step5.Select(x => x.Key).ToList();
    }

    public static HandResult? GetThreeOfAKind(Char[] set)
    {
        var threeOfAKindCards = GetNOfAKindCard(set, 3);

        return threeOfAKindCards.Count() > 0
            ? HandResult.ThreeOfAKind
            : null;
    }

    public static HandResult? GetFullHouse(Char[] set)
    {
        var threeOfAKindCards = GetThreeOfAKindCard(set);
        if (threeOfAKindCards.Count > 0)
        {
            var remainingCards = set.Except(threeOfAKindCards).ToArray();
            var remainingSet = set.Where(x => remainingCards.Any(y => y == x)).ToArray();
            var twoPairCards = GetOnePairCards(remainingSet) ?? [];

            return twoPairCards.Count > 0
                ? HandResult.FullHouse
                : null;
        }

        return null;
    }

    public static HandResult? GetFourOfAKind(Char[] set)
    {
        var sameCards = GetNOfAKindCard(set, 4);

        return sameCards.Count() > 0
            ? HandResult.FourOfAKind
            : null;
    }

    public static HandResult? GetFiveOfAKind(Char[] set)
    {
        var sameCards = GetNOfAKindCard(set, 5);

        return sameCards.Count() > 0
            ? HandResult.FiveOfAKind
            : null;
    }
}
