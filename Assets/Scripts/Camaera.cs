using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaera : MonoBehaviour
{
    public Transform target;
    Vector3 difference;
    void Start()
    {
        difference = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (!Ball.didItFall)
        {
           transform.position = target.position + difference;
        }
    }
}
