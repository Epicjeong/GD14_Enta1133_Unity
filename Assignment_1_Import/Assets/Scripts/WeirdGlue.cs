using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    internal class WeirdGlue : DuraItem
    {
        //Minimum and max durability that can be restored
        public WeirdGlue()
        {
            minDuraRestored = 1;
            maxDuraRestored = 20;
        }

        //What the item does
        internal override void ItemAction(Player player, System.Random random, DiceRolls diceroller, Map map)
        { 
            //Gets a random amount of durability to restore
            duraRestored = random.Next(minDuraRestored, maxDuraRestored);
        }
    }
}
