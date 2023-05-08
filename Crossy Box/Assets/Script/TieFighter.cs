using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TieFighter : MonoBehaviour
{
    [SerializeField, Range(0, 50)] float speed = 25;
    [SerializeField] Duck targetDuck;

    [SerializeField] UnityEvent tieFly;

    void Update()
    {   
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        tieFly.Invoke();
    }
}
