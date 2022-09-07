using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    private Queue<GameObject> pooledArrow;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private int poolSize;

    private void Awake()
    {
        pooledArrow = new Queue<GameObject>();

        for(int i = 0; i< poolSize; i++)
        {
            GameObject obj = Instantiate(arrowPrefab);
            obj.SetActive(false);
            pooledArrow.Enqueue(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject obj = pooledArrow.Dequeue();
        obj.SetActive(true);
        pooledArrow.Enqueue(obj);
        return obj;
    }
}
