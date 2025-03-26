using Action = Madiff.CardActionChecker.Model.Action;
using Shouldly;
using Madiff.CardActionChecker.Model.CardTypes;
using Madiff.CardActionChecker.Model;
using Madiff.CardActionChecker.Model.CardStatues;
using Madiff.CardActionChecker.Application;

namespace Madiff.CardActionCheckerTests.Model;

public class CardTypeTest
{
	private CardDetails CreateDebetCard(CardType cardType, CardStatus status, bool isPinSet)
	{
		return new CardDetails("TestNumber", cardType, status, isPinSet);
	}

	public static IEnumerable<object[]> GetCreditCardTestData()
	{

		yield return new object[] { CardType.Credit, CardStatus.Ordered, new OrderedStatusHandler() };
		yield return new object[] { CardType.Credit, CardStatus.Inactive, new InactiveStatusHandler() };
		yield return new object[] { CardType.Credit, CardStatus.Active, new ActiveStatusHandler() };
		yield return new object[] { CardType.Credit, CardStatus.Restricted, new RestrictedStatusHandler() };
		yield return new object[] { CardType.Credit, CardStatus.Blocked, new BlockedStatusHandler() };
		yield return new object[] { CardType.Credit, CardStatus.Expired, new ExpiredStatusHandler() };
		yield return new object[] { CardType.Credit, CardStatus.Closed, new ClosedStatusHandler() };
	}

	public static IEnumerable<object[]> GeDebitCardTestData()
	{

		yield return new object[] { CardType.Debit, CardStatus.Ordered, new OrderedStatusHandler() };
		yield return new object[] { CardType.Debit, CardStatus.Inactive, new InactiveStatusHandler() };
		yield return new object[] { CardType.Debit, CardStatus.Active, new ActiveStatusHandler() };
		yield return new object[] { CardType.Debit, CardStatus.Restricted, new RestrictedStatusHandler() };
		yield return new object[] { CardType.Debit, CardStatus.Blocked, new BlockedStatusHandler() };
		yield return new object[] { CardType.Debit, CardStatus.Expired, new ExpiredStatusHandler() };
		yield return new object[] { CardType.Debit, CardStatus.Closed, new ClosedStatusHandler() };
	}

	public static IEnumerable<object[]> GePrepaidCardTestData()
	{
		// Return data as tuples: (CardType, CardStatus, CardStatusHandler)
		yield return new object[] { CardType.Prepaid, CardStatus.Ordered, new OrderedStatusHandler() };
		yield return new object[] { CardType.Prepaid, CardStatus.Inactive, new InactiveStatusHandler() };
		yield return new object[] { CardType.Prepaid, CardStatus.Active, new ActiveStatusHandler() };
		yield return new object[] { CardType.Prepaid, CardStatus.Restricted, new RestrictedStatusHandler() };
		yield return new object[] { CardType.Prepaid, CardStatus.Blocked, new BlockedStatusHandler() };
		yield return new object[] { CardType.Prepaid, CardStatus.Expired, new ExpiredStatusHandler() };
		yield return new object[] { CardType.Prepaid, CardStatus.Closed, new ClosedStatusHandler() };
	}


	[Theory]
	[MemberData(nameof(GetCreditCardTestData))]
	public void CreditCard_ShouldReturnUnchangedHandlerAction(CardType cardType, CardStatus status, ICardStatusHandler handler)
	{
		// Arrange
		CardDetails cardDetails = CreateDebetCard(cardType, status, true);
		var card = CardFactory.CreateCard(cardDetails);

		// Act
		var allowedActions = card.GetAllowedActions();
		var handlerAllowedActions = handler.GetAllowedActions(cardDetails);
		// Assert
		allowedActions.ShouldBe(handlerAllowedActions);
		handlerAllowedActions.ShouldBe(allowedActions);
	}


	[Theory]
	[MemberData(nameof(GeDebitCardTestData))]
	public void DebitCard_ShouldReturnHandlerAction_WithoutAction5(CardType cardType, CardStatus status, ICardStatusHandler handler)
	{
		// Arrange
		CardDetails cardDetails = CreateDebetCard(cardType, status, true);
		var card = CardFactory.CreateCard(cardDetails);

		// Act
		var allowedActions = card.GetAllowedActions();
		var handlerAllowedActions = handler.GetAllowedActions(cardDetails).ToList();
		handlerAllowedActions.Remove(Action.ACTION5.ToString());

		// Assert
		allowedActions.ShouldBe(handlerAllowedActions);
	}

	[Theory]
	[MemberData(nameof(GePrepaidCardTestData))]
	public void PrepaidCard_ShouldReturnHandlerAction_WithoutAction5(CardType cardType, CardStatus status, ICardStatusHandler handler)
	{
		// Arrange
		CardDetails cardDetails = CreateDebetCard(cardType, status, true);
		var card = CardFactory.CreateCard(cardDetails);

		// Act
		var allowedActions = card.GetAllowedActions();
		var handlerAllowedActions = handler.GetAllowedActions(cardDetails).ToList();
		handlerAllowedActions.Remove(Action.ACTION5.ToString());

		// Assert
		allowedActions.ShouldBe(handlerAllowedActions);
	}
}
