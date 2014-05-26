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
		public class GAME_005 : ICardDefinition
		{
			public string Id { get { return "GAME_005"; } }

		    //Cardname The coin
           
            public PlayPriority GetPlayPriority()
            {              
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