using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float XMove;
    private float YMove;
    private float XRotation;
    [SerializeField] private Transform PlayerBody;
    public Vector2 LockAxis;
    public float baseSensitivity = 0.2f;

    void Update()
    {
        // Obtener sensibilidad global desde el manager (slider)
        float sliderSensitivity = TouchSensitivityManager.instance.GetSensitivity();

        // Combinamos sensibilidad base + del slider
        float finalSensitivity = baseSensitivity * sliderSensitivity;

        // Aplicamos movimiento (sin Time.deltaTime, ya que LockAxis ya es delta por frame)
        XMove = LockAxis.x * finalSensitivity;
        YMove = LockAxis.y * finalSensitivity;

        // Rotación vertical (pitch)
        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        // Aplicamos rotaciones
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * XMove);
    }
}
//void Start()
//{

//}


//    void Update()
//    {
//        float sensitivity = TouchSensitivityManager.instance.GetSensitivity();

//        XMove = LockAxis.x * Sensivity * Time.deltaTime;
//        YMove = LockAxis.y * Sensivity * Time.deltaTime;
//        XRotation -= YMove;
//        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

//        transform.localRotation = Quaternion.Euler(XRotation,0,0);
//        PlayerBody.Rotate(Vector3.up * XMove);
//    }
//}
