using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    //spells and spawnPoint lenths must be equal
    [SerializeField] private Transform[] upSpawnPoint;
    [SerializeField] private GameObject[] upSpells;
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject[] spells;
    [SerializeField] private float spawnDelay;
    private GameObject[] pool;
    private GameObject[] upPool;
    private float spawnRare;
    private int i;
    private void Start()
    {
        MakePool(pool,spells);
        MakePool(upPool, upSpells);
    }
    private void Update()
    {
        SpellSpawn(pool, spawnPoint);
        SpellSpawn(upPool, upSpawnPoint);
    }
    public void SpellSpawn(GameObject [] pool,Transform [] spawnPoint)
    {
        if (Time.time > spawnRare)
        {
            int spawnindex = Random.Range(0, spawnPoint.Length);
            if (i >= spells.Length)
            {
                i = 0;
            }
            pool[i].transform.position = transform.position;
            pool[i].SetActive(true);
            pool[i].transform.localScale = Vector3.one;
            pool[i].transform.position = spawnPoint[spawnindex].position;
            i++;
            spawnRare = Time.time + spawnDelay;
        }
    }
    void MakePool(GameObject[]pool,GameObject[]spells)
    {
        pool = new GameObject[spells.Length];
        for (int i = 0; i < pool.Length; i++)
        {
            GameObject poolBulletObj = Instantiate(spells[i]);
            poolBulletObj.SetActive(false);
            pool[i] = poolBulletObj;
        }
    }
}