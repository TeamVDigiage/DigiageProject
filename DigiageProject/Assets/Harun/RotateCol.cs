using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCol : MonoBehaviour
{
    public static RotateCol instance;
    public bool rotate = false;
    bool inc = true;
    [SerializeField] GameObject rotateObject;
    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rotate"))
        {
            rotateObject = other.gameObject;
            rotate = true;
            Debug.Log("b");
        }
        if (other.gameObject.CompareTag("RotateTour") && gameObject.name == "Player")
        {
            ScoreSystem.instance.inc *= 5;
            rotateObject = other.gameObject;
            rotate = true;
        }
    }
    private void Update()
    {
        //Debug.Log(rotateObject.transform.rotation.eulerAngles);
        if (rotate && gameObject.name != "RotateCam")
        {
            Debug.Log("a");
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rotateObject.transform.rotation.eulerAngles.y, 0), Time.deltaTime * 6);
        }
        if (rotate && gameObject.name == "RotateCam")
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rotateObject.transform.rotation.eulerAngles.y - 180, 0), Time.deltaTime * 6);
        }
    }
}
