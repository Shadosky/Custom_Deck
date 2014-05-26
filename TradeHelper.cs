using System.Collections;
using System.Linq;
using Triton.Bot;
using Triton.Common;
using Triton.Game;
using Triton.Game.Mapping;

namespace Shadosky.murloc
{
	public static class TradeHelper
	{
	
	 public static string[] ImportantMinionsIds =
        {
            "EX1_350", //prophetvelen 
            "CS2_155", //archmageantonidas 
            "EX1_565", //flametonguetotem 
            "CS2_122", //raidleader 
            "EX1_508", //grimscaleoracle 
            "EX1_162", //direwolfalpha 
            "EX1_507", //murlocwarleader 
            "NEW1_027", //southseacaptain 
            "CS2_222", //stormwindchampion 
            "DS1_175", //timberwolf 
            "NEW1_033", //leokk 
            "CS2_235", //northshirecleric 
            "EX1_608", //sorcerersapprentice 
            "EX1_315", //summoningportal 
            "EX1_076", //pint-sizedsummoner 
            "EX1_531", //scavenginghyena
            "tt_004" //flesheatingghoul
        };

        public static double DetermineMinionDangerousLevel(HSCard c)
        {
            double level = 0;
            level += c.Health * 0.5;
            level += c.Attack * 1.5;
            if (c.HasTaunt) level += c.Health * 0.5;

            if (c.IsPoisonous) level += 4;
            if (c.IsEnraged) level += 5;

            if (c.HasWindfury) level += c.Attack * 1.5;
            if (c.HasDivineShield) level += 1;
            if(c.Attack >= TritonHS.OurHeroHealthAndArmor) level += 100;

            switch(c.Rarity)
            {
                case TAG_RARITY.LEGENDARY :
                    level += 5;
                    break;
                case TAG_RARITY.EPIC :
                    level += 3.5;
                    break;
                case TAG_RARITY.RARE :
                    level += 2;
                    break;
                case TAG_RARITY.COMMON:
                    level += 1;
                    break;
            }

            if (c.IsSilenced)
                level -= 3;
            if (c.IsFrozen)
                level -= 5; 
            if (c.HasDeathrattle)
                level -= 2;

            if (ImportantMinionsIds.Contains(c.Id))
                level += 8;

            return level;
        }
	
	
	
	}
}