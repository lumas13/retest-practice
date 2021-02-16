using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    float dropSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3); //destory the game object after 3 seconds
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * -dropSpeed * Time.deltaTime; //drops the object
    }
    
}
