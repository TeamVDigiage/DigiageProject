using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    Vector3 offset = new Vector3(5, 2, 0);
    [SerializeField] GameObject player;
    void Start()
    {
        
    }
    void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime * 5);
        //transform.rotation = Quaternion.Euler(0, player.transform.rotation.eulerAngles.y, 0);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 2);
    }
}
