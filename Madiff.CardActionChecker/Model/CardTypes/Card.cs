using Madiff.CardActionChecker.Model.CardStatues;

namespace Madiff.CardActionChecker.Model.CardTypes;

public abstract class Card
{
	protected Card(CardDetails details, ICardStatusHandler cardStatusHandler)
	{
		_details = details;
		_cardStatusHandler = cardStatusHandler;
	}

	private CardDetails _details;
	private ICardStatusHandler _cardStatusHandler;

	public virtual List<string> GetAllowedActions()
	{
		// First get the actions allowed by status
		List<string> statusActions = GetStatusAllowedActions();

		// Then modify these actions based on card kind/type
		return ModifyStatusAllowedActionsByCardKind(statusActions);
	}

	protected List<string> GetStatusAllowedActions()
	{
		return _cardStatusHandler.GetAllowedActions(_details);
	}

	protected virtual List<string> ModifyStatusAllowedActionsByCardKind(List<string> statusAllowedActions)
	{

		return statusAllowedActions;
	}
}
