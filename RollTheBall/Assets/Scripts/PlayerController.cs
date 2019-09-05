using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;


    private int pickupsCounter;
    private Rigidbody rb;


    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        pickupsCounter = 0;
        countText.text = "Count: " + pickupsCounter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Update is called before physics calculation
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            pickupsCounter++;
            countText.text = "Count: " + pickupsCounter.ToString();
        }
    }
}
