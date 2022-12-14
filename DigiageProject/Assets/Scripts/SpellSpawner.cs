using UnityEngine;

public class SpellSpawner : MonoBehaviour
{

    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject[] spells;
    [SerializeField] private float spawnDelay;
        
    private GameObject[] pool = new GameObject[9];

    private float spawnRare;
    private int i;
    private void Start()
    {
        MakePool(pool, spells);
    }
    private void Update()
    {
        SpellSpawn(pool, spawnPoint);
    }
    public void SpellSpawn(GameObject[] pool, Transform[] spawnPoint)
    {
        if (Time.time > spawnRare)
        {
            int spawnindex = Random.Range(0, spawnPoint.Length);
            if (i >= spells.Length)
            {
                i = 0;
            }
            pool[i].transform.GetChild(0).gameObject.SetActive(false);
            pool[i].transform.position = transform.position;
            pool[i].SetActive(true);
            pool[i].GetComponent<MeshRenderer>().enabled = true;
            pool[i].transform.localScale = Vector3.one;
            pool[i].transform.position = spawnPoint[spawnindex].position;
            pool[i].gameObject.GetComponent<SphereCollider>().enabled = true;
            i++;
            spawnRare = Time.time + spawnDelay;
        }
    }
    void MakePool(GameObject[] pool, GameObject[] spells)
    {
        for (int i = 0; i < pool.Length-1; i++)
        {
            GameObject poolBulletObj = Instantiate(spells[i]);
            poolBulletObj.SetActive(false);
            pool[i] = poolBulletObj;
        }
    }
}