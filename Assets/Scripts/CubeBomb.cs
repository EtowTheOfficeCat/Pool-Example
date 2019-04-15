using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBomb : MonoBehaviour
{
    [SerializeField] private Rigidbody cubePrefab;
    [SerializeField] private float spawnInterval = 0.5f;
    private CubePool pool;

    private float timer;

    private void Start()
    {
        pool = GameObject.Find("CubePool").GetComponent<CubePool>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer>= spawnInterval)
        {
            timer = 0f;
            Rigidbody rb = pool.GetNext(transform.position, Quaternion.identity);
            rb.AddForce(Random.insideUnitSphere * 20f, ForceMode.Impulse);
        }
    }
}
