using System.Collections;
using System.Collections.Generic;
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

    class Murloc : ICustomDeck
    {
		
		public Dictionary<string, ICardDefinition> MurlocMap = new Dictionary<string, ICardDefinition>()
		{
		{ "CS2_065", new CS2_065()},
		{ "CS2_122", new CS2_122()},
		{ "CS2_124", new CS2_124()},
		{ "CS2_168", new CS2_168()},
		{ "CS2_173", new CS2_173()},
		{ "CS2_213", new CS2_213()},
		{ "EX1_004", new EX1_004()},
		{ "EX1_029", new EX1_029()},
		{ "EX1_062", new EX1_062()},
		{ "EX1_103", new EX1_103()},
		{ "EX1_319", new EX1_319()},
		{ "EX1_506", new EX1_506()},
		{ "EX1_506a", new EX1_506a()},
		{ "EX1_507", new EX1_507()},
		{ "EX1_508", new EX1_508()},
		{ "EX1_509", new EX1_509()},
		{ "NEW1_017", new NEW1_017()},
		{ "NEW1_019", new NEW1_019()},
		{ "GAME_005", new GAME_005()}
		};
        private int _loopCount = 1;
		private int sure = 0;

        public IEnumerator SelectCard()
        {
            // Some verbose

			
            Logging.Write("------- Turn " + TritonHS.CurrentTurn + " Loop " + _loopCount + " -------");
            _loopCount++;

            // ----- First : drops
            // Try to play coin :
            yield return TryToPlayCoin();

            // Retrieve our cards in hand which can be used 
            // Can be used do a lot of check for us : enough mana, battlefield is not full to drop a minion, this spell can be used, etc...
            // Use this function to determine if a card can be played from you hand
             
				// Retrieve cards priority
				var lowPriority = new List<HSCard>();
				var normalPriority = new List<HSCard>();
				var highPriority = new List<HSCard>();
				var ultraPriority = new List<HSCard>();
				Logging.Write("Checking hand cards priorities :");
				
				foreach (HSCard card in TritonHS.GetCards(CardZone.Hand).Where(s =>
                s.CanBeUsed))
				{

					// Retrieve priority
					PlayPriority priority = MurlocMap[card.Id].GetPlayPriority();
					//Logging.Write("Card " + c.GetName() + " has priority " + priority);
					switch (priority)
					{
						case PlayPriority.VeryLow:
							//Logging.Write("\tCard " + c.GetName() + " has a very low priority");
							break;
						case PlayPriority.Low:
							lowPriority.Add(card);
							Logging.Write("\tCard " + card.Name + " has a low priority");
							break;
						case PlayPriority.Normal:
							normalPriority.Add(card);
							Logging.Write("\tCard " + card.Name + " has a normal priority");
							break;
						case PlayPriority.High:
							highPriority.Add(card);
							Logging.Write("\tCard " + card.Name + " has a high priority!");
							break;
						case PlayPriority.Ultra:
							ultraPriority.Add(card);
							Logging.Write("\tCard " + card.Name + " has an ULTRA priority!");
							break;
						default:
							//Dont play
							Logging.Write("\tCard " + card.Name + " must be ignored");
							break;
					}
				}

				if (ultraPriority.Count != 0)
				{
					
					 HSCard best = null;
   
					foreach (HSCard card in ultraPriority.Where(s => s.IsMinion))
					{
							if(best == null)
							best = card;
    
							if (card.Cost == TritonHS.CurrentMana && best.Cost != TritonHS.CurrentMana)
							best = card;

							// for minions priority is choosed with atk (in a first time)
							if (best.Attack < card.Attack)
							{
								best = card;
							}
					}
						Logging.Write("Lets play " + best.Name + " !");
										best.DoGrab();
										yield return Coroutine.Sleep(500);
										best.DoDrop();
										yield return Coroutine.Sleep(500);
   
						yield break;
					
				}
				else if (highPriority.Count != 0)
				{

					
					 HSCard best = null;
   
					foreach (HSCard card in highPriority.Where(s => s.IsMinion))
					{
							if(best == null)
							best = card;
    
							if (card.Cost == TritonHS.CurrentMana && best.Cost != TritonHS.CurrentMana)
							best = card;

							// for minions priority is choosed with atk (in a first time)
							if (best.Attack < card.Attack)
							{
								best = card;
							}
					}
						Logging.Write("Lets play " + best.Name + " !");
										best.DoGrab();
										yield return Coroutine.Sleep(500);
										best.DoDrop();
										yield return Coroutine.Sleep(500);
   
						yield break;
					
				}
				else if (normalPriority.Count != 0)
				{
					
					 HSCard best = null;
   
					foreach (HSCard card in normalPriority.Where(s => s.IsMinion))
					{
							if(best == null)
							best = card;
    
							if (card.Cost == TritonHS.CurrentMana && best.Cost != TritonHS.CurrentMana)
							best = card;

							// for minions priority is choosed with atk (in a first time)
							if (best.Attack < card.Attack)
							{
								best = card;
							}
					}
						Logging.Write("Lets play " + best.Name + " !");
										best.DoGrab();
										yield return Coroutine.Sleep(500);
										best.DoDrop();
										yield return Coroutine.Sleep(500);
   
						yield break;
					
				}
				else if (lowPriority.Count != 0 ) // Dont play low priority if coin if used [... =0 && !_coinPlayed
				{
					
					 HSCard best = null;
   
					foreach (HSCard card in lowPriority.Where(s => s.IsMinion))
					{
							if(best == null)
							best = card;
    
							if (card.Cost == TritonHS.CurrentMana && best.Cost != TritonHS.CurrentMana)
							best = card;

							// for minions priority is choosed with atk (in a first time)
							if (best.Attack < card.Attack)
							{
								best = card;
							}
					}
						Logging.Write("Lets play " + best.Name + " !");
										best.DoGrab();
										yield return Coroutine.Sleep(500);
										best.DoDrop();
										yield return Coroutine.Sleep(500);
   
						yield break;
				}
            

			
			// ----- Second : check hero power
            if (TritonHS.OurHeroPowerCard.CanBeUsed)
            {
                // We can use our hero power
                if (TritonHS.OurHero.Class == TAG_CLASS.WARLOCK && TritonHS.OurHeroHealthAndArmor < 10)
                    // Be careful with warlock power
                {
                    Logging.Write("We are a warlock and we are low life : ignore our hero power.");
                }
                else
                {
                    Logging.Write("Lets use our hero power.");

                    // Grab card : only a grab is needed for spells
                    TritonHS.OurHeroPowerCard.DoGrab();
                    yield return Coroutine.Sleep(1000); // Game need to load some stuff

                    // Is a target needed for hero power?
                    // Check if target retrieved is not null (maybe we did a misstake in our RetrieveTargetForHeroPower function)
                    if (TritonHS.IsInTargetMode() && RetrieveTargetForHeroPower() != null)
                    {
                        // So, find a target
                        TritonHS.OurHeroPowerCard.DoTarget(RetrieveTargetForHeroPower());
                        yield return Coroutine.Sleep(1000); // Game need to load some stuff
                    }
                    yield break;
                        // Get out of this loop => return at the start of the function => check if we can use new cards (maybe we have drawn a card?)
                }
            }

            // ------ Third : use our Hero 
            // Our hero can be used : our hero ATK is > 0 && we are not frozen
            // Dont focus taunters with our hero -> Focus enemy hero
            // Enemy hero can be attacked
            if (TritonHS.OurHero.CanBeUsed && !DoTheEnemyHasATaunter() &&
                TritonHS.EnemyHero.CanBeTargetedByOpponents)
            {
                TritonHS.OurHero.DoAttack(TritonHS.EnemyHero);
            }
			
            // ----- Fourth : attacks
			
			
            // Retrive cards on our battlefield which can be used
            // CanbeUsed function is checking if we can attack with this minion (it is not frozen, not exhausted, has atk > 0, etc...)
			 
			
            foreach (HSCard card in TritonHS.GetCards(CardZone.Battlefield).Where(s => s.CanBeUsed))
            {
			HSCard BestEnnemy = null;
				//Seek if a dangerous monster is on the field
			
				foreach (HSCard EnnemyCard in TritonHS.GetCards(CardZone.Battlefield, false).Where(s => s.CanBeAttacked))
				{
				double level = TradeHelper.DetermineMinionDangerousLevel(EnnemyCard);
				Logging.Write("Level of : " + EnnemyCard.Name + " -> " + level);
				
					if(DoTheEnemyHasATaunter())
					{
						if ( EnnemyCard.HasTaunt)
						{
							if(EnnemyCard.Health <= card.Attack) //Can we kill it ?
							{
							// Do our attack on enemy taunter
							BestEnnemy = EnnemyCard;
							Logging.Write("Kill the Taunter : " + card.Name + " -> " + EnnemyCard.Name);
                    
                        // Get out of this loop => return at the start of the function => check if we can use new cards (maybe we have drawn a card?)
							}else{
								BestEnnemy = null;
								}
						}
					}else{
				
						if(level <= 14)
						{
							if(EnnemyCard.Health <= card.Attack && card.Health > EnnemyCard.Attack)
								{
									Logging.Write("Best ennemy for : " + card.Name + " -> " + EnnemyCard.Name);
									BestEnnemy = EnnemyCard;									
									
								}
						}
						if(level > 14 && level < 20)
						{
							if(EnnemyCard.Health <= card.Attack)
								{
									Logging.Write("Best ennemy for : " + card.Name + " -> " + EnnemyCard.Name);
									BestEnnemy = EnnemyCard;						
									
								}
						}
						if(level >= 20)
						{
							if(EnnemyCard.Health /2 <= card.Attack )
								{
									Logging.Write("Best ennemy for : " + card.Name + " -> " + EnnemyCard.Name);
									BestEnnemy = EnnemyCard;								
									
								}
						}
				
									
					}
				
				}
			
				if(BestEnnemy != null){	
					card.DoAttack(BestEnnemy);
                    yield return Coroutine.Sleep(1000); // Little sleep after an attack	
								}else if (TritonHS.EnemyHero.CanBeTargetedByOpponents)
						{
							// Do our attack
							Logging.Write("Do attack : " + card.Name + " -> " + TritonHS.EnemyHero.Name);
							card.DoAttack(TritonHS.EnemyHero);
							yield return Coroutine.Sleep(1000); // Little sleep after an attack
							
								// Get out of this loop => return at the start of the function => check if we can use new cards (maybe we have drawn a card?)
						}
					yield break;
			
            }


            // ----- Finally : end our turn
            // If we reach this point : all our hand cards avaible are dropped & all our usable cards on battlefield are exhausted.

            // Ensure we are not in target mode (maybe we failed somewhere)
            // If game is still in target mode, endturn will fail
            if (TritonHS.IsInTargetMode())
            {
                TritonHS.CancelTargetingMode();
            }
			
			sure ++;
			if ( sure == 2)
			{
            // End our turn
            _loopCount = 1;
			sure = 0;
            Logging.Write("End turn.");
            TritonHS.EndTurn();
			}else
			{
			Logging.Write("Last check");
			yield break;
			}
        }

        /// <summary>
        ///     check if we have coin in hand, and play it if needed
        /// </summary>
        private IEnumerator TryToPlayCoin()
        {
            // Coin card ID
            const string coinId = "GAME_005";

            // Should we play coin?
            if (TritonHS.GetCards(CardZone.Hand).Any(s => s.Id == coinId) // Do we have coin in hand?
                &&
                !TritonHS.GetCards(CardZone.Hand)
                    .Any(s => s.CanBeUsed // Ensure we cant play cards with current mana avaible
                              &&
                              TritonHS.GetCards(CardZone.Hand)
                                  .Any(c => c.Cost == TritonHS.CurrentMana + 1 && c.IsMinion && !c.HasBattlecry)))
                // A card is awaible with currentmana + 1 (more checks are needed!!)
            {
                HSCard coin = TritonHS.GetCards(CardZone.Hand).FirstOrDefault(s => s.Id == coinId);
                if (coin != null)
                {
                    Logging.Write("Lets play coin!");
                    coin.DoGrab();
                    yield return Coroutine.Sleep(500);
                    coin.DoDrop();
                    yield return Coroutine.Sleep(500);
                }
            }
        }
		

		
		
        /// <summary>
        ///     Determine if enemy player has a taunter on the field
        /// </summary>
        /// <returns></returns>
        public static bool DoTheEnemyHasATaunter()
        {
            return TritonHS.GetCards(CardZone.Battlefield, false).Any(s => s.HasTaunt);
        }

        /// <summary>
        ///     Retrieve first enemy taunter card which can be attacked
        /// </summary>
        /// <returns></returns>
        public static HSCard RetrieveEnemyTaunter()
        {
            return
                TritonHS.GetCards(CardZone.Battlefield, false)
                    .FirstOrDefault(s => s.HasTaunt && s.CanBeTargetedByOpponents);
        }

        /// <summary>
        ///     Retrieve a target for hero power (depending on hero class)
        /// </summary>
        /// <returns>null if no target</returns>
        private HSCard RetrieveTargetForHeroPower()
        {
            switch (TritonHS.OurHero.Class)
            {
                // These 6 class dont need a target => return null
                case TAG_CLASS.DRUID:
                case TAG_CLASS.HUNTER:
                case TAG_CLASS.PALADIN:
                case TAG_CLASS.ROGUE:
                case TAG_CLASS.SHAMAN:
                case TAG_CLASS.WARRIOR:
                case TAG_CLASS.WARLOCK:
                    return null;
                case TAG_CLASS.MAGE:
                    // Target enemy hero
                    return TritonHS.EnemyHero;
                case TAG_CLASS.PRIEST:
                    // Target our hero
                    return TritonHS.OurHero;
                default:
                    return null;
            }
        }
		
    }
}