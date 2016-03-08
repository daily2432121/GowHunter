using System;
using System.Collections.Generic;
using System.Linq;
using GoWHunter.World.JSONModels;

namespace GoWHunter.World
{
    public class DropRateCalculator
    {
        
        public Dictionary<string, DropRateResultItem> Calculate(List<PChest> chests, WorldParser world, Localization.LocalizationParser dict)
        {
            Dictionary<string, DropRateResultItem> result = new Dictionary<string, DropRateResultItem>();
            foreach (var chest in chests)
            {
                var chestIndex = chests.IndexOf(chest);
                foreach (var reward in chest.Rewards)
                {
                    
                    var type = reward.Type;
                    if (type != "Rune" && type != "Troop")
                    {
                        DropRateResultItem item = new DropRateResultItem()
                        {
                            Category = type,
                            ChanceInAll = reward.Chance,
                            ChanceInSameCategory = 1,
                            Min = reward.Min,
                            Max = reward.Max,
                            ExpectationInAll = (reward.Max + reward.Min)/2.0*reward.Chance,
                            ExpectationInSameCategory = (reward.Max + reward.Min)/2.0,
                            ReferenceName = type,
                            Stars = 0
                        };
                        result.Add($"{chestIndex}|{type}|{item.ReferenceName}", item);
                        continue;
                    }
                    if (type == "Rune")
                    {
                        var rarity = reward.RarityChance;
                        foreach (var rune in reward.Included)
                        {
                            var runeInfo = dict.GetTune(rune);
                            var count = dict.GetRuneCountInSameRarity(runeInfo.Rarity, reward.Included);
                            
                            DropRateResultItem item = new DropRateResultItem()
                            {
                                Category = type,
                                ChanceInAll = reward.Chance * rarity[runeInfo.Rarity] / count,
                                ChanceInSameCategory = rarity[runeInfo.Rarity] / count,
                                ExpectationInAll = reward.Chance * rarity[runeInfo.Rarity] / count,
                                ExpectationInSameCategory = rarity[runeInfo.Rarity] / count,
                                ReferenceName = dict.GetTune(rune).Text,
                                Stars = 0
                            };
                            result.Add($"{chestIndex}|{type}|{item.ReferenceName}", item);
                        }
                    }
                    if (type == "Troop")
                    {
                        var rarity = reward.RarityChance;
                        foreach (var troop in reward.Included)
                        {
                            var troopInfo = world.TroopsDictById[troop];
                            var count = world.GetCountInSameRarity(troopInfo.TroopRarity, reward.Included);
                            var rarityInt = (int)Enum.Parse(typeof(TroopRarity), troopInfo.TroopRarity);
                            DropRateResultItem item = new DropRateResultItem()
                            {
                                Category = type,
                                ChanceInAll = reward.Chance * rarity[rarityInt] / count,
                                ChanceInSameCategory = rarity[rarityInt] / count,
                                ExpectationInAll = reward.Chance * rarity[rarityInt] / count,
                                ExpectationInSameCategory = rarity[rarityInt] / count,
                                ReferenceName = troopInfo.ReferenceName,
                                Stars = rarityInt
                            };
                            var key = $"{chestIndex}|{type}|{item.ReferenceName}";
                            if (result.ContainsKey(key))
                            {
                                var oldItem = result[key];
                                oldItem.ChanceInAll += item.ChanceInAll;
                                oldItem.ChanceInSameCategory += item.ChanceInSameCategory;
                                oldItem.ExpectationInAll += item.ExpectationInAll;
                                oldItem.ExpectationInSameCategory += item.ExpectationInSameCategory;
                            }
                            else
                            {
                                result.Add(key, item);
                            }
                        }
                    }
                }
            }
            return result;    
        }
    }
}