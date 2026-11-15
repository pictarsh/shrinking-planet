using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawnerScripts : MonoBehaviour
{
    public GameObject meteor;
    public float distance;

    void Start()
    {
        StartCoroutine(SpawnMeteror());
    }

    IEnumerator SpawnMeteror()
    {
        Vector3 position = Random.onUnitSphere * distance;
        Instantiate(meteor, position, Quaternion.identity);

        yield return new WaitForSeconds(Random.Range(1, 3));
        StartCoroutine(SpawnMeteror());
    }
}
