using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public GameObject egg;
    public float minLayEggTime = 2f;
    public float maxLayEggTime = 5f;
    private float nextLayEggTime;
    void Start()
    {
        // Initialize the next egg laying time
        nextLayEggTime = Time.time + UnityEngine.Random.Range(minLayEggTime, maxLayEggTime);
    }

    void Update()
    {
        if (Time.time >= nextLayEggTime)
        {
            Instantiate(egg, transform.position, Quaternion.identity);
            nextLayEggTime = Time.time + Random.Range(minLayEggTime, maxLayEggTime);
        }
    }
}
