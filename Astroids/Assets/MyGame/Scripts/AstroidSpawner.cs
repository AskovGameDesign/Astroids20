using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    public float spawnRate = 2f;
    public GameObject astroidPrefab;

    public List<Transform> spawnPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        Transform[] tmpList = GetComponentsInChildren<Transform>();
        
        foreach (var item in tmpList)
        {
            if (item != this.transform)
                spawnPoints.Add(item);
        }

        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            Instantiate(astroidPrefab, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
            
            yield return new WaitForSeconds(spawnRate);
        }
    }

}
