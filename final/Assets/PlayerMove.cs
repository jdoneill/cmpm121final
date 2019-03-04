using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    //player movement vars
    public CharacterController player;
    float speed;//speed of player
    float jump = 6;//height to jump on space
    bool doubleJump;
    bool singleJump;
    private Vector3 move;
    private Vector3 startPos;

    void Start()
    {//initialize stuff
        player = GetComponent<CharacterController>();
        doubleJump = true;
        singleJump = true;
        speed = 6;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lava")//if the player dies
        {
            //Make a game over screen w/ restart and quit insted of hard reset
            Debug.Log("It BuRnS!!!");
            SceneManager.LoadScene("startMenu");//restart level

        }
    }

    private void FixedUpdate()
    {
        float gravMod = (player.isGrounded) ? 0 : 1.2f;
        float yVel = move.y;//store y velocity for jump/gravity

        if (player.isGrounded)
        {
            speed = 6;
            move.y = 0;
            doubleJump = true;
            singleJump = true;
        }


        move = (transform.forward * Input.GetAxis("Vertical")) //move logic inputs
             + (transform.right * Input.GetAxis("Horizontal")
             );

        move = move.normalized * speed;// make it so you can't game the game
        move.y = yVel;// maintain y velocity

        if (singleJump && doubleJump && Input.GetKeyDown(KeyCode.Space))//press space to jump
        {
            move.y = jump * .75f;//hippity hop
            singleJump = false;
        }
        else if (!singleJump && doubleJump && Input.GetKeyDown(KeyCode.Space))//double jump chump
        {
            move.y = jump;//hippity hop
            doubleJump = false;
        }

        move.y = move.y + (Physics.gravity.y * Time.deltaTime * gravMod);//add gravity
        player.Move(move * Time.deltaTime);//move the player

    }
}
