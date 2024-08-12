using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private bool canSpawn= true;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (true)
        {
            yield return wait;

            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
