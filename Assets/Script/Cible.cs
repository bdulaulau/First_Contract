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


    void Update()
    {
        if (isValid == true)
        {
            AudioManager.instance.PlayClipAt(lightOn, transform.position);
        } 
    }
    public void TakeDamage(int amount)
    {
        if (currentValue < 9)
        {
            currentValue += 1;

            foreach (int code in codesValid)  // On v�rifie si la nouvelle valeur fait partie des codes valides
            {
                if (currentValue == code)
                {
                    isValid = true;
                    break; //on casse la loop d�s que c'est bon
                }
            }

            if (On != null)
            {
                On.SetActive(isValid);

            }// si l'objet "On" existe on l'active ou le désactive selon la validité
        }
        else
        {
            currentValue = 0;
            if (On != null) On.SetActive(false);
        }
    }
}
