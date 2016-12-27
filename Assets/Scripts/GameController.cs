using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public CoffeeCup coffeeCupPrefab;
    public List<CoffeeCup> coffeeCups;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-10.0f, 10.0f),
                Random.Range(-10.0f, 10.0f),
                Random.Range(-10.0f, 10.0f));
            var randomRotation = Quaternion.Euler(
                Random.Range(0, 360),
                Random.Range(0, 360),
                Random.Range(0, 360));
            coffeeCups.Add(Instantiate(coffeeCupPrefab, randomPosition, randomRotation));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // FixedUpdate is called uniformly at fixed points in time (for physical forces)
    void FixedUpdate()
    {
        float centerOfMassX = 0f;
        float centerOfMassY = 0f;
        float centerOfMassZ = 0f;
        foreach (CoffeeCup coffeeCup in coffeeCups)
        {
            centerOfMassX += coffeeCup.transform.position.x;
            centerOfMassY += coffeeCup.transform.position.y;
            centerOfMassZ += coffeeCup.transform.position.z;            
        }
        centerOfMassX = centerOfMassX / (coffeeCups.Count);
        centerOfMassY = centerOfMassY / (coffeeCups.Count);
        centerOfMassZ = centerOfMassZ / (coffeeCups.Count);
        for (int i=0; i< coffeeCups.Count; i++ )
        {
            Rigidbody rb = coffeeCups[i].GetComponent<Rigidbody>();
            Vector3 force = new Vector3(
                ((centerOfMassX - coffeeCups[i].transform.position.x) / 10),
                ((centerOfMassY - coffeeCups[i].transform.position.y) / 10),
                ((centerOfMassZ - coffeeCups[i].transform.position.z) / 10));
            rb.AddForce(force);
        }
    }
}
