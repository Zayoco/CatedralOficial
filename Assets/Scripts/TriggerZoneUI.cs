using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneUI : MonoBehaviour
{
    public GameObject botonMostrar;   // Botón que aparece dentro del trigger
    public GameObject panelInfo;      // Panel con imagen
    public GameObject panelLink;      // Segundo panel (link)

    void Start()
    {
        if (botonMostrar != null)
            botonMostrar.SetActive(false);

        if (panelInfo != null)
            panelInfo.SetActive(false);

        if (panelLink != null)
            panelLink.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            botonMostrar.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            botonMostrar.SetActive(false);
            panelInfo.SetActive(false);
            panelLink.SetActive(false);
        }
    }

    // Mostrar panel normal
    public void MostrarPanel()
    {
        panelInfo.SetActive(true);
    }

    // Mostrar panel con link
    public void MostrarPanelLink()
    {
        panelLink.SetActive(true);
    }

    // Botón para cerrar paneles
    public void CerrarPanel()
    {
        panelInfo.SetActive(false);
        panelLink.SetActive(false);
    }
}


