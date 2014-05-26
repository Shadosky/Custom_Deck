using System.Collections;
using System.Linq;
using Triton.Bot;
using Triton.Common;
using Triton.Game;
using Triton.Game.Mapping;

namespace Shadosky.murloc
{
		public class EX1_506 : ICardDefinition
		{
			public string Id { get { return "EX1_506"; } }
		    
		    //Cardname Murloc Tidehunter

			public PlayPriority GetPlayPriority()
			{
                return PlayPriority.Normal;
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