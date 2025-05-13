using System;
using UnityEngine;
using UnityEngine.UI;

public class DigitalDisplay : MonoBehaviour
{
    [SerializeField] private Sprite[] digits;
    [SerializeField] private Image[] characters;
    [SerializeField] private KeypadManager keypad;

    //public event Action<KeypadManager> OnCodeCorrect;

    public Door door;
    public bool Open = false;

    private string codeSequence = "";

    void Start()
    {
        ResetDisplay();
        PushTheButton.ButtonPressed += AddDigitToCodeSequence;
    }

    public void SetKeypad(KeypadManager manager)
    {
        keypad = manager;
    }

    private void AddDigitToCodeSequence(string digitEntered)
    {
        if (digitEntered == "Star")
        {
            ResetDisplay();
            return;
        }

        if (digitEntered == "Hash")
        {
            if (codeSequence.Length > 0)
                CheckResults();
            return;
        }

        if (codeSequence.Length >= 4) return;

        int digit = -1;
        switch (digitEntered)
        {
            case "Zero": digit = 0; break;
            case "One": digit = 1; break;
            case "Two": digit = 2; break;
            case "Three": digit = 3; break;
            case "Four": digit = 4; break;
            case "Five": digit = 5; break;
            case "Six": digit = 6; break;
            case "Seven": digit = 7; break;
            case "Eight": digit = 8; break;
            case "Nine": digit = 9; break;
        }

        if (digit != -1)
        {
            codeSequence += digit.ToString();
            UpdateDisplay(digit);
        }
    }

    private void CheckResults()
    {
        //Debug.Log($"Display {gameObject.name} checking code {codeSequence} against {keypad.GetCode()}");
        if (codeSequence == keypad.GetCode())
        {
            //OnCodeCorrect?.Invoke(keypad);
            Open = true; 

        }
        else
        {
            ResetDisplay();
        }
    }

    private void ResetDisplay()
    {
        codeSequence = "";
        foreach (var img in characters)
        {
            img.sprite = digits[10]; // empty
        }
    }

    private void UpdateDisplay(int digitJustEntered)
    {
        // Just updating the last slot for simplicity
        for (int i = 0; i < characters.Length - 1; i++)
            characters[i].sprite = characters[i + 1].sprite;

        characters[characters.Length - 1].sprite = digits[digitJustEntered];
    }

    private void OnDestroy()
    {
        PushTheButton.ButtonPressed -= AddDigitToCodeSequence;
    }
}
