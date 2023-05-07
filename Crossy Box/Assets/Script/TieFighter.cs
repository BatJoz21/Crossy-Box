using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieFighter : MonoBehaviour
{
    [SerializeField, Range(0, 1)] float speed;
    [SerializeField] Duck targetDuck;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
