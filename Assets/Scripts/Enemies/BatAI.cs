using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatAI : MonoBehaviour
{

    private float speed = 2f; //f means force using Unity's gravity system
    private bool isAwake = false; 
    private Vector2 moveDirection; // displacement from player

    [SerializeField] private Rigidbody2D rb; //rb for rigid body 2d reference to component
    [SerializeField] private Rigidbody2D playerRb; //rb for rigid body 2d reference to component


    public Transform bat; //referencing bat Inspector values
    public Transform player; //referencing player Inspector values
    public Collider2D batCollider;
    public Collider2D playerCollider;
    // Start is called before the first frame update
 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    private void FixedUpdate() //used for physics calculations (same frequency as physics system)
    {

        if(player.position.y <= bat.position.y){ //checks if player is below bat
            isAwake = true; //wakes up bat
        }

        if(!isAwake){ // guard clause to check if bat is awake
            return;
        }

        moveDirection = player.position - bat.position; // sets moveDirection to displacement from player
        rb.velocity = moveDirection.normalized*speed;// sets velocity to have the a direction of the move direction and a magnitude of the speed of the bat

        if(IsTouchingPlayer()){
             //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
             Destroy(gameObject);
        }
    }

    private bool IsTouchingPlayer() //checks if bat is touching player
    {
       return playerCollider.IsTouching(batCollider);
    }

}

