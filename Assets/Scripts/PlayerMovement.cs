using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7.0f;
    [Range(0.0f, 10.0f)]
    public float jumpForce = 2.0f;

    internal bool isJumping = false;
    internal float resetPosition = -3.0f;
    internal Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        // Jump
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            Jump();
        }


        // Reset Posição ao cair
        if (transform.position.y < resetPosition)
        {
            Invoke(nameof(ResetPosition), 1f);
        }

    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVerical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVerical);
        rb.AddForce(movement * speed);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }

    private void ResetPosition()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Box")
        {
            isJumping = false;
        }
    }
}
