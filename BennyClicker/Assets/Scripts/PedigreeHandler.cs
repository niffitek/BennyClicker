using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PedigreeHandler : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.back, 20 * Time.deltaTime);
    }
}
