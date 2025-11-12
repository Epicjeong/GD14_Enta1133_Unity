using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GD14_1133_DiceGame_Jeong_Yuri.Scripts
{
    /// <summary>
    /// The abstract item
    /// What all items are based on
    /// </summary>
    internal abstract class Item : MonoBehaviour
    {
        //What the item does
        internal abstract void ItemAction(Player player, System.Random random, DiceRolls diceroller, Map map);
    }
}
