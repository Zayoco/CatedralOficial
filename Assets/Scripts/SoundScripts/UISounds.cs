using UnityEngine;
using FMODUnity;
using UnityEngine.UI;
using FMOD.Studio;
using static UnityEngine.Rendering.DebugUI;

public class UISounds : MonoBehaviour
{
    [SerializeField] SFX_Gameplay sfx_Gameplay;
    [SerializeField] EventReference clickEvent;
    [SerializeField] EventReference menuMusic;

    void Start()
    {
        if(!menuMusic.IsNull && sfx_Gameplay)
            RuntimeManager.PlayOneShot(menuMusic);
    }
    void Update()
    {        
        
    }


    public void PlayClickDos()
    {
        if (!clickEvent.IsNull)
            RuntimeManager.PlayOneShot(clickEvent);
    }

    
}
