using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public List<GameObject> enemyList;
    public Vector3 playerPos;
    public GameObject player;
    public List<GameObject> objectsInLayer = new List<GameObject>();
    void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    void Update()
    {
        playerPos = player.transform.position;
    }
    IEnumerator EnemySpawn()
    {
        while (!PlayerController.Local.battle.health.isDeath)
        {
            if (Enemy.enemies.Count >= 3)
            {
                yield return null;
                continue;
            }
            float randTime = Random.Range(0.5f, 2f);
            int randObject = Random.Range(0, enemyList.Count);
            Vector3 randPos = new Vector3(playerPos.x + Random.Range(10, 20), 0, 0);
            yield return new WaitForSeconds(randTime);
            Instantiate(enemyList[randObject], randPos, Quaternion.identity);
        }
    }
}
