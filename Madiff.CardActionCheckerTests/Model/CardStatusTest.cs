using Madiff.CardActionChecker.Model.CardStatues;
using Madiff.CardActionChecker.Model.CardTypes;
using Madiff.CardActionChecker.Model;
using Shouldly;
using Action = Madiff.CardActionChecker.Model.Action;

namespace Madiff.CardActionCheckerTests.Model;

public class CardStatusHandlerTests
{
	private CardDetails CreateCardDetails(bool isPinSet)
	{
		return new CardDetails("TestNumber", (CardType)999, (CardStatus)999, isPinSet);
	}

	[Fact]
	public void OrderedCardStatus_GetAllowedActions_WhenPinIsSet()
	{
		// Arrange
		ICardStatusHandler handler = new OrderedStatusHandler();
		var details = CreateCardDetails(true);

		// Act
		var allowedActions = handler.GetAllowedActions(details);

		// Assert
		allowedActions.ShouldContain(Action.ACTION3.ToString());
		allowedActions.ShouldContain(Action.ACTION4.ToString());
		allowedActions.ShouldContain(Action.ACTION5.ToString());
		allowedActions.ShouldContain(Action.ACTION6.ToString());
		allowedActions.ShouldContain(Action.ACTION8.ToString());
		allowedActions.ShouldContain(Action.ACTION9.ToString());
		allowedActions.ShouldContain(Action.ACTION10.ToString());
		allowedActions.ShouldContain(Action.ACTION12.ToString());
		allowedActions.ShouldContain(Action.ACTION13.ToString());
		allowedActions.Count.ShouldBe(9);
	}

	[Fact]
	public void OrderedCardStatus_GetAllowedActions_WhenPinIsNotSet()
	{
		// Arrange
		ICardStatusHandler handler = new OrderedStatusHandler();
		var details = CreateCardDetails(false);

		// Act
		var allowedActions = handler.GetAllowedActions(details);

		// Assert
		allowedActions.ShouldContain(Action.ACTION3.ToString());
		allowedActions.ShouldContain(Action.ACTION4.ToString());
		allowedActions.ShouldContain(Action.ACTION5.ToString());
		allowedActions.ShouldContain(Action.ACTION7.ToString());
		allowedActions.ShouldContain(Action.ACTION8.ToString());
		allowedActions.ShouldContain(Action.ACTION9.ToString());
		allowedActions.ShouldContain(Action.ACTION10.ToString());
		allowedActions.ShouldContain(Action.ACTION12.ToString());
		allowedActions.ShouldContain(Action.ACTION13.ToString());
		allowedActions.Count.ShouldBe(9);
	}

	[Fact]
	public void InactiveCardStatus_GetAllowedActions_WhenPinIsSet()
	{
		// Arrange
		ICardStatusHandler handler = new InactiveStatusHandler();
		var details = CreateCardDetails(true);

		// Act
		var allowedActions = handler.GetAllowedActions(details);

		// Assert
		allowedActions.ShouldContain(Action.ACTION2.ToString());
		allowedActions.ShouldContain(Action.ACTION3.ToString());
		allowedActions.ShouldContain(Action.ACTION4.ToString());
		allowedActions.ShouldContain(Action.ACTION5.ToString());
		allowedActions.ShouldContain(Action.ACTION6.ToString());
		allowedActions.ShouldContain(Action.ACTION8.ToString());
		allowedActions.ShouldContain(Action.ACTION9.ToString());
		allowedActions.ShouldContain(Action.ACTION10.ToString());
		allowedActions.ShouldContain(Action.ACTION11.ToString());
		allowedActions.ShouldContain(Action.ACTION12.ToString());
		allowedActions.ShouldContain(Action.ACTION13.ToString());
		allowedActions.Count.ShouldBe(11);
	}

	[Fact]
	public void InactiveCardStatus_GetAllowedActions_WhenPinIsNotSet()
	{
		// Arrange
		ICardStatusHandler handler = new InactiveStatusHandler();
		var details = CreateCardDetails(false);

		// Act
		var allowedActions = handler.GetAllowedActions(details);

		// Assert
		allowedActions.ShouldContain(Action.ACTION2.ToString());
		allowedActions.ShouldContain(Action.ACTION3.ToString());
		allowedActions.ShouldContain(Action.ACTION4.ToString());
		allowedActions.ShouldContain(Action.ACTION5.ToString());
		allowedActions.ShouldContain(Action.ACTION7.ToString());
		allowedActions.ShouldContain(Action.ACTION8.ToString());
		allowedActions.ShouldContain(Action.ACTION9.ToString());
		allowedActions.ShouldContain(Action.ACTION10.ToString());
		allowedActions.ShouldContain(Action.ACTION11.ToString());
		allowedActions.ShouldContain(Action.ACTION12.ToString());
		allowedActions.ShouldContain(Action.ACTION13.ToString());
		allowedActions.Count.ShouldBe(11);
	}

	[Fact]
	public void ActiveCardStatus_GetAllowedActions_WhenPinIsSet()
	{
		// Arrange
		ICardStatusHandler handler = new ActiveStatusHandler();
		var details = CreateCardDetails(true);

		// Act
		var allowedActions = handler.GetAllowedActions(details);

		// Assert
		allowedActions.ShouldContain(Action.ACTION1.ToString());
		allowedActions.ShouldContain(Action.ACTION3.ToString());
		allowedActions.ShouldContain(Action.ACTION4.ToString());
		allowedActions.ShouldContain(Action.ACTION5.ToString());
		allowedActions.ShouldContain(Action.ACTION6.ToString());
		allowedActions.ShouldContain(Action.ACTION8.ToString());
		allowedActions.ShouldContain(Action.ACTION9.ToString());
		allowedActions.ShouldContain(Action.ACTION10.ToString());
		allowedActions.ShouldContain(Action.ACTION11.ToString());
		allowedActions.ShouldContain(Action.ACTION12.ToString());
		allowedActions.ShouldContain(Action.ACTION13.ToString());
		allowedActions.Count.ShouldBe(11);
	}

	[Fact]
	public void ActiveCardStatus_GetAllowedActions_WhenPinIsNotSet()
	{
		// Arrange
		ICardStatusHandler handler = new ActiveStatusHandler();
		var details = CreateCardDetails(false);

		// Act
		var allowedActions = handler.GetAllowedActions(details);

		// Assert
		allowedActions.ShouldContain(Action.ACTION1.ToString());
		allowedActions.ShouldContain(Action.ACTION3.ToString());
		allowedActions.ShouldContain(Action.ACTION4.ToString());
		allowedActions.ShouldContain(Action.ACTION5.ToString());
		allowedActions.ShouldContain(Action.ACTION7.ToString());
		allowedActions.ShouldContain(Action.ACTION8.ToString());
		allowedActions.ShouldContain(Action.ACTION9.ToString());
		allowedActions.ShouldContain(Action.ACTION10.ToString());
		allowedActions.ShouldContain(Action.ACTION11.ToString());
		allowedActions.ShouldContain(Action.ACTION12.ToString());
		allowedActions.ShouldContain(Action.ACTION13.ToString());
		allowedActions.Count.ShouldBe(11);
	}

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void RestrictedCardStatus_GetAllowedActions_NotDependsOfPinSet(bool isPinSet)
	{
		// Arrange
		ICardStatusHandler handler = new RestrictedStatusHandler();
		var details = CreateCardDetails(isPinSet);

		// Act
		var allowedActions = handler.GetAllowedActions(details);

		// Assert
		allowedActions.ShouldContain(Action.ACTION3.ToString());
		allowedActions.ShouldContain(Action.ACTION4.ToString());
		allowedActions.ShouldContain(Action.ACTION5.ToString());
		allowedActions.ShouldContain(Action.ACTION9.ToString());
		allowedActions.Count.ShouldBe(4);
	}

	[Fact]
	public void BlockedCardStatus_GetAllowedActions_WhenPinIsSet()
	{
		// Arrange
		ICardStatusHandler handler = new BlockedStatusHandler();
		var details = CreateCardDetails(true);

		// Act
		var allowedActions = handler.GetAllowedActions(details);

		// Assert
		allowedActions.ShouldContain(Action.ACTION3.ToString());
		allowedActions.ShouldContain(Action.ACTION4.ToString());
		allowedActions.ShouldContain(Action.ACTION5.ToString());
		allowedActions.ShouldContain(Action.ACTION6.ToString());
		allowedActions.ShouldContain(Action.ACTION7.ToString());
		allowedActions.ShouldContain(Action.ACTION8.ToString());
		allowedActions.ShouldContain(Action.ACTION9.ToString());
		allowedActions.Count.ShouldBe(7);
	}

	[Fact]
	public void BlockedCardStatus_GetAllowedActions_WhenPinIsNotSet()
	{
		// Arrange
		ICardStatusHandler handler = new BlockedStatusHandler();
		var details = CreateCardDetails(false);

		// Act
		var allowedActions = handler.GetAllowedActions(details);

		// Assert
		allowedActions.ShouldContain(Action.ACTION3.ToString());
		allowedActions.ShouldContain(Action.ACTION4.ToString());
		allowedActions.ShouldContain(Action.ACTION5.ToString());
		allowedActions.ShouldContain(Action.ACTION8.ToString());
		allowedActions.ShouldContain(Action.ACTION9.ToString());
		allowedActions.Count.ShouldBe(5);
	}


	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void ExpiredCardStatus_GetAllowedActions_NotDependsOfPin(bool isPinSet)
	{
		// Arrange
		ICardStatusHandler handler = new ExpiredStatusHandler();
		var details = CreateCardDetails(isPinSet);

		// Act
		var allowedActions = handler.GetAllowedActions(details);

		// Assert
		allowedActions.ShouldContain(Action.ACTION3.ToString());
		allowedActions.ShouldContain(Action.ACTION4.ToString());
		allowedActions.ShouldContain(Action.ACTION5.ToString());
		allowedActions.ShouldContain(Action.ACTION9.ToString());
		allowedActions.Count.ShouldBe(4);
	}

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public void ClosedCardStatus_GetAllowedActions_NotDependsOfPin(bool isPinSet)
	{
		// Arrange
		ICardStatusHandler handler = new ClosedStatusHandler();
		var details = CreateCardDetails(isPinSet);

		// Act
		var allowedActions = handler.GetAllowedActions(details);

		// Assert
		allowedActions.ShouldContain(Action.ACTION3.ToString());
		allowedActions.ShouldContain(Action.ACTION4.ToString());
		allowedActions.ShouldContain(Action.ACTION5.ToString());
		allowedActions.ShouldContain(Action.ACTION9.ToString());
		allowedActions.Count.ShouldBe(4);
	}


}
