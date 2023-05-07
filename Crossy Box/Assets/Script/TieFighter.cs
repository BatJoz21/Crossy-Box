using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieFighter : MonoBehaviour
{
    [SerializeField, Range(0, 50)] float speed = 25;
    [SerializeField] Duck targetDuck;

    void Update()
    {   
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
