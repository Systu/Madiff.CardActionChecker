using Madiff.CardActionChecker.Model.CardStatues;

namespace Madiff.CardActionChecker.Model.CardTypes;

public class DebitCard : Card
{
	public DebitCard(CardDetails details, ICardStatusHandler cardStatusHandler) : base(details, cardStatusHandler) { }
	protected override List<string> ModifyStatusAllowedActionsByCardKind(List<string> statusAllowedActions)
	{
		statusAllowedActions.Remove(Action.ACTION5.ToString());
		return statusAllowedActions;
	}
}
