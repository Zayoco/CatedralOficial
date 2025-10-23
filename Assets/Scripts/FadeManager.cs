using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public Animator animator;      // Animator del Canvas
    public Canvas canvasFade;      // Canvas con la imagen negra
    public float fadeDuration = 2f;

    private void Start()
    {
        // Al iniciar la escena, asegurarse que el canvas esté activo y ejecutar FadeIn
        canvasFade.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    // FadeIn: pantalla negra → visible
    public IEnumerator FadeIn()
    {
        animator.SetTrigger("FadeOut");  // Trigger FadeIn en Animator
        yield return new WaitForSeconds(fadeDuration);
        canvasFade.gameObject.SetActive(false);
    }

    // FadeOut: visible → pantalla negra antes de cargar otra escena
    public IEnumerator FadeOutAndLoad(string sceneName)
    {
        canvasFade.gameObject.SetActive(true);
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(fadeDuration);

        SceneManager.LoadScene(sceneName);
    }
}


