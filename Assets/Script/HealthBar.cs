using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health) //quand le jeu démarre, le joueur aura 100% de ses pv
    {
        slider.maxValue= health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }



}
