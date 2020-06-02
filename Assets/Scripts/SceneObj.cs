using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SceneObj : MonoBehaviour
{
    public new Renderer renderer;
    public Guid guid;
    void Awake()
    {
        guid = Guid.NewGuid();
    }

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();   
    }

    private void OnMouseDown()
    {
        if (GameEvents.OnMouseDown != null) GameEvents.OnMouseDown(this);
    }

    private void OnMouseDrag()
    {
        if (GameEvents.OnSimpleDrag != null) GameEvents.OnSimpleDrag();
    }
}
