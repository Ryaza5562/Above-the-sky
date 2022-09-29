using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] SpawnPoints;
    [SerializeField] private GameObject PlatformPrefab;
    [SerializeField] private float MinVerticalOffset = 0.5f;
    [SerializeField] private float MaxVerticalOffset = 1.5f;
    private float VerticalOffset;

    private float? LastPointPositionY = null;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Transform RandomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        VerticalOffset = Random.Range(MinVerticalOffset, MaxVerticalOffset);
        float SpawnPointPositionY = LastPointPositionY == null ? RandomSpawnPoint.position.y : (float)LastPointPositionY + VerticalOffset;

        RandomSpawnPoint.position = new Vector3(RandomSpawnPoint.position.x, SpawnPointPositionY, RandomSpawnPoint.position.z);
        LastPointPositionY = SpawnPointPositionY;

        Instantiate(PlatformPrefab, RandomSpawnPoint.position, Quaternion.identity);
    }
}
