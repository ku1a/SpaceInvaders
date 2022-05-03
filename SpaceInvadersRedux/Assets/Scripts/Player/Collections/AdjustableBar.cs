using UnityEngine;
using UnityEngine.UI;


public class AdjustableBar : MonoBehaviour
{
    public Slider slider;


    public void SetMax(int value)
    {
        slider.maxValue = value;
    }

    public void SetCurrent(int value)
    {
        slider.value = value;
    }
}
