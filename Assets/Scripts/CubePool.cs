using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    [SerializeField] private Rigidbody cubePrefab;
    [SerializeField] private int maxCapacity = 24;
    private Stack<Rigidbody> cubes;

   void Awake()
    {
        cubes = new Stack<Rigidbody>(maxCapacity);
        for (int i = 0; i < 24; i++)
        {
            Rigidbody rb = Instantiate(cubePrefab);
            rb.gameObject.SetActive(false);
            cubes.Push(rb);
            rb.GetComponent<DeathTimer>().Pool = this;
        }
    }

    public Rigidbody GetNext(Vector3 pos, Quaternion rot)
    {
        Rigidbody rb;
        if(cubes.Count!= 0)
        {
            rb = cubes.Pop();
            
        }
        else 
        {
            rb = Instantiate(cubePrefab);
            rb.GetComponent<DeathTimer>().Pool = this;
        }
        rb.transform.position = pos;
        rb.transform.rotation = rot;
        rb.gameObject.SetActive(true);
        return rb;
    }

    public void ReturnToPool(Rigidbody rb)
    {
        rb.gameObject.SetActive(false);
        cubes.Push(rb);
    }
}
