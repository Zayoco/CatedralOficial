using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField _FixedTouchField;
    public CameraLook _CameraLook;

    void Start()
    {
        // Buscar referencias autom�ticamente si no est�n asignadas
        if (_FixedTouchField == null)
            _FixedTouchField = FindObjectOfType<FixedTouchField>();
        if (_CameraLook == null)
            _CameraLook = FindObjectOfType<CameraLook>();
    }

    void Update()
    {
        // Evitar errores si a�n no existen
        if (_FixedTouchField == null || _CameraLook == null)
            return;

        _CameraLook.LockAxis = _FixedTouchField.TouchDist;
    }
}
