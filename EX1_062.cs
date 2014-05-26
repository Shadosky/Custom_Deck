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
		public class EX1_062 : ICardDefinition
		{
			public string Id { get { return "EX1_062"; } }
           
		    //Cardname Old Murk-Eye
			
			public PlayPriority GetPlayPriority()
			{
                int addAtk = DropHelper.HowManyMurlocOnTheField()+2;
                return DropHelper.ShouldICharge(addAtk);
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