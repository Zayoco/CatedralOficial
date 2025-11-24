using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneUI : MonoBehaviour
{
    public GameObject botonMostrar;   
    public GameObject panelInfo;      
    public GameObject panelLink;     

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


    public void MostrarPanel()
    {
        panelInfo.SetActive(true);
    }

    public void MostrarPanelLink()
    {
        panelLink.SetActive(true);
    }

    public void CerrarPanel()
    {
        panelInfo.SetActive(false);
        panelLink.SetActive(false);
    }
}


