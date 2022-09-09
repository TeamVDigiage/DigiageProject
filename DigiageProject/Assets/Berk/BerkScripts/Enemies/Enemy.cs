using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int enemyHealth;
    [SerializeField] Transform spawnPoint;
    //int startHealth;
    //EnemyAnimation enemyAnimation;

    //private void Start()
    //{
    //    enemyHealth = startHealth;
    //    enemyAnimation = GetComponent<EnemyAnimation>();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            other.gameObject.SetActive(false);

            if (enemyHealth > 1)
                enemyHealth -= 1;

            else if (enemyHealth == 1)
            {
                transform.position = spawnPoint.position;
                //enemyAnimation.DyingAnimation();
                //StartCoroutine(DeathDelay());
            }       
        }
    }

    //public IEnumerator DeathDelay()
    //{
    //    enemyHealth = startHealth;
    //    yield return new WaitForSeconds(0.5f);
    //    transform.position = spawnPoint.position;
    //}
}
