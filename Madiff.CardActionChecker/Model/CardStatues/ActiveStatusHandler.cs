namespace Madiff.CardActionChecker.Model.CardStatues;

public class ActiveStatusHandler : ICardStatusHandler
{
	public bool IsActionAllowed(Action action, CardDetails details) => action switch
	{
		Action.ACTION1 => true,
		Action.ACTION2 => false,
		Action.ACTION3 => true,
		Action.ACTION4 => true,
		Action.ACTION5 => true,
		Action.ACTION6 => details.IsPinSet,
		Action.ACTION7 => !details.IsPinSet,
		Action.ACTION8 => true,
		Action.ACTION9 => true,
		Action.ACTION10 => true,
		Action.ACTION11 => true,
		Action.ACTION12 => true,
		Action.ACTION13 => true,
		_ => throw new NotImplementedException($"Not supported Action in {GetType().Name}")
	};
}