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
		public class NEW1_019 : ICardDefinition
		{
			public string Id { get { return "NEW1_019"; } }

		    //Cardname Knife Juggler

			public PlayPriority GetPlayPriority()
			{
                 //If we have some ressources & some minions avaible => highter priority
                 if(TritonHS.CurrentMana > 5 && DropHelper.HowManyCardInHandCanBeUsed() > 2)
                 {
                     return PlayPriority.High;
                 }
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