using System.Collections;
using System.Linq;
using Triton.Bot;
using Triton.Common;
using Triton.Game;
using Triton.Game.Mapping;

// Class & struct by Shadosky
// Special thanks to Hankerspace
// Don't forget us in our CustomDeck's credit if u use code find here

namespace Shadosky.Murloc.rush
{
		public class EX1_103 : ICardDefinition
		{
			public string Id { get { return "EX1_103"; } }
			
			// "Cardname": "Coldlight Seer",

			public PlayPriority GetPlayPriority()
			{
                if (DropHelper.HowManyMurlocOnTheField() > 4)
                    return PlayPriority.High;
                if (DropHelper.HowManyMurlocOnTheField() > 2)
                    return PlayPriority.Normal;
                if (DropHelper.HowManyMurlocOnTheField() > 0)
                    return PlayPriority.Low;
                return PlayPriority.DontPlay;

			}

			public HSCard GetCardToUseOn(HSCard thisCard)
			{
                 if (Murloc.DoTheEnemyHasATaunter())
                {
                    // Do our attack on enemy taunter
                   return Murloc.RetrieveEnemyTaunter();
                }

                // Enemy has NO taunter and we can target him => go for the face
                if (TritonHS.EnemyHero.CanBeTargetedByOpponents)
                {
                    // Do our attack
                    return TritonHS.EnemyHero;
                }
				
				return null;
			}

		    public HSCard UseBattlecryOn(HSCard thisCard)
			{
                return null;
			}
		}
	
}