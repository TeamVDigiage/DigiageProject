using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 2);
    }
}
