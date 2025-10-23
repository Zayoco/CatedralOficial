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

            // Busca FadeManager en la escena actual
            FadeManager fade = FindObjectOfType<FadeManager>();
            if (fade != null)
            {
                StartCoroutine(fade.FadeOutAndLoad(sceneToLoad));
            }
            else
            {
                Debug.LogWarning("Chale no da :(");
                // carga la escena sin faded
                StartCoroutine(LoadWithoutFade());
            }
        }
    }

    private IEnumerator LoadWithoutFade()
    {
        yield return new WaitForSeconds(2f); // Espera un time a.., segundo antes de cambiar
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
