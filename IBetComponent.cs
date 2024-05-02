public interface IBetComponent
{
    void PlaceBet(User user, Bank bank);
}
public class ColorBet : IBetComponent
{
    public void PlaceBet(User user, Bank bank)
    {
        _childBets.Add(bet);
    }
}

public class NumberBet : IBetComponent
{
    public void PlaceBet(User user, Bank bank)
    {
        bet.PlaceBet(user, bank);
    }
}
public class CompositeBet : IBetComponent
{
    private List<IBetComponent> _childBets = new List<IBetComponent>();

    public void Add(IBetComponent bet)
    {
        _childBets.Add(bet);
    }

    public void PlaceBet(User user, Bank bank)
    {
        foreach (var bet in _childBets)
        {
            bet.PlaceBet(user, bank);
        }
    }
}