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
    [SerializeField] private GameObject PanelCreditos;

    private void Awake()
    {
        //SceneManager.LoadScene("PrincipalMenu");
    }
    void Start()
    {
        //SceneManager.LoadScene("PrincipalMenu");
    }

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
                Time.timeScale = 0f; 

                break;
            case 6:
                PanelOpciones.SetActive(false);
                Time.timeScale = 1f; 
                break;
            case 7:
                SceneManager.LoadScene("Creditos");
                break;
            case 8:
                SceneManager.LoadScene("PrincipalMenu");
                break;    
            default:
                Debug.Log("indice no valido");
                break;
        }
    }
}