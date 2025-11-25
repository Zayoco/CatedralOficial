using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActivation : MonoBehaviour
{
    public GameObject objetoActivar;
    public float tiempoEspera = 9f; 

    private void Start()
    {
        StartCoroutine(EsperarYActivar());
    }

    private IEnumerator EsperarYActivar()
    {
        yield return new WaitForSeconds(tiempoEspera);

        objetoActivar.SetActive(true);
    }
}
