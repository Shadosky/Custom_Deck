﻿using System.Collections;
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
		public class CS2_122 : ICardDefinition
		{
			public string Id { get { return "CS2_122"; } }
			//Cardname: Raid Leader

            public PlayPriority GetPlayPriority()
            {
				if(DropHelper.HowManyCardOnTheFieldCanAtk() > 3)
                   return PlayPriority.High;
                if(DropHelper.HowManyCardOnTheFieldCanAtk() > 1)
                   return PlayPriority.Normal;
                return PlayPriority.Low;
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