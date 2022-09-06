using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCol : MonoBehaviour
{
    bool rotate = false;
    GameObject rotateObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rotate"))
        {
            rotateObject = other.gameObject;
            Debug.Log(gameObject.transform.rotation.eulerAngles.y);
            rotate = true;
        }
    }
    private void Update()
    {
        if (rotate)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rotateObject.transform.rotation.eulerAngles.y, 0), Time.deltaTime * 3);
        }
    }
}
