using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    public bool sphereIsOntheground = true;

    public GameObject Level2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }



    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }

    public void Level22()
    {
        if (count==1)
        {
             gameObject.SetActive(true);
        }
       
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && sphereIsOntheground)
        {
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            sphereIsOntheground = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Level2")
        {
            sphereIsOntheground = true;
        }
    }



    public void Respawn()
    {
        transform.position = new Vector3(0f, 0.5f, 0f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    } 
}
