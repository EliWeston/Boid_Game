using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBandAssigner : MonoBehaviour
{
    public int cubeBand;
    public float startScale;
    public Material _material;
    public bool colorChangerCheck = false;
    public Color _color;


    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (colorChangerCheck == true)
        {
            Color _color = new Color(AudioPeer._audioBandBuffer[cubeBand] - .01f, AudioPeer._audioBandBuffer[cubeBand] - .01f, AudioPeer._audioBandBuffer[cubeBand] - .01f);
            _material.SetColor("_EmissionColor", _color);
        }
    }
}
