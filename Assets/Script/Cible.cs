using UnityEngine;

public class Cible : MonoBehaviour
{
    public int currentValue = 0;
    public int[] codesValid = { 2, 5, 7, 9 };

    public GameObject On;
    public GameObject Off;

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

            bool isValid = false;
            foreach (int code in codesValid)  // On v�rifie si la nouvelle valeur fait partie des codes valides
            {
                if (currentValue == code)
                {
                    isValid = true;
                    break; //on casse la loop d�s que c'est bon
                }
            }

            if (On != null) On.SetActive(isValid);  // si l'objet "On" existe on l'active ou le désactive selon la validité
        }
        else
        {
            currentValue = 0;
            if (On != null) On.SetActive(false);
        }
    }
}
