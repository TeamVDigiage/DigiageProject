using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject closestEnemy = null;

    //Speed for arrows movement speed to enemeies
    [SerializeField] float speed = 1;


    void Update()
    {
        FindClosestEnemy();
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;

        //Finds all game objects tagged enemy and adds to an array
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        //Checks every game objects distance to each other and finds closest one to the player
        foreach (GameObject currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy< distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        //if there is no on scene, arrows returns to the object pool.
        if (closestEnemy == null)
        {
            gameObject.SetActive(false);
            return;
        }


        MoveToEnemy();
    }

    //Arrows moves to closest enemy which has found from FindClosestEnemy function.
    void MoveToEnemy()
    {
        Vector3 targetPosition = closestEnemy.transform.position;
        Vector3 currentPosition = this.transform.position;

            Vector3 directionOfTravel = targetPosition - currentPosition;

            directionOfTravel.Normalize();

            this.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);

        //Rotates arrow upon enemy position to left or right
            transform.LookAt(targetPosition);

        //Fixes arrow models rotation to forward.
            transform.rotation *= Quaternion.Euler(0, -90, 0);
    }
}
