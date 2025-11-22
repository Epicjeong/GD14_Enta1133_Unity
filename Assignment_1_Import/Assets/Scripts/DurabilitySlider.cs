using GD14_1133_DiceGame_Jeong_Yuri.Scripts;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using GD14_1133_DiceGame_Jeong_Yuri;

public class DurabilitySlider : MonoBehaviour
{
    //The slider that chooses the starting durability
    Slider slider;
    private int sliderValue;
    //public TextMeshProUGUI startingDura;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //slider = GetComponent<TextMeshPro>();
    }

    //Shows the player what durability they would start with
    public void SliderUpdate()
    {
        //startingDura = (int)slider.value;
    }

    //Sets the amount of durability the player starts with
    internal int SliderChange()
    {
        sliderValue = (int)slider.value;
        return sliderValue;
    }
}
