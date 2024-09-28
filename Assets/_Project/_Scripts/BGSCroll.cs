using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSCroll : MonoBehaviour
{
    public Renderer meshrenderer;
    public float speed = .1f;


    void Update()
    {
        meshrenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);

    }
}
