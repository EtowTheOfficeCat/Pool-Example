using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] float lifeSpan = 1.5f;
    private float timer;
    private CubePool pool;
    public CubePool Pool
    {
        set { pool = value; }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifeSpan)
        {
            timer = 0;
            pool.ReturnToPool(GetComponent<Rigidbody>());
        }
    }
}
