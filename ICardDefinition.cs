using System.Collections;
using System.Linq;
using Triton.Bot;
using Triton.Common;
using Triton.Game;
using Triton.Game.Mapping;

// Class & struct by Shadosky
// Special thanks to Hankerspace
// Don't forget us in our CustomDeck's credit if u use code find here

namespace Shadosky.murloc
{

public enum PlayPriority
    {
        Ultra = 4,
        High = 3,
        Normal = 2,
        Low = 1,
        VeryLow = 0, // for hero powers only
        DontPlay = -1,
    }
	
public interface ICardDefinition
    {
        /// <summary>
        /// Gets the unique identifier for this card.
        /// </summary>
        string Id { get; }


        /// <summary>
        /// Delegate indicating whether we should or should not use the card right now.
        /// </summary>
        PlayPriority GetPlayPriority();

        /// <summary>
        /// Battlecry target selector delegate for this card.
        /// </summary>
        HSCard UseBattlecryOn(HSCard thisCard);

        /// <summary>
        /// Target selector delegate for this card.
        /// </summary>
        HSCard GetCardToUseOn(HSCard c);

    }
}