using Madiff.CardActionChecker.Application;
using Madiff.CardActionChecker.Model.CardStatues;
using Madiff.CardActionChecker.Model.CardTypes;
using Madiff.CardActionChecker.Model;
using Shouldly;

namespace Madiff.CardActionCheckerTests.Application;

public class CardFactoryTests
{
	[Theory]
	[InlineData(CardType.Prepaid, CardStatus.Ordered)]
	[InlineData(CardType.Prepaid, CardStatus.Inactive)]
	[InlineData(CardType.Prepaid, CardStatus.Active)]
	[InlineData(CardType.Prepaid, CardStatus.Restricted)]
	[InlineData(CardType.Prepaid, CardStatus.Blocked)]
	[InlineData(CardType.Prepaid, CardStatus.Expired)]
	[InlineData(CardType.Prepaid, CardStatus.Closed)]
	[InlineData(CardType.Credit, CardStatus.Ordered)]
	[InlineData(CardType.Credit, CardStatus.Inactive)]
	[InlineData(CardType.Credit, CardStatus.Active)]
	[InlineData(CardType.Credit, CardStatus.Restricted)]
	[InlineData(CardType.Credit, CardStatus.Blocked)]
	[InlineData(CardType.Credit, CardStatus.Expired)]
	[InlineData(CardType.Credit, CardStatus.Closed)]
	[InlineData(CardType.Debit, CardStatus.Ordered)]
	[InlineData(CardType.Debit, CardStatus.Inactive)]
	[InlineData(CardType.Debit, CardStatus.Active)]
	[InlineData(CardType.Debit, CardStatus.Restricted)]
	[InlineData(CardType.Debit, CardStatus.Blocked)]
	[InlineData(CardType.Debit, CardStatus.Expired)]
	[InlineData(CardType.Debit, CardStatus.Closed)]
	public void CreateCard_ShouldCreateCorrectCardTypeWithCorrectStatus(CardType cardType, CardStatus cardStatus)
	{
		// Arrange
		var cardDetails = new CardDetails("TestNumber", cardType, cardStatus, true);

		// Act
		var card = CardFactory.CreateCard(cardDetails);

		// Assert
		switch (cardType)
		{
			case CardType.Prepaid:
				card.ShouldBeOfType<PrepaidCard>();
				break;
			case CardType.Credit:
				card.ShouldBeOfType<CreditCard>();
				break;
			case CardType.Debit:
				card.ShouldBeOfType<DebitCard>();
				break;
		}


		var allowedActions = card.GetAllowedActions();
		allowedActions.ShouldNotBeNull();
	}

	[Fact]
	public void CreateCard_WithInvalidCardType_ShouldThrowArgumentException()
	{
		var cardType = (CardType)999;
		// Arrange
		var cardDetails = new CardDetails("TestNumber", cardType, CardStatus.Active, true);

		// Act & Assert
		Should.Throw<ArgumentException>(() => CardFactory.CreateCard(cardDetails))
			.Message.ShouldBe($"Unknown card type: {cardType}");
	}

	[Fact]
	public void CreateCard_WithInvalidCardStatus_ShouldThrowArgumentException()
	{
		var cardStatus = (CardStatus)999;
		// Arrange
		var cardDetails = new CardDetails("TestNumber", CardType.Prepaid, cardStatus, true);

		// Act & Assert
		Should.Throw<ArgumentException>(() => CardFactory.CreateCard(cardDetails))
			.Message.ShouldContain($"Unknown card status: {cardStatus}");
	}
}
