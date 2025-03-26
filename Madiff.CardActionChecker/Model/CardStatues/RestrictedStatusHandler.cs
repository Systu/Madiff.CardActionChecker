namespace Madiff.CardActionChecker.Model.CardStatues;

public class RestrictedStatusHandler : ICardStatusHandler
{
	public bool IsActionAllowed(Action action, CardDetails details) => action switch
	{
		Action.ACTION1 => false,
		Action.ACTION2 => false,
		Action.ACTION3 => true,
		Action.ACTION4 => true,
		Action.ACTION5 => true,
		Action.ACTION6 => false,
		Action.ACTION7 => false,
		Action.ACTION8 => false,
		Action.ACTION9 => true,
		Action.ACTION10 => false,
		Action.ACTION11 => false,
		Action.ACTION12 => false,
		Action.ACTION13 => false,
		_ => throw new NotImplementedException($"Not supported Action in {GetType().Name}")
	};
}
