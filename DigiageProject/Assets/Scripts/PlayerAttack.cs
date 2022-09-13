using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private ArrowPool arrowPool = null;
    public static int arrowCount;
    PlayerAnimation playerAnimation;

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectableArrows"))
        {
            arrowCount += 4;
            other.gameObject.SetActive(false);
        }

        Debug.Log("Arrows:" + arrowCount);
    }

    void Shoot()
    {
        if (arrowCount > 0)
        {
            playerAnimation.ShootAnimation();
            arrowCount -= 1;
            var obj = arrowPool.GetPooledObject();
            obj.transform.position = gameObject.transform.position;
            
        }
    }
}