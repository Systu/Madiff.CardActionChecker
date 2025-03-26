using Madiff.CardActionChecker.Model.CardStatues;

namespace Madiff.CardActionChecker.Model.CardTypes;

public class CreditCard : Card
{
	public CreditCard(CardDetails details, ICardStatusHandler cardStatusHandler) : base(details, cardStatusHandler) { }
}