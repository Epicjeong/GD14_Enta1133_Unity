using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GD14_1133_DiceGame_Jeong_Yuri;

public class DurabilitySlider : MonoBehaviour
{
    //The slider that chooses the starting durability
    [SerializeField] private Slider slider;
    private int sliderValue;
    public TextMeshProUGUI startingDura;
    public TextMeshProUGUI displayDura;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    //Shows the player what durability they would start with
    public void SliderUpdate(Player player)
    {
        sliderValue = (int)slider.value;
        startingDura.text = sliderValue.ToString();
        displayDura.text = "Durability: " + sliderValue.ToString();
        player.playerSidesLeft = sliderValue;
    }
}
