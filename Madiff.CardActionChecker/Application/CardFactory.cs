using Madiff.CardActionChecker.Model.CardStatues;
using Madiff.CardActionChecker.Model.CardTypes;
using Madiff.CardActionChecker.Model;

namespace Madiff.CardActionChecker.Application;

public static class CardFactory
{
	public static Card CreateCard(CardDetails details) => details.CardType switch
	{
		CardType.Prepaid => new PrepaidCard(details, GetStatusHandler(details.CardStatus)),
		CardType.Credit => new CreditCard(details, GetStatusHandler(details.CardStatus)),
		CardType.Debit => new DebitCard(details, GetStatusHandler(details.CardStatus)),
		_ => throw new ArgumentException($"Unknown card type: {details.CardType}")
	};

	private static ICardStatusHandler GetStatusHandler(CardStatus status) => status switch
	{
		CardStatus.Ordered => new OrderedStatusHandler(),
		CardStatus.Inactive => new InactiveStatusHandler(),
		CardStatus.Active => new ActiveStatusHandler(),
		CardStatus.Restricted => new RestrictedStatusHandler(),
		CardStatus.Blocked => new BlockedStatusHandler(),
		CardStatus.Expired => new ExpiredStatusHandler(),
		CardStatus.Closed => new ClosedStatusHandler(),
		_ => throw new ArgumentException($"Unknown card status: {status}")
	};
}
