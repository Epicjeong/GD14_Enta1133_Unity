using GD14_1133_DiceGame_Jeong_Yuri;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GainItems : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI itemDescription;
    //Pressing button gives player a random item
    public void GainItem(Player player)
    {
        player.GainItems(player);
        int itemGained = player.GetItemGained();
        switch (itemGained)
        {
            case 1:
                itemText.text = "You got Duct tape";
                return;
            case 2:
                itemText.text = "You got Weird Glue";
                return;
            case 3:
                itemText.text = "You got A gem";
                return;
            case 4:
                itemText.text = "You got Magnifying glass";
                return;
        }
    }
}
