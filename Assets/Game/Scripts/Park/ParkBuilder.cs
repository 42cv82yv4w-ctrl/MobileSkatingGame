using System.Collections.Generic;
using UnityEngine;

public class ParkBuilder : MonoBehaviour
{
    [Header("Ground")]
    public GameObject groundPrefab;
    public Vector3 parkSize = new Vector3(200f, 1f, 200f);

    [Header("Ramps")]
    public GameObject rampPrefab;
    public int numberOfRamps = 12;

    [Header("Drops")]
    public GameObject dropPrefab;
    public int numberOfDrops = 8;

    [Header("Rails")]
    public GameObject railPrefab;
    public int numberOfRails = 10;

    [Header("Decor")]
    public GameObject[] props;

    private readonly List<GameObject> spawnedObjects = new List<GameObject>();

    private void Start()
    {
        BuildBasePark();
        SpawnRamps();
        SpawnDrops();
        SpawnRails();
        SpawnDecor();
    }

    private void BuildBasePark()
    {
        if (groundPrefab == null)
        {
            Debug.LogWarning("ParkBuilder: groundPrefab is not assigned.");
            return;
        }

        GameObject ground = Instantiate(groundPrefab, transform);
        ground.transform.localScale = parkSize;
        ground.transform.position = Vector3.zero;
        ground.name = "MegaParkGround";
        spawnedObjects.Add(ground);
    }

    private void SpawnRamps()
    {
        if (rampPrefab == null) return;

        for (int i = 0; i < numberOfRamps; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-80f, 80f),
                0.5f,
                Random.Range(-80f, 80f));

            Quaternion rot = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            GameObject ramp = Instantiate(rampPrefab, transform);
            ramp.transform.position = pos;
            ramp.transform.rotation = rot;
            ramp.name = "Ramp_" + i;
            spawnedObjects.Add(ramp);
        }
    }

    private void SpawnDrops()
    {
        if (dropPrefab == null) return;

        for (int i = 0; i < numberOfDrops; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-70f, 70f),
                0f,
                Random.Range(-70f, 70f));

            GameObject drop = Instantiate(dropPrefab, transform);
            drop.transform.position = pos;
            drop.name = "Drop_" + i;
            spawnedObjects.Add(drop);
        }
    }

    private void SpawnRails()
    {
        if (railPrefab == null) return;

        for (int i = 0; i < numberOfRails; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-75f, 75f),
                1.2f,
                Random.Range(-75f, 75f));

            Quaternion rot = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            GameObject rail = Instantiate(railPrefab, transform);
            rail.transform.position = pos;
            rail.transform.rotation = rot;
            rail.name = "Rail_" + i;
            spawnedObjects.Add(rail);
        }
    }

    private void SpawnDecor()
    {
        if (props == null || props.Length == 0) return;

        for (int i = 0; i < 40; i++)
        {
            GameObject prop = props[Random.Range(0, props.Length)];
            Vector3 pos = new Vector3(
                Random.Range(-90f, 90f),
                0f,
                Random.Range(-90f, 90f));

            Instantiate(prop, pos, Quaternion.identity, transform);
        }
    }
}
