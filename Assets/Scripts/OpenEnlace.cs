using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEnlace : MonoBehaviour
{
    public string url = "https://www.youtube.com/watch?v=bWZfRx85FeA";

    public void AbrirURL()
    {
        Application.OpenURL(url);
    }
}
