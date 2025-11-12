using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// The subclass for utility items
    /// Shortened to Util for length
    /// Items that dont restore durability but still help the player
    /// </summary>
    internal class UtilItem : Item
    {
        //What the item does
        internal override void ItemAction(Player player, System.Random random, DiceRolls diceroller, Map map)
        {
            
        }
    }
}
