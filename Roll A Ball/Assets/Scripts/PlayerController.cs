using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rigidBody;
    public float speed;

    private int score;
    public Text winText;
    public Text scoreText;

    // Use this for initialization.Called on the first frame when script is active.
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        score = 0;
        winText.text = "";
        updateScore();

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Input.acceleration.x, 0 , Input.acceleration.z);
    }

    // Called before making any physics calculations.So most of the physics code is present in this method.
    void FixedUpdate()
    {

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        //rigidBody.AddForce(movement * speed);
        //transform.Translate(Input.acceleration.x, 0, Input.acceleration.z);
        Vector3 movement = new Vector3(Input.acceleration.x, 0, -Input.acceleration.z);
        rigidBody.AddForce(movement  * speed);


    }

    // called everytime when the player touches a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            updateScore();
        }
    }

    private void updateScore()
    {
        scoreText.text = "Score:" + score.ToString();
        if (score >=13 )
        {
            winText.text = "You Win";
        }
    }
}
