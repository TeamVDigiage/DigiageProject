using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    //spells and spawnPoint lenths must be equal
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject[] spells;
    [SerializeField] private float spawnDelay;
    private GameObject[] Pool;
    private float spawnRare;
    private int i;
    public static bool isSpawn;
    private void Start()
    {
        isSpawn = true;
        Pool = new GameObject[spells.Length];
        for (int i = 0; i < Pool.Length; i++)
        {
            GameObject poolBulletObj = Instantiate(spells[i]);
            poolBulletObj.SetActive(false);
            Pool[i] = poolBulletObj;
        }
    }
    private void Update()
    {
        SpellSpawn(isSpawn);
    }
    public void SpellSpawn(bool isSpawn)
    {
        if (isSpawn)
        {
            if (Time.time > spawnRare)
            {
                int spawnindex = Random.Range(0, spawnPoint.Length);
                if (i >= spells.Length)
                {
                    i = 0;
                }
                Pool[i].SetActive(true);
                Pool[i].transform.position = spawnPoint[spawnindex].position;
                i++;
                spawnRare = Time.time + spawnDelay;
            }
        }
        
    }
}