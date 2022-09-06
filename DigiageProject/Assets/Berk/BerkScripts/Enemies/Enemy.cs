using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int enemyHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            other.gameObject.SetActive(false);

            if (enemyHealth > 1)
                enemyHealth -= 1;

            else if (enemyHealth == 1)

                Destroy(gameObject); //Enemy object pool yapıldığında destroy edilmeyecek, false edilecek.

        }
    }

}
