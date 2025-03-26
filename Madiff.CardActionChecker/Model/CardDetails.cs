using Madiff.CardActionChecker.Model.CardStatues;
using Madiff.CardActionChecker.Model.CardTypes;

namespace Madiff.CardActionChecker.Model;

public record CardDetails(string CardNumber, CardType CardType, CardStatus CardStatus, bool IsPinSet);