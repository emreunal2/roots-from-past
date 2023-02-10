using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnWarning;

    public BoxCollider2D spawnArea;
    [SerializeField] float maxCountdown;
    [SerializeField] float spawnRate;
    [SerializeField] float nextSpawn;
    [SerializeField] float countdown;

    private void Start()
    {
        countdown = maxCountdown;

    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        Debug.Log(Time.timeSinceLevelLoad);
        //if (Time.time > nextSpawn)
        if(countdown<=0)
        {
            Vector3 spawnPoint = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );
            Instantiate(spawnWarning, spawnPoint, Quaternion.identity);
            StartCoroutine(SpawnWithDelay(spawnPoint));

            countdown = maxCountdown - (Time.timeSinceLevelLoad / 300);

        }
    }

    private IEnumerator SpawnWithDelay(Vector3 spawnPoint)
    {
        yield return new WaitForSeconds(.2f);
        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
    }
}
