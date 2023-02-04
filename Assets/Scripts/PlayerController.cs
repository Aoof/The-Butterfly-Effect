using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    private float playerVelocity;
   
    // Update is called once per frame
    void Update()
    {
        playerVelocity = Input.GetAxis("x");
        System.Console.WriteLine(playerVelocity);
        //transform.position = new Vector2(transform.position.x + playerVelocity, transform.position.y);
    }
}
