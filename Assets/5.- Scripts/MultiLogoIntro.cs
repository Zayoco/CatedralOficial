using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class MultiLogoIntro : MonoBehaviour
{
    public VideoPlayer videoPlayer;     
    public VideoClip[] logos;          
    public string nextScene = "MenuScene"; 

    private int index = 0;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished;
        PlayNextLogo();
    }

    void PlayNextLogo()
    {
        if (index < logos.Length)
        {
            videoPlayer.clip = logos[index];
            videoPlayer.Play();
            index++;
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        PlayNextLogo();
    }
}
