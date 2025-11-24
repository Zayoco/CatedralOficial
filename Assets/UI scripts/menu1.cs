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
    [SerializeField] private GameObject PanelMainMenu;

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
            case 0: //activar escena 1, patio
                SceneManager.LoadScene("escena 1");
                break;
            case 1: //activar escena 2, salon principal
                SceneManager.LoadScene("escena 2");
                break;
            case 2: //activar panel salir escritorio
                PanelSalirEscritorio.SetActive(true);
                PanelOpciones.SetActive(false);

                break;
            case 3: //salir escritorio, SI
                Debug.Log("Saliendo...");
                Application.Quit();
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
                break;
            case 4: //salir escritorio, NO
                PanelSalirEscritorio.SetActive(false);
                PanelOpciones.SetActive(true);
                break;
            case 5: //activar panel opciones
                PanelMainMenu.SetActive(false);
                PanelOpciones.SetActive(true);
                Time.timeScale = 0f; 

                break;
            case 6: //desactivar panel opciones
                PanelMainMenu.SetActive(true);
                PanelOpciones.SetActive(false);
                Time.timeScale = 1f; 
                break;
            case 7: //activar escena creditos
                SceneManager.LoadScene("Creditos");
                break;
            case 8: //activar escena menu principal
                SceneManager.LoadScene("PrincipalMenu");
                break;    
            default: //indice no valido
                Debug.Log("indice no valido");
                break;
        }
    }
}