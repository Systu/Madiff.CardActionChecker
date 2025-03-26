namespace Madiff.CardActionChecker.Model.CardStatues;

public interface ICardStatusHandler
{
	public List<string> GetAllowedActions(CardDetails details) =>
		[.. Enum.GetValues<Action>()
		.Where(action => IsActionAllowed(action, details))
		.Select(action => action.ToString())];
	bool IsActionAllowed(Action action, CardDetails details);
}
