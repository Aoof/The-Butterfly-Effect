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
        playerVelocity = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveSpeed * playerVelocity, 0);
        transform.Translate(movement * Time.deltaTime);
    }
}
