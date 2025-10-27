using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class SFX_Gameplay : MonoBehaviour
{
    [SerializeField] EventReference pasos;
    [SerializeField] EventReference abrirPuerta;
    [SerializeField] EventReference cerrarPuerta;

    [SerializeField] private StudioEventEmitter campana;

    [SerializeField] private Slider masterVolume;

    private EventInstance instanciaPasos;
    private EventInstance instanciaAbrirPuerta;
    private string escena;

    private void OnEnable()
    {
        SoundEvents.Pasos += ReproducirPasosConcreto;
        SoundEvents.DetenerPasos += DetenerPasosConcreto;
        SoundEvents.AbrirPuerta += ReproducirAbrirPuerta;
    }

    private void OnDisable()
    {
        SoundEvents.AbrirPuerta -= ReproducirAbrirPuerta;
        SoundEvents.Pasos -= ReproducirPasosConcreto;
    }

    void Start()
    {
        Scene escenaActiva = SceneManager.GetActiveScene();
        instanciaPasos = RuntimeManager.CreateInstance(pasos);
        instanciaAbrirPuerta = RuntimeManager.CreateInstance(abrirPuerta);

        escena = escenaActiva.name;

        if (escena == "escena 2")
            RuntimeManager.PlayOneShot(cerrarPuerta);

        if (escena == "escena 3")
            StartCoroutine(ReproducirCampanas());
    }

    void Update()
    {
        ActualizarMasterVolume();

        // ?? Detectar si la escena cambió
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
            //float test;
            if (escena == "escena 1")
            {
                instanciaPasos.setParameterByName("Trinario0-2", 2);
                /*instanciaPasos.getParameterByName("Trinario0-2", out test);
                UnityEngine.Debug.Log("Valor 1 actual del parámetro Trinario: " + test);
                */
            }
            else if (escena == "escena 2")
            {
                instanciaPasos.setParameterByName("Trinario0-2", 1);
            }
            else if (escena == "escena 3")
            {
                instanciaPasos.setParameterByName("Trinario0-2", 0);
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
    public void ActualizarMasterVolume() 
    {        
        float volume = masterVolume.value;
        //Debug.Log("Valor actual del Scrollbar: " + volume);
        //UnityEngine.Debug.Log("Actualizando Master Volume..." + volume);
        RuntimeManager.StudioSystem.setParameterByName("MasterFader", volume);
        RuntimeManager.StudioSystem.getParameterByName("MasterFader", out float value);
        //Debug.Log("Valor actual del MasterFader: " + value);
    }
    public void ReproducirAbrirPuerta()
    {
        if (!abrirPuerta.IsNull)
        {
            instanciaAbrirPuerta.start();
            if (escena == "escena 3")
               instanciaAbrirPuerta.setParameterByName("Binario0-1", 0);
            else instanciaAbrirPuerta.setParameterByName("Binario0-1", 1);
        }
    }
    private IEnumerator ReproducirCampanas()
    {
        while (true)
        {
            campana.Play();
            yield return new WaitForSeconds(60f);
        }
    }
}
