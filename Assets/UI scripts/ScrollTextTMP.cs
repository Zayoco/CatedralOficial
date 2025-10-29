using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollTextTMP : MonoBehaviour
{
    public float speed = 50f; // velocidad de desplazamiento

    private RectTransform rectTransform;
    private RectTransform canvasRect;
    private Vector2 startPos;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }

    void OnEnable()
    {
        // obtener RectTransform del Canvas ahora que está activo
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasRect = canvas.GetComponent<RectTransform>();
        }

        // reinicia la posición al activarse
        rectTransform.anchoredPosition = startPos;
    }

    void Update()
    {
        if (canvasRect == null) return;

        // desplaza hacia arriba
        rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;

        // si sale del Canvas (parte superior)
        float topEdge = rectTransform.anchoredPosition.y + rectTransform.rect.height / 2;
        float canvasTop = canvasRect.rect.height / 2;

        if (topEdge > canvasTop)
        {
            rectTransform.anchoredPosition = startPos; // reinicia al inicio
        }
    }
}



