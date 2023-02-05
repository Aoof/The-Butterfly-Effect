using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float boundary = 20f;
    public float yShift = -5.25f;
    public Transform[] playerBoundaries = { null, null };
    private float playerVelocity;
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.GetInstance().dialogueOn)
        {
            return;
        }
        playerVelocity = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveSpeed * playerVelocity, 0);

        if (playerVelocity != 0)
            GetComponent<SpriteRenderer>().flipX = playerVelocity < 0;

        playerAnimator.SetBool("Moving", playerVelocity != 0);

        transform.Translate(movement * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundary *-1, boundary), yShift, 0);

        if (playerBoundaries[0])
            playerBoundaries[0].position = new Vector3(boundary * -1, yShift);
        if (playerBoundaries[1])
            playerBoundaries[1].position = new Vector3(boundary, yShift);
    }
}
