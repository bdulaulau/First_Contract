using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ZoneAlert : MonoBehaviour
{
    public Image fadeImage;
    public TextMeshProUGUI alertText;
    public string message = "ZONE DANGEREUSE";
    public float fadeDuration = 0.5f;
    public float displayDuration = 2f;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(ShowAlert());
        }
    }

    IEnumerator ShowAlert()
    {
        AudioListener.volume = 0f;
        yield return StartCoroutine(Fade(0f, 1f, fadeDuration));

        // Affiche message
        alertText.text = message;
        alertText.gameObject.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        // Cache message
        alertText.gameObject.SetActive(false);

        yield return StartCoroutine(Fade(1f, 0f, fadeDuration));
        AudioListener.volume = 1f;
    }

    IEnumerator Fade(float start, float end, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float alpha = Mathf.Lerp(start, end, elapsed / duration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, end);
    }
}
