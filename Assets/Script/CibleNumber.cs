using UnityEngine;
using TMPro;

public class CibleNumber : MonoBehaviour
{
    public TMP_Text Number;
    public Cible cible;

    private void Update()
    {
        if (cible != null && Number != null)
        {
            Number.text = cible.currentValue.ToString();
        }
    }
}
