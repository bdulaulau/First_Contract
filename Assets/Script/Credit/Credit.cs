using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Credit : MonoBehaviour
{
    public Image fadeImage;
    public TextMeshProUGUI credit;
    public float fadeDuration = 0.5f;
    public float displayDuration = 2f;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(ShowCredit());
        }
    }

    IEnumerator ShowCredit()
    {
        AudioListener.volume = 0f;
        yield return StartCoroutine(Fade(0f, 1f, fadeDuration));

        // Affiche message
        credit.gameObject.SetActive(true);

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
