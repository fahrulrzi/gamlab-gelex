using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour
{
    public float hoverScale = 1.1f; 
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter()
    {
        transform.localScale = originalScale * hoverScale;
    }

    public void OnPointerExit()
    {
        transform.localScale = originalScale;
    }
}
