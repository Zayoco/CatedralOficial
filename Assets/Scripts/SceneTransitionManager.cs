using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;
    public Image fadeImage; // imagen del Canvas para el fundido (negro)

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // mantiene el fade entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método simple para cargar escena con fundido
    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(sceneName);
        yield return StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        if (fadeImage == null)
            yield break;

        Color color = fadeImage.color;
        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            color.a = t;
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;
    }

    private IEnumerator FadeIn()
    {
        if (fadeImage == null)
            yield break;

        Color color = fadeImage.color;
        for (float t = 1f; t > 0f; t -= Time.deltaTime)
        {
            color.a = t;
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0f;
        fadeImage.color = color;
    }
}
