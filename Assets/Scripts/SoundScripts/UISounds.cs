using UnityEngine;
using FMODUnity;
using UnityEngine.UI;
using FMOD.Studio;
using static UnityEngine.Rendering.DebugUI;

public class UISounds : MonoBehaviour
{
    [SerializeField] EventReference clickEvent;

    
    private void Awake()
    {
        int managers = FindObjectsOfType<UISounds>().Length;
        if (managers > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
    
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
