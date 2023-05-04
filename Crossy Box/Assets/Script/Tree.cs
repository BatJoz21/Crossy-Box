using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour
{
    static HashSet<Vector3> positionsSet = new HashSet<Vector3>();

    public static HashSet<Vector3> AllPositions { get => new HashSet<Vector3>(positionsSet); }

    private void OnEnable()
    {
        positionsSet.Add(this.transform.position);
        Debug.Log(this.transform.position);
    }

    private void OnDisable()
    {
        positionsSet.Remove(this.transform.position);
    }
}