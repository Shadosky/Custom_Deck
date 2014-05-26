using System.Collections;
using System.Linq;
using Triton.Bot;
using Triton.Common;
using Triton.Game;
using Triton.Game.Mapping;

namespace Shadosky.murloc
{
		public class CS2_213 : ICardDefinition
		{
			public string Id { get { return "CS2_213"; } }

		    //Cardname "Reckless Rocketeer"
			
			public PlayPriority GetPlayPriority()
			{
                return DropHelper.ShouldICharge(5);
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