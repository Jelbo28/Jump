using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    float jumpForce;
    [SerializeField]
    float jumpWait;

    Rigidbody rbody;
    private bool onGround;
    private float jumpLock;
    private int spacePressed;
    private DisplayManager displayManager;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
        displayManager = GameObject.FindObjectOfType<DisplayManager>();
	}
	
	// Update is called once per frame
	void Update () {

        Jump();
		
	}

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpLock <= 0)
        {
            rbody.AddForce(Vector3.up * jumpForce);
            jumpLock = jumpWait;
            spacePressed++;
        }

        if (jumpLock > 0)
        {
            jumpLock -= Time.deltaTime;
        }
        else
        {
            jumpLock = 0;
        }
    }

    void CheckObjective()
    {
        if (spacePressed > 0 && onGround)
        {
            displayManager.mainText.text = "Good job!";
            Debug.Log("Winning!");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("joe");
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
            CheckObjective();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}
