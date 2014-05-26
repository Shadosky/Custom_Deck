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
	public static class DropHelper
	{
		
		/// <summary>
        ///     Determine how many card we have on the field who can attack
        /// </summary>
        /// <returns>Number of cards we have who can attack</returns>
        public static int HowManyCardOnTheFieldCanAtk()
        {
            return TritonHS.GetCards(CardZone.Battlefield).Count(s => s.CanBeUsed);
        }
		
		/// <summary>
        ///     Determine how many card we have
        /// </summary>
        /// <returns>Number of cards we have</returns>
        public static int HowManyCardInHandCanBeUsed()
        {
            return TritonHS.GetCards(CardZone.Hand).Count(s => s.CanBeUsed);
        }
		
		/// <summary>
        ///     Determine how many card we have
        /// </summary>
        /// <returns>Number of cards we have</returns>
        public static int HowManyMurlocInHand()
        {
            return TritonHS.GetCards(CardZone.Hand).Count(s => s.Race == TAG_RACE.MURLOC);
        }
		
		/// <summary>
        ///     Determine how many murloc we have on the field 
        /// </summary>
        /// <returns>Number of murloc we have</returns>
        public static int HowManyMurlocOnTheField()
        {
            return TritonHS.GetCards(CardZone.Battlefield, true).Count(s => s.Race == TAG_RACE.MURLOC);
        }
		
		/// <summary>
        ///     Determine if we have a taunter on the field
        /// </summary>
        /// <returns></returns>
        public static bool DoIHaveTaunter()
        {
            return TritonHS.GetCards(CardZone.Battlefield, true).Any(s => s.HasTaunt);
        }
		
		/// <summary>
        ///     Determine if we should play a card with charge
        /// </summary>
        /// <returns>PlayPriority</returns>
        public static PlayPriority ShouldICharge(int attack)
        {
			if ( Murloc.DoTheEnemyHasATaunter())
				{
					HSCard Taunter = Murloc.RetrieveEnemyTaunter();
					if(Taunter != null && Taunter.Health <= attack)
						return PlayPriority.High;
					else
						return PlayPriority.Low;
				}else{
				
					if( TritonHS.EnemyHeroHealthAndArmor <= attack)
						return PlayPriority.Ultra;
					else
						return PlayPriority.Normal;

				}
        }
		
	}
	
}