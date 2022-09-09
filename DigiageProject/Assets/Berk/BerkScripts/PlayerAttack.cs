using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private ArrowPool arrowPool = null;
    [SerializeField] private int _arrowCount;
    PlayerAnimation playerAnimation;

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CollectableArrows"))
        {
            _arrowCount += 4;
            other.gameObject.SetActive(false);
        }

        Debug.Log("Arrows:" + _arrowCount);
    }

    void Shoot()
    {
        if (_arrowCount > 0)
        {
            _arrowCount -= 1;
            var obj = arrowPool.GetPooledObject();
            obj.transform.position = gameObject.transform.position;

            //Animasyon Eklendiğinde Açılacak
            //playerAnimation.ShootAnimation();
        }

    }



}