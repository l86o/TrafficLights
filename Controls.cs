using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;

    public class Item
    {
        public string itemName;
    }

    public List<Item> inventory = new List<Item>();
    private bool inventoryOpen = false;

    private GameObject heldObject = null; // what we're grabbing

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move left/right
        float moveInput = 0f;
        if (Input.GetKey(KeyCode.A)) moveInput = -1f;
        else if (Input.GetKey(KeyCode.D)) moveInput = 1f;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jump with W or Space
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Flip sprite
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Inventory toggle with I
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryOpen = !inventoryOpen;
            Debug.Log(inventoryOpen ? "Inventory Opened" : "Inventory Closed");
            // Add actual UI show/hide logic here
        }

        // Grab action with G
        if (Input.GetKeyDown(KeyCode.G))
        {
            TryGrab();
        }
    }

    private void TryGrab()
    {
        if (heldObject == null)
        {
            // Find nearby object to grab
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Grabbable"))
                {
                    heldObject = hit.gameObject;
                    heldObject.transform.SetParent(transform);
                    heldObject.transform.localPosition = new Vector3(1, 0, 0); // adjust as needed
                    Debug.Log("Grabbed " + heldObject.name);
                    break;
                }
            }
        }
        else
        {
            // Release object
            heldObject.transform.SetParent(null);
            heldObject = null;
            Debug.Log("Released object");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
    