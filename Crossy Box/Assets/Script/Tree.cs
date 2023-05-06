using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour
{
    static List<Vector3> positionsSet = new List<Vector3>();

    //public static HashSet<Vector3> AllPositions { get => new HashSet<Vector3>(positionsSet); }
    public static List<Vector3> AllPositions { get => positionsSet; }

    private void OnEnable()
    {
        if (AllPositions.Contains(this.transform.position))
        {
            return;
        }
        positionsSet.Add(this.transform.position);
        Debug.Log(this.transform.position);
    }

    private void OnDisable()
    {
        positionsSet.Remove(this.transform.position);
    }
}