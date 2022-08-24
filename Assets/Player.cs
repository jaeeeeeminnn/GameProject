using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveX;

    Rigidbody2D rb;

    [Header("이동속도 조절")]
    [SerializeField] [Range(100f, 800f)] float moveSpeed = 200f;

    [Header("점프 강도")]
    [SerializeField] [Range(100f, 800f)] float jumpForce = 400f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //이동
        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector2(moveX, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.velocity.y == 0)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
            }
        }


    }
}
