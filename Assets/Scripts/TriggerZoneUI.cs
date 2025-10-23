using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerZoneUI : MonoBehaviour
{
    public GameObject botonMostrar;   // El botón que se activa dentro del trigger
    public GameObject panelInfo;      // El panel o canvas con la imagen

    private bool jugadorDentro = false;

    void Start()
    {
        if (botonMostrar != null)
            botonMostrar.SetActive(false);

        if (panelInfo != null)
            panelInfo.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = true;
            botonMostrar.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDentro = false;
            botonMostrar.SetActive(false);
            panelInfo.SetActive(false);
        }
    }

    // Llamado desde el botón en el inspector
    public void MostrarPanel()
    {
        panelInfo.SetActive(true);
    }

    void Update()
    {
        // Si el panel está activo y el usuario toca cualquier parte de la pantalla
        if (panelInfo.activeSelf && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            panelInfo.SetActive(false);
        }

        // También funciona con clic de mouse (modo PC o editor)
        if (panelInfo.activeSelf && Input.GetMouseButtonDown(0))
        {
            panelInfo.SetActive(false);
        }
    }
}

