using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesArray;
    [SerializeField] float spawningArea;
    [SerializeField] float initialTimeBetweenSpawns;
    [SerializeField] float finalTimeBetweenSpawns;
    [SerializeField] float deltaTimeBetweenSpawns;
    [SerializeField] float noSpawnZoneAroundPlayer; //Don't set to more than 10 unless you like lag, this gets used in a while loop;

    bool spawning = true;

    private Transform playerTransform;

    void Start() {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        StartCoroutine(SpawnEnemy(initialTimeBetweenSpawns));
    }


    void Spawn(GameObject enemy) {
        Vector2 spawnPlace = new Vector2(Random.Range(-spawningArea, spawningArea), Random.Range(-spawningArea, spawningArea));

        Instantiate(enemy, spawnPlace, Quaternion.identity);
    }

    Vector2 ChooseSpawnLocation() {
        Vector2 spawnPlace = playerTransform.position;
        while (Vector2.Distance(playerTransform.position, spawnPlace) < noSpawnZoneAroundPlayer) {
            spawnPlace = new Vector2(Random.Range(-spawningArea, spawningArea), Random.Range(-spawningArea, spawningArea));
        }

        return spawnPlace;
    }

    IEnumerator SpawnEnemy(float timeBetweenSpawns) {
        while (spawning) {
            Spawn(enemiesArray[0]);
            yield return new WaitForSeconds(timeBetweenSpawns);

            if (timeBetweenSpawns > finalTimeBetweenSpawns) timeBetweenSpawns -= deltaTimeBetweenSpawns;
        }
    }
}
