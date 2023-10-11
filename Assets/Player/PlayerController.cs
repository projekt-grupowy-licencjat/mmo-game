using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private int velocity;

    private Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        velocity = 1; // Graphite test
        direction = Vector3.zero;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) direction += Vector3.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector3.right;
        if (Input.GetKey(KeyCode.W)) direction += Vector3.up;
        if (Input.GetKey(KeyCode.S)) direction += Vector3.down;
        
        transform.Translate(direction * (velocity * Time.deltaTime));
        direction = Vector3.zero;
    }
}
