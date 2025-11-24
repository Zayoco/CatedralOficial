using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneIntroText : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float displayTime = 5f;   
    public float fadeDuration = 2f;  

    public string customMessage = ""; // que decir :v

    void Start()
    {
        StartCoroutine(ShowAndFadeText());
    }

    IEnumerator ShowAndFadeText()
    {
        if (messageText == null)
        {
            Debug.LogWarning("No se asign� un TextMeshProUGUI en SceneIntroText.");
            yield break;
        }

        if (string.IsNullOrEmpty(customMessage))
            messageText.text = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        else
            messageText.text = customMessage;

        messageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(displayTime);

        float elapsedTime = 0f;
        Color originalColor = messageText.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            messageText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        messageText.gameObject.SetActive(false);
    }
}

