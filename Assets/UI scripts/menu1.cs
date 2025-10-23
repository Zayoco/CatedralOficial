using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;
using UnityEngine.SceneManagement;

public class menu1 : MonoBehaviour
{
    [SerializeField] int indice;
    [SerializeField] private GameObject PanelSalirEscritorio;
    [SerializeField] private GameObject PanelOpciones;

    // Start is called before the first frame update
    private void Awake()
    {
        //SceneManager.LoadScene("PrincipalMenu");
    }
    void Start()
    {
        //SceneManager.LoadScene("PrincipalMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        switch (indice)
        {
            case 0:
                SceneManager.LoadScene("escena 1");
                break;
            case 1:
                SceneManager.LoadScene("escena 2");
                break;
            case 2:
                PanelSalirEscritorio.SetActive(true);
                break;
            case 3:
                Debug.Log("Saliendo...");
                Application.Quit();
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
                break;
            case 4:
                PanelSalirEscritorio.SetActive(false);
                break;
            case 5:
                PanelOpciones.SetActive(true);
                Time.timeScale = 0f; // Congela todo el tiempo del juego
                //if (player != null)
                //    player.GetComponent<CharacterController>().enabled = false; // Desactiva movimiento
                break;
            case 6:
                PanelOpciones.SetActive(false);
                Time.timeScale = 1f; // Congela todo el tiempo del juego
                break;
            default:
                Debug.Log("Índice no válido");
                break;
        }
    }
}