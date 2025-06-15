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
    void FixedUpdate()
    {
        getEnemyList();
    }
    IEnumerator EnemySpawn()
    {
        while (!PlayerController.Local.battle.health.isDeath)
        {
            if (objectsInLayer.Count > 3)
            {
                continue;
            }
            float randTime = Random.Range(0.5f, 2f);
            int randObject = Random.Range(0, enemyList.Count);
            Vector3 randPos = new Vector3(playerPos.x + Random.Range(10, 20), 0, 0);
            yield return new WaitForSeconds(randTime);
            Instantiate(enemyList[randObject], randPos, Quaternion.identity);
        }
    }
    void getEnemyList()
    {
        objectsInLayer.Clear();
        int layer = LayerMask.NameToLayer("enemy");
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == layer)
            {
                objectsInLayer.Add(obj);
            }
        }
    }
}
