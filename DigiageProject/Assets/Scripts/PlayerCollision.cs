using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            other.GetComponent<SpellMove>().UseMove();
            other.GetComponent<SpellPower>().UseSpellPower();
        }
    }
}
