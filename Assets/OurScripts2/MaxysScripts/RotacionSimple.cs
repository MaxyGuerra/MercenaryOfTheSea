using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionSimple : MonoBehaviour
{
    public float r1;
    public float r2;
    public float r3;
    void Update()
    {
        transform.Rotate(r1 * Time.deltaTime, r2 * Time.deltaTime, r3 * Time.deltaTime);
    }
}
