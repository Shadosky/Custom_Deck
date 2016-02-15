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
		public class NEW1_017 : ICardDefinition
		{
			public string Id { get { return "NEW1_017"; } }

		    //Cardname Hungry Crab
           
            public PlayPriority GetPlayPriority()
            {
                // if (GameState.Get().GetRemotePlayer().GetBattlefieldZone().GetCards().Count(s => s.GetRace() == TAG_RACE.MURLOC) > 0)
                    // return PlayPriority.High;
                // if (GameState.Get().GetLocalPlayer().GetBattlefieldZone().GetCards().Count(s => s.GetRace() == TAG_RACE.MURLOC) > 0)
                    // return PlayPriority.Normal;
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
                // Card c = GameState.Get().GetRemotePlayer().GetBattlefieldZone().GetCards().FirstOrDefault(s => s.GetRace() == TAG_RACE.MURLOC);
                // if (c != null)
                    // return new HSCard(c);
                // return new HSCard(GameState.Get().GetLocalPlayer().GetBattlefieldZone().GetCards().FirstOrDefault(s => s.GetRace() == TAG_RACE.MURLOC));
				return null;
            }
		}
	
}