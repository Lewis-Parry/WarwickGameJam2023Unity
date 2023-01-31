using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal; //horizontal input
    private float speed = 8f; //f means force using Unity's gravity system
    private float jumpingPower = 20f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb; //rb for rigid body 2d reference to component
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Transform Player; //referencing Player Inspector values
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

         if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        rotateBack();

        horizontal = Input.GetAxisRaw("Horizontal"); //returns -1, 0 or 1 depending on direction moving (button dependent)

        if (Input.GetButtonDown("Jump") && IsGrounded())//when jump button pressed and on ground (GO TO EDIT -> PROJECT SETTINGS -> INPUT MANAGER TO SEE WHAT VALUES ARE WHAT)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); //y velocity changes
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {//release up button whilst still in air, jump higher vs jump lower
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


        Squeeze();
        Flip();


    }
    private void FixedUpdate() //used for physics calculations (same frequency as physics system)
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded() //for ground detection
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);//creates an invisible circle at players feet, if this circle collides with groundLayer then the player can then jump 
    }




    float Rotation;
    private void rotateBack() //rotates the player back to upright position
    {

        if (Player.eulerAngles.z <= 180f)  //finding the Player's current rotationa
        { Rotation = Player.eulerAngles.z; }
        else { Rotation = Player.eulerAngles.z - 360f; }

        float origGrav = Player.GetComponent<Rigidbody2D>().gravityScale;
        if (Rotation >= 45 || Rotation <= -45)
        {
            Player.GetComponent<Rigidbody2D>().gravityScale = 0.0f; transform.Rotate(new Vector3(0, 0, -Rotation / 4)); Player.GetComponent<Rigidbody2D>().gravityScale = origGrav;
        }
        if (IsGrounded())//only occurs when on ground
        {
            if (Rotation >= 34 || Rotation <= -34)
            { Player.GetComponent<Rigidbody2D>().gravityScale = 0.0f; transform.Rotate(new Vector3(0, 0, -Rotation / 2)); Player.GetComponent<Rigidbody2D>().gravityScale = origGrav; }
            else if (Rotation >= 17 || Rotation <= -17)
            { Player.GetComponent<Rigidbody2D>().gravityScale = 0.0f; transform.Rotate(new Vector3(0, 0, -Rotation / 2)); Player.GetComponent<Rigidbody2D>().gravityScale = origGrav; }
            else if (Rotation >= 9 || Rotation <= -9)
            { Player.GetComponent<Rigidbody2D>().gravityScale = 0.0f; transform.Rotate(new Vector3(0, 0, -Rotation / 2)); Player.GetComponent<Rigidbody2D>().gravityScale = origGrav; }
            else if (Rotation >= 5 || Rotation <= -5)
            { Player.GetComponent<Rigidbody2D>().gravityScale = 0.0f; transform.Rotate(new Vector3(0, 0, -Rotation / 2)); Player.GetComponent<Rigidbody2D>().gravityScale = origGrav; }
            else if (Rotation >= 3 || Rotation <= -3)
            { Player.GetComponent<Rigidbody2D>().gravityScale = 0.0f; transform.Rotate(new Vector3(0, 0, -Rotation / 2)); Player.GetComponent<Rigidbody2D>().gravityScale = origGrav; }

        }
    }




    private void Flip() //flip and squeeze sprite model
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;  //multiples Player's x component by -1
            transform.localScale = localScale; //applies transformation
        }

    }

    private void Squeeze()
    {
        Vector3 localScale = transform.localScale;
        if (horizontal != 0) //only changes when moving
        {
            localScale.x = (-horizontal * 0.4f) / (1 - 0.28f * Mathf.Abs(rb.velocity.x)); //0.4f is dependent on the player's x scale value, if you change that, change this accordingly
            //scale.x = 1 - 1 / (SPEED - Math.abs(velocity.x)) / SPEED;
        }
        else
        {
            if (isFacingRight)
            {localScale.x = 0.4f;}
            else
            {localScale.x = -0.4f;}
        }

        localScale.y = 0.4f / (1 + 0.05f * rb.velocity.y);
        if (Mathf.Abs(localScale.y) <= 0.4f && Mathf.Abs(localScale.x) <= 0.4f) { //can only can be as wide as the initial width and height
            transform.localScale = localScale;
        }

    }

}

