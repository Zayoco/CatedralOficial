using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public Animator animator;      
    public Canvas canvasFade;  
    public float fadeDuration = 2f;

    private void Start()
    {
        canvasFade.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        animator.SetTrigger("FadeOut");  
        yield return new WaitForSeconds(fadeDuration);
        canvasFade.gameObject.SetActive(false);
    }

    public IEnumerator FadeOutAndLoad(string sceneName)
    {
        canvasFade.gameObject.SetActive(true);
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(fadeDuration);

        SceneManager.LoadScene(sceneName);
    }
}


