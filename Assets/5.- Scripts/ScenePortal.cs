using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePortal : MonoBehaviour
{
    public string sceneToLoad;
    private bool isTransitioning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTransitioning)
        {
            isTransitioning = true;

            FadeManager fade = FindObjectOfType<FadeManager>();
            if (fade != null)
            {
                SoundEvents.AbrirPuerta?.Invoke();
                StartCoroutine(fade.FadeOutAndLoad(sceneToLoad));
            }
            else
            {
                Debug.LogWarning("Chale no da :(");
                StartCoroutine(LoadWithoutFade());
            }
        }
    }

    private IEnumerator LoadWithoutFade()
    {
        yield return new WaitForSeconds(2f); 
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
