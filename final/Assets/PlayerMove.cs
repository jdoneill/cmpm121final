using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private Vector3 move;
    private Vector3 startPos;
    public float wallJumpForce = 3;
    public float wallJumpTime = 1;
    private float walJumpCounter;

    void Start()
    {//initialize stuff
        player = GetComponent<CharacterController>();
        doubleJump = true;
        singleJump = true;
        speed = 6;
        UserInterface.GetComponent<Canvas>().enabled = true;
        gameOver.GetComponent<Canvas>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;// no cursor during gameplay
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lava")//if the player hits lava - GAME OVER
        {
            //Make a game over screen w/ restart and quit insted of hard reset
            UserInterface.GetComponent<Canvas>().enabled = false;
            gameOver.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;// make the mouse usable

        }
    }

    private void FixedUpdate()
    {
        float gravMod = (player.isGrounded) ? 0 : 1.2f;
        float yVel = move.y;//store y velocity for jump/gravity

        if (player.isGrounded)
        {
            speed = 6;
            move.y = 0;// this may be unnecessary
            doubleJump = true;
            singleJump = true;
        }

        if(walJumpCounter <= 0){

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

        
        }
        else{
            walJumpCounter -= Time.deltaTime;
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
        walJumpCounter = wallJumpTime;
        dir = dir.normalized;
        dir.y = 0;//remove jump so we can add it later

        move = ((player.transform.forward * Input.GetAxis("Vertical"))//move forward if input
                + dir) * wallJumpForce;//bounce away from the wall
        move.y = jump;//hippity hop


    }
}
