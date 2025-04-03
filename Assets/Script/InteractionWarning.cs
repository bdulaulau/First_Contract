using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InteractionWarning : MonoBehaviour
{
    public TextMeshProUGUI Interaction;


    private void Awake()
    {
        Interaction.gameObject.SetActive(false);
    }

    public void InteractionPopUp()
    {
        Interaction.gameObject.SetActive(true);
    }
}
