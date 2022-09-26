using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public SaveObject so;
    public GameObject player;
    public List<GameObject> objects;
    void Start()
    {
        so = SaveManager.Load();
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].name == so.objName)
            {
                Instantiate(objects[i], objects[i].transform.position, objects[i].transform.rotation);
            }
        }
    }
}
