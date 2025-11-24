using UnityEngine;

public class RotacionObjeto : MonoBehaviour
{
    public Transform centro;
    public float velocidad = 5f;

    void Update()
    {
        transform.RotateAround(centro.position, Vector3.up, velocidad * Time.deltaTime);
    }
}
