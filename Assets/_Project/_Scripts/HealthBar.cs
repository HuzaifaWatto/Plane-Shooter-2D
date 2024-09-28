using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform Bar;

    Vector3 originalSize;

    private void Start()
    {
        originalSize = Bar.localScale;
    }


    public  void SetSize(float size)
    {
        Bar.localScale = new Vector3(originalSize.x * size, originalSize.y, originalSize.z);
    }
}
