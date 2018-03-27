using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public int PoolSize = 5;
    public GameObject columnPrefab;
    public Vector2 objPoolPosition = new Vector2(-15f, -25f);
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] pool;
    private float timeSinceLastSpawn;
    private float spawnX = 10f;
    private int currentColumn = 0;

	// Use this for initialization
	void Start () {
        pool = new GameObject[PoolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = (GameObject)Instantiate(columnPrefab, objPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawn += Time.deltaTime;

        if(!GameManager.instance.isGameOver && timeSinceLastSpawn >=spawnRate)
        {
            timeSinceLastSpawn = 0f;
            float spawnY = Random.Range(columnMin, columnMax);

            pool[currentColumn].transform.position = new Vector2(spawnX, spawnY);
            currentColumn++;
            if(currentColumn>=PoolSize)
            {
                currentColumn = 0;
            }

        }
	}
}
