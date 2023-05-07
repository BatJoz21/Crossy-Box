using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIESpawner : MonoBehaviour
{
    [SerializeField] TieFighter tfPrefab;
    [SerializeField] Duck duck;
    [SerializeField] float initialTimer;
    float timer;

    void Start()
    {
        timer = initialTimer;
        tfPrefab.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if (timer <= 0 && tfPrefab.gameObject.activeInHierarchy == false)
        {
            tfPrefab.gameObject.SetActive(true);
            tfPrefab.transform.position = duck.transform.position + new Vector3(0, 0, 13);
            duck.SetMoveable(false);
        }
        timer -= Time.deltaTime;
    }

    public void ResetTimer()
    {
        timer = initialTimer;
    }
}
