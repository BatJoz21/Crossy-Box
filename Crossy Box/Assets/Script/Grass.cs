using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Grass : Terrain
{
    [SerializeField] List<Tree> treePrefabs;
    [SerializeField, Range(0, 1)] float treeProbability;

    public void SetTreePercentage(float newProb)
    {
        this.treeProbability = Mathf.Clamp01(newProb);
    }

    public override void Generate(int size)
    {
        base.Generate(size);

        var limit = Mathf.FloorToInt((float)size / 2);
        var treeCount = Mathf.FloorToInt((float)size * treeProbability);

        List<int> emptyPosition = new List<int>();
        for (int i = -limit; i <= limit; i++)
        {
            emptyPosition.Add(i);
        }

        for (int i = 0; i < treeCount; i++)
        {
            // memilih posisi kosong secara random
            var randomIndex = Random.Range(0, emptyPosition.Count - 1);
            var pos = emptyPosition[randomIndex];

            // hapus posisi yang sudah dipilih
            emptyPosition.RemoveAt(randomIndex);

            Debug.Log(pos);
            SpawnRandomTree(pos);
            
        }

        SpawnRandomTree(-limit - 1);
        SpawnRandomTree(limit + 1);
    }

    private void SpawnRandomTree(int xPos)
    {
        // set pohon ditempat yang terpilih
        var randomIndex = Random.Range(0, treePrefabs.Count);
        var prefab = treePrefabs[randomIndex];

        var tree = Instantiate(
            prefab,
            new Vector3(xPos, 0, this.transform.position.z), 
            Quaternion.identity, 
            transform);

        tree.enabled = false;
        tree.enabled = true;
    }
}
