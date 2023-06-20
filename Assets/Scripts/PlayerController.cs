using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    private float movementHorizontal;
    private float movementVertical;
    
    // Start is called before the first frame update
    void Start()
    {
        Console.Write("Start");
        rb = GetComponent<Rigidbody>();
        count = 0;
        
        SetCountText();
        winTextObject.SetActive(false);
    }

    // void OnMove(InputValue movementValue)
    // {
        // Vector2 movementVector = movementValue.Get<Vector2>();
        //
        // movementX = movementVector.x;
        // movementY = movementVector.y;
    // }

    void FixedUpdate()
    {
        Console.Write("FixedUpdate");
        movementHorizontal = Input.GetAxisRaw("Horizontal");
        movementVertical = Input.GetAxisRaw("Vertical");
        
        // Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        Vector3 movement = new Vector3(movementHorizontal, 0, movementVertical);
        
        rb.AddForce(movement * speed, ForceMode.Impulse);
    }

    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            
            SetCountText();
        }
    }
}
