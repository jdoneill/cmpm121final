using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    //player movement vars
    public CharacterController player;
    public GameObject UserInterface;
    public GameObject gameOver;
    float speed;//speed of player
    float jump = 6;//height to jump on space
    bool doubleJump;
    bool singleJump;
    private bool wallJumped;
    private Vector3 move;
    private Vector3 startPos;
    public Text gameFinished;
    //public float wallJumpTime = 10;
    //private float walJumpCounter;

    void Start()
    {//initialize stuff
        player = GetComponent<CharacterController>();
        doubleJump = true;
        singleJump = true;
        wallJumped = false;
        speed = 8;
        UserInterface.GetComponent<Canvas>().enabled = true;
        gameOver.GetComponent<Canvas>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;// no cursor during gameplay
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lava")//if the player hits lava - GAME OVER
        {
            UserInterface.GetComponent<Canvas>().enabled = false;//turn off UI
            gameOver.GetComponent<Canvas>().enabled = true;      //turn on gameover
            Time.timeScale = 0;//freeze time
            Cursor.lockState = CursorLockMode.None;// make the mouse usable

        }
        else if (other.tag == "Finish")//if the player hits lava - GAME OVER
        {
            UserInterface.GetComponent<Canvas>().enabled = false;//turn off UI
            gameOver.GetComponent<Canvas>().enabled = true;      //turn on gameover
            Time.timeScale = 0;//freeze time
            Cursor.lockState = CursorLockMode.None;// make the mouse usable
            gameFinished.text = "Level Complete!";

        }
    }

    private void FixedUpdate()
    {
        float gravMod = (player.isGrounded) ? 0 : 1.2f;
        float yVel = move.y;//store y velocity for jump/gravity

        if (player.isGrounded)
        {
            //speed = 8;
            move.y = 0;// this may be unnecessary
            doubleJump = true;
            singleJump = true;
            wallJumped = false;
        }

        if(!wallJumped){//maintain velocity after jumping off wall

        move = (transform.forward * Input.GetAxis("Vertical")) //move logic inputs
             + (transform.right * Input.GetAxis("Horizontal")
             );

        }

        /*
        else
        {
            walJumpCounter -= Time.deltaTime;
        }
        */

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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!player.isGrounded)
        {
            //doubleJump = true;
            //singleJump = true;
            
            if (Input.GetKeyDown(KeyCode.Space))//press space to wall jump
            {
                wallJump(hit.normal);
            }
            
        }    
    }

    private void wallJump(Vector3 dir)//wall jump logic
    {

        //walJumpCounter = wallJumpTime;
        wallJumped = true;
        dir = dir.normalized;
        dir.y = 0;//remove jump so we can add it later

        move = ((player.transform.forward * Input.GetAxis("Vertical"))//move forward if input
                + dir);//bounce away from the wall
        move.y = jump;//hippity hop

    }
}
