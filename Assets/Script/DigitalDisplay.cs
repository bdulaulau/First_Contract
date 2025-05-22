using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class DigitalDisplay : MonoBehaviour
{
    [SerializeField] private Sprite[] digits;
    [SerializeField] private Image[] characters;
    [SerializeField] private KeypadManager keypad;

    //public event Action<KeypadManager> OnCodeCorrect;


    public AudioClip falseCode;
    public AudioClip correctCode;
    public AudioClip button;
    private AudioSource audioSource;
    public Door door;
    public bool Open = false;
    public GameObject KeypadUI;

    private string codeSequence = "";

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        ResetDisplay();
        PushTheButton.ButtonPressed += AddDigitToCodeSequence;
    }

    void Update()
    {
        int digit = -1;

       if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0)) {
    digit = 0;
    AudioManager.instance.PlayClipAt(button, transform.position);
}
else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) {
    digit = 1;
    AudioManager.instance.PlayClipAt(button, transform.position);
}
else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) {
    digit = 2;
    AudioManager.instance.PlayClipAt(button, transform.position);
}
else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) {
    digit = 3;
    AudioManager.instance.PlayClipAt(button, transform.position);
}
else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) {
    digit = 4;
    AudioManager.instance.PlayClipAt(button, transform.position);
}
else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) {
    digit = 5;
    AudioManager.instance.PlayClipAt(button, transform.position);
}
else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) {
    digit = 6;
    AudioManager.instance.PlayClipAt(button, transform.position);
}
else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7)) {
    digit = 7;
    AudioManager.instance.PlayClipAt(button, transform.position);
}
else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8)) {
    digit = 8;
    AudioManager.instance.PlayClipAt(button, transform.position);
}
else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9)) {
    digit = 9;
    AudioManager.instance.PlayClipAt(button, transform.position);
}

        if (digit != -1 && codeSequence.Length < 4)
        {
            codeSequence += digit.ToString();
            UpdateDisplay(digit); // Ajout d'un chiffre
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (codeSequence.Length > 0)
                CheckResults();         // Validation du code avec la touche Entr�e ou KeypadEnter
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ResetDisplay(); // Reinitialisation avec la touche Backspace
        }
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
            AudioManager.instance.PlayClipAt(correctCode, transform.position);
            //OnCodeCorrect?.Invoke(keypad);
            Open = true;
            KeypadUI.gameObject.SetActive(false);
        }
        else
        {
            ResetDisplay();
            audioSource.PlayOneShot(falseCode);
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
