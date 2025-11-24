using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManagerMenu : MonoBehaviour
{
    public static AudioManagerMenu instance;

    private const string VolumeKey = "MasterVolume";

    private float currentVolume = 1f;

    private void Awake()
    {
        // Singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Cargar valor guardado
        currentVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        AudioListener.volume = currentVolume;

        // Escuchar cambios de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Esperar un frame para que la UI esté lista
        StartCoroutine(AssignSlidersNextFrame());
    }

    private IEnumerator AssignSlidersNextFrame()
    {
        yield return null;

        // Busca todos los sliders con el tag "VolumeSlider"
        Slider[] sliders = GameObject.FindObjectsOfType<Slider>(true);

        foreach (Slider s in sliders)
        {
            if (s.CompareTag("VolumeSlider"))
            {
                // Asignar valor actual
                s.value = currentVolume;

                // Borrar listeners viejos y añadir uno nuevo
                s.onValueChanged.RemoveAllListeners();
                s.onValueChanged.AddListener(delegate { SetVolume(s.value); });
            }
        }
    }

    public void SetVolume(float value)
    {
        currentVolume = value;
        AudioListener.volume = value;
        PlayerPrefs.SetFloat(VolumeKey, value);
    }
}
//public class AudioManagerMenu : MonoBehaviour
//{
//    public static AudioManagerMenu instance;

//    [SerializeField] private Slider volumenSlider;

//    private const string VolumeKey = "MasterVolume";

//    private void Awake()
//    {
//        // Singleton que persiste entre escenas
//        if (instance != null)
//        {
//            Destroy(gameObject);
//            return;
//        }

//        instance = this;
//        DontDestroyOnLoad(gameObject);
//        SceneManager.sceneLoaded += OnSceneLoaded;
//    }

//    private void Start()
//    {
//        // Cargamos y aplicamos el volumen guardado
//        float savedValue = PlayerPrefs.GetFloat(VolumeKey, 1f);
//        AudioListener.volume = savedValue;

//        // Si hay un slider en escena, sincronizamos
//        if (volumenSlider != null)
//        {
//            volumenSlider.value = savedValue;
//            volumenSlider.onValueChanged.AddListener(SetVolume);
//        }
//    }

//    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//    {
//        // Espera un frame para que todo se haya cargado
//        StartCoroutine(FindSliderNextFrame());
//    }

//    private IEnumerator FindSliderNextFrame()
//    {
//        yield return null; // espera 1 frame
//        FindAndBindSlider();
//    }

//    private void FindAndBindSlider()
//    {
//        // Busca cualquier slider con la etiqueta "VolumeSlider"
//        GameObject sliderObj = GameObject.FindWithTag("VolumeSlider");

//        if (sliderObj != null)
//        {
//            volumenSlider = sliderObj.GetComponent<Slider>();

//            if (volumenSlider != null)
//            {
//                volumenSlider.onValueChanged.RemoveAllListeners();
//                volumenSlider.onValueChanged.AddListener(SetVolume);
//                volumenSlider.value = PlayerPrefs.GetFloat(VolumeKey, 1f);
//            }
//        }
//    }

//    private void SetVolume(float value)
//    {
//        AudioListener.volume = value;
//        PlayerPrefs.SetFloat(VolumeKey, value);
//    }
//}

//public class AudioManagerMenu : MonoBehaviour
//{
//    public static AudioManagerMenu instance;

//    [SerializeField] private Slider volumenSlider;

//    private const string VolumeKey = "MasterVolume";

//    private void Awake()
//    {
//        if (instance != null)
//        {
//            Destroy(gameObject);
//            return;
//        }

//        instance = this;
//        DontDestroyOnLoad(gameObject);
//        SceneManager.sceneLoaded += OnSceneLoaded; // Se ejecuta cuando cambia de escena
//    }

//    private void Start()
//    {
//        LoadVolume();
//        ApplyVolume();
//        FindSliderIfMissing();
//    }

//    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
//    {
//        // Cada vez que cambia de escena, buscamos un nuevo slider si no hay uno asignado
//        FindSliderIfMissing();
//    }

//    private void FindSliderIfMissing()
//    {
//        if (volumenSlider == null)
//        {
//            volumenSlider = FindObjectOfType<Slider>(); // busca el primer slider de la escena
//            if (volumenSlider != null)
//            {
//                volumenSlider.onValueChanged.AddListener(delegate { SetVolume(volumenSlider.value); });
//                volumenSlider.value = PlayerPrefs.GetFloat(VolumeKey, 1f);
//            }
//        }
//    }

//    public void SetVolume(float value)
//    {
//        //AudioListener.volume = value;
//        AudioListener.volume = volumenSlider.value;
//        PlayerPrefs.SetFloat(VolumeKey, value);
//    }

//    private void LoadVolume()
//    {
//        if (PlayerPrefs.HasKey(VolumeKey))
//        {
//            float savedValue = PlayerPrefs.GetFloat(VolumeKey);
//            AudioListener.volume = savedValue;
//            if (volumenSlider != null)
//                volumenSlider.value = savedValue;
//        }
//        else
//        {
//            PlayerPrefs.SetFloat(VolumeKey, 1f);
//            AudioListener.volume = 1f;
//        }
//    }

//    private void ApplyVolume()
//    {
//        AudioListener.volume = PlayerPrefs.GetFloat(VolumeKey, 1f);
//    }
//}
//public class AudioManagerMenu : MonoBehaviour
//{
//    public static AudioManagerMenu instance;

//    [SerializeField] Slider VolumenSlider;
//    // Start is called before the first frame update


//    private void Awake()
//    {
//        if(instance != null)
//            Destroy(gameObject);
//        else
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//    }
//    void Start()
//    {
//        if (PlayerPrefs.HasKey("soundVolume"))
//            LoadVolume();
//        else
//        {
//            PlayerPrefs.SetFloat("SoundVolume", 1f);
//            LoadVolume();
//        }

//    }

//    // Update is called once per frame
//    public void  SetVolume()
//    {
//        AudioListener.volume = VolumenSlider.value;
//        SaveVolume();
//    }

//    public void SaveVolume()
//    {
//        PlayerPrefs.SetFloat("SoundVolume", VolumenSlider.value);
//    }

//    public void LoadVolume()
//    {
//        VolumenSlider.value = PlayerPrefs.GetFloat("SoundVolume");
//    }
//}

