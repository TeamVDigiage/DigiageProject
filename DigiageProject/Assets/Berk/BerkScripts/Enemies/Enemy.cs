using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int enemyHealth;
    [SerializeField] Transform spawnPoint;
    int _startHealth;
    public static KillCounter killCounter = new KillCounter();
    //EnemyAnimation enemyAnimation;


    private void Start()
    {
        _startHealth = enemyHealth;
        //enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            other.gameObject.SetActive(false);

            if (enemyHealth > 1)
                enemyHealth -= 1;

            else if (enemyHealth <= 1)
            {
                transform.position = spawnPoint.position;
                enemyHealth = _startHealth;
        
                    killCounter.CountKill();
                
                
                //enemyAnimation.DyingAnimation();
                //StartCoroutine(DeathDelay());
            }
        }
    }

    //public IEnumerator DeathDelay()
    //{

    //    yield return new WaitForSeconds(0.5f);
    //    transform.position = spawnPoint.position;
    //}
}
