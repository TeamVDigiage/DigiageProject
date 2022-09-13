using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter 
{
    public static int killCount;

    public void Start()
    {
        killCount = 0;
    }

    public void CountKill()
    {
        killCount++;
        Debug.Log(killCount);
    }
}
