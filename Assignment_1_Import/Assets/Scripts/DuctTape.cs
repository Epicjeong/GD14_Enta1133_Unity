using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    internal class DuctTape : DuraItem
    {
        //Minimum and max durability that can be restored
        public DuctTape()
        {
            minDuraRestored = 4;
            maxDuraRestored = 12;
        }
        
        //What the item does
        internal override void ItemAction(Player player, System.Random random, DiceRolls diceroller, Map map)
        {
            //Gets a random amount of durability to restore
            duraRestored = random.Next(minDuraRestored, maxDuraRestored);
        }
    }
}
