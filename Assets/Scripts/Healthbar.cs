using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
public class Healthbar : MonoBehaviour
{
    public Slider Slider;
    public Gradient gradient;
    public Image Fill;
    public void SetMaxhealth(int health)
    {
        Slider.maxValue = health;
        Slider.value=health;
        Fill.color= gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        Slider.value = health;
        Fill.color= gradient.Evaluate(Slider.normalizedValue);
    }

}
