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
		public class CS2_124 : ICardDefinition
		{
			public string Id { get { return "CS2_124"; } }
			//Cardname : Wolfrider

			public PlayPriority GetPlayPriority()
			{
                return DropHelper.ShouldICharge(3);
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