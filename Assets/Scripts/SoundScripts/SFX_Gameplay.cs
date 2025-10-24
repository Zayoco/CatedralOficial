using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class SFX_Gameplay : MonoBehaviour
{
    [SerializeField] EventReference pasos;

    private EventInstance instanciaPasos;
    private string escena;

    private void OnEnable()
    {
        SoundEvents.Pasos += ReproducirPasosConcreto;
        SoundEvents.DetenerPasos += DetenerPasosConcreto;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Scene escenaActiva = SceneManager.GetActiveScene();
        instanciaPasos = RuntimeManager.CreateInstance(pasos);
        escena = escenaActiva.name;
    }

    void Update()
    {
        // ?? Detectar si la escena cambi�
        string escenaActual = SceneManager.GetActiveScene().name;
        if (escena != escenaActual)
        {
            escena = escenaActual;
            UnityEngine.Debug.Log("Escena actualizada a: " + escena);
        }
    }

    private void ReproducirPasosConcreto()
    {
        if (!pasos.IsNull)
        {
            instanciaPasos.start();

            if (escena == "escena 1")
            {
                instanciaPasos.setParameterByName("Binario0-1", 0);
            }
            else if (escena == "escena 2")
            {
                instanciaPasos.setParameterByName("Binario0-1", 1);
            }

            UnityEngine.Debug.Log("Reproduciendo pasos en: " + escena);
        }
    }

    private void DetenerPasosConcreto()
    {
        if (!pasos.IsNull)
        {
            instanciaPasos.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
