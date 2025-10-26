using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneIntroText : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float displayTime = 5f;   // tiempo visible antes del fade...
    public float fadeDuration = 2f;  // tiempo del desv

    public string customMessage = ""; // que decirr

    void Start()
    {
        StartCoroutine(ShowAndFadeText());
    }

    IEnumerator ShowAndFadeText()
    {
        if (messageText == null)
        {
            Debug.LogWarning("No se asignó un TextMeshProUGUI en SceneIntroText.");
            yield break;
        }

        // Muestra texto
        if (string.IsNullOrEmpty(customMessage))
            messageText.text = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        else
            messageText.text = customMessage;

        messageText.gameObject.SetActive(true);

        // Mantiene el texto visible unos seg
        yield return new WaitForSeconds(displayTime);

        // Empieza el desv
        float elapsedTime = 0f;
        Color originalColor = messageText.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            messageText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Oculta completamente el texto al final
        messageText.gameObject.SetActive(false);
    }
}

