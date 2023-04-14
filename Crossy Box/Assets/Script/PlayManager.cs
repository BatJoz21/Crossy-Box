using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] Grass grassPrefabs;
    [SerializeField] Road roadPrefabs;
    [SerializeField] int initialGrassCount = 5;
    [SerializeField] int horizontalSize;
    [SerializeField] int backViewPos = -5;
    [SerializeField] int forwardViewPos = 15;
    [SerializeField, Range(0, 1)] float treeProbability;

    void Start()
    {
        for (int zPos = backViewPos; zPos < initialGrassCount; zPos++)
        {
            var grass = Instantiate(grassPrefabs);
            grass.transform.position = new Vector3(0, 0, zPos);
            grass.SetTreePercentage(zPos < -1 ? 1 : 0);
            grass.Generate(horizontalSize);
        }

        for (int zPos = initialGrassCount; zPos < forwardViewPos; zPos++)
        {
            var terrain = Instantiate(roadPrefabs);
            terrain.transform.position = new Vector3(0, 0, zPos);
            terrain.Generate(horizontalSize);
        }
    }

    void Update()
    {
        
    }
}
