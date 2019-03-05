﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used for terrain which disappears after a while
/// </summary>
public class Breakable : MonoBehaviour
{
    private const float disappearDelay = 2f;
    private float disappearAfter = 0f;
    private float disappearRate = 1f;

    private Renderer rend;
    
    // Start is called before the first frame update
    void Start()
    {
        disappearAfter = 0.1f * Vector3.Distance(transform.position, PlayerController.Instance.transform.position);

        if (GetComponent<MeshRenderer>() != null)
        {
            rend = GetComponent<MeshRenderer>();
            rend.material.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rend != null)
        {
            rend.material.color = Color.Lerp(Color.white, Color.black, Time.timeSinceLevelLoad / disappearAfter);
        }

        if (Time.timeSinceLevelLoad > disappearAfter)
        {
            transform.Translate(Vector3.down * disappearRate * Time.deltaTime);
        }
    }
}