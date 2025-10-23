using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    public class TouchSensitivityManager : MonoBehaviour
    {
        public static TouchSensitivityManager instance;

        private const string SensitivityKey = "TouchSensitivity";
        private float currentSensitivity = 0.2f; // Valor base (ajústalo a gusto)

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

            currentSensitivity = PlayerPrefs.GetFloat(SensitivityKey, 1f);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            StartCoroutine(FindSlidersNextFrame());
        }

        private IEnumerator FindSlidersNextFrame()
        {
            yield return null;

            // Busca sliders con el tag "TouchSlider"
            Slider[] sliders = GameObject.FindObjectsOfType<Slider>(true);
            foreach (Slider s in sliders)
            {
                if (s.CompareTag("TouchSlider"))
                {
                    s.value = currentSensitivity;
                    s.onValueChanged.RemoveAllListeners();
                    s.onValueChanged.AddListener(delegate { SetSensitivity(s.value); });
                }
            }
        }

        public void SetSensitivity(float value)
        {
            currentSensitivity = value;
            PlayerPrefs.SetFloat(SensitivityKey, value);
        }

        public float GetSensitivity()
        {
            return currentSensitivity;
        }
    }
