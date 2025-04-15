using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushTheButton : MonoBehaviour
{
    // Déclaration d'un événement statique auquel d'autres objets peuvent s'abonner.
    // Il est déclenché lorsqu'un bouton est pressé et transmet une string (la valeur du bouton).
    public static event Action<string> ButtonPressed = delegate{};

    // Variables privées pour stocker la position du séparateur "_" dans le nom du bouton,
    // ainsi que le nom complet du bouton et sa valeur extraite.
    private int _deviderPosition;
    private string buttonName, buttonValue;


    void Start()
    {
        buttonName = gameObject.name; // Récupère le nom de l'objet bouton (par exemple "5_Button" ou "Start_Button")
        _deviderPosition = buttonName.IndexOf("_");// Cherche la position du séparateur "_" dans le nom du bouton
        buttonValue = buttonName.Substring(0, _deviderPosition);// Extrait la partie avant "_" pour récupérer la valeur à transmettre (ex : "5")

        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked); // Ajoute une méthode à appeler lors du clic sur le bouton
    }

    private void ButtonClicked()
    {
        ButtonPressed(buttonValue); // Déclenche l'événement en passant la valeur du bouton
    }

}
