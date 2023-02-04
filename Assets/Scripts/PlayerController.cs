using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    private float playerVelocity;
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {    

        playerVelocity = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveSpeed * playerVelocity, 0);

        if (playerVelocity != 0)
        {
            GetComponent<SpriteRenderer>().flipX = playerVelocity < 0;
        }
        playerAnimator.SetBool("Moving", playerVelocity != 0);

        transform.Translate(movement * Time.deltaTime);
    }
}
