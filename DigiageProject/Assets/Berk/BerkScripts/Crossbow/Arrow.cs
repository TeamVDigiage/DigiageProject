using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject closestEnemy = null;
    [SerializeField] float speed = 1;


    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy< distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        if (closestEnemy == null)
        {
            gameObject.SetActive(false);
            return;
        }

        MoveToEnemy();
    }

    void MoveToEnemy()
    {
        Vector3 targetPosition = closestEnemy.transform.position;
        Vector3 currentPosition = this.transform.position;

        if (Vector3.Distance(currentPosition, targetPosition) > .1f)
        {
            Vector3 directionOfTravel = targetPosition - currentPosition;

            directionOfTravel.Normalize();

            this.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);

            transform.LookAt(targetPosition);
            transform.rotation *= Quaternion.Euler(90, 0, 0);
        }
    }
}
