using UnityEngine;

public class Cible : MonoBehaviour
{
    public int currentValue = 0;
    public int[] codesValid = { 2, 5, 7, 9 };

    public GameObject On;
    public GameObject Off;

    public AudioClip lightOn;
    private bool isValid = false;

    void Awake()
    {
        if (On != null) On.SetActive(false);
        if (Off != null) Off.SetActive(true);
    }

    public void TakeDamage(int amount)
    {
        if (currentValue < 9)
        {
            currentValue += 1;

            isValid = false;

            foreach (int code in codesValid)
            {
                if (currentValue == code)
                {
                    isValid = true;

                    AudioManager.instance.PlayClipAt(lightOn, transform.position);
                    break;
                }
            }

            if (On != null)
                On.SetActive(isValid);
        }
        else
        {
            currentValue = 0;
            isValid = false;

            if (On != null) On.SetActive(false);
        }
    }
}
