using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour

{
    public float charScale = 0.33f;// reference this to the scale being used in the transform section for the character (default)

    private float horizontal; //horizontal input
    private float vertical; //vertical input

    [SerializeField] private PlayerStats playerStats;
    private PlayerData playerData;
    [SerializeField] private Weapon weaponScript;
    private float speed = 20f; //affects horizontal movement
    private float fixTargetSpeed = 2f;
    [SerializeField] private float fixAccelRate = 6f; //rate of acceleration
    [SerializeField] private float airborneDampening = 0.8f; //rate of acceleration dampening airborne

    [SerializeField] private float apexJumpModifier = 1.6f; //changes how much acceleration and max speed changes whilst at apex of jump
    [SerializeField] private float apexJumpThreshold = 7f;//changes threshold for what counts as jump apex


    private float fallingStrength = -1f;
    private bool isFacingRight = true;


    //DASHING GLOBAL VARIABLES
    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 150f;
    [SerializeField] private float dashingTime = 0.2f;


    [SerializeField] private Rigidbody2D rb; //rb for rigid body 2d reference to component
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioSource downSoundEffect;

    [SerializeField] private TrailRenderer tr;
    [SerializeField] private ParticleSystem pSyst;


    public Transform Player; //referencing Player Inspector values
    // Start is called before the first frame update

    void Start()
    {
        playerData = GameObject.Find("Player2Data(Clone)").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isDashing) //prevents additional movement options
        { return; }

        if (IsGrounded()) //doubleJumps
        {
            playerStats.currentJumps = playerData.numberJumps;
        }

        fixTargetSpeed = playerStats.speed;

        rotateBack();

        horizontal = Input.GetAxisRaw("Horizontal2"); //returns -1, 0 or 1 depending on direction moving (button dependent)
        vertical = Input.GetAxisRaw("Vertical2");



        if (Input.GetButtonDown("Jump2") && playerStats.currentJumps > 0 || Input.GetButtonDown("Jump2") && IsGrounded() || Input.GetButtonDown("Jump2") && playerStats.canFly)//when jump button pressed and on ground (GO TO EDIT -> PROJECT SETTINGS -> INPUT MANAGER TO SEE WHAT VALUES ARE WHAT)
        {
            rb.velocity = new Vector2(rb.velocity.x, playerStats.jumpingPower + playerStats.speed * 0.01f); //y velocity changes
            playerStats.currentJumps -= 1;
        }

        if (Input.GetButtonUp("Jump2") && rb.velocity.y > 0f)
        {//release up button whilst still in air, jump higher vs jump lower
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f + playerStats.speed * 0.01f);
        }

        if (vertical == -1 && playerData.slamUnlocked && !IsGrounded())
        {

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + fallingStrength);
            downSoundEffect.Play();
        }



        //DASHING
        if (Input.GetButtonDown("Dash2") && canDash && playerData.dashUnlocked)
        {
            StartCoroutine(Dash());
        }


        Squeeze();
        Flip();

    }
    private void FixedUpdate() //used for physics calculations (same frequency as physics system)
    {


        if (isDashing) //prevents additional movement options
        { return; }


        //HORIZONTAL VELOCITY, utilises acceleration, more eased and less robotic movement. 

        float accelRate = fixAccelRate;
        float targetSpeed = playerStats.speed;

        //APEX OF JUMP CHANGES MIGHT MAKE INTO A FUNCTION
        if (!IsGrounded() && Mathf.Abs(rb.velocity.y) < apexJumpThreshold)
        {
            accelRate = accelRate * apexJumpModifier;  //changes acceleration at apex of jump
            targetSpeed = targetSpeed * apexJumpModifier;
        }

        //DAMPENING OF ACCELERATION WHEN AIRBORNE
        if (!IsGrounded())
        {
            accelRate = accelRate * airborneDampening; //if the character is airbone, decrease acceleration
        }
        else
        {
            accelRate = fixAccelRate; //original accelRate
        }


        float speedDif = (targetSpeed * horizontal - rb.velocity.x); //speedDif increases as rb.velocity.x decreases
        float movement = speedDif * accelRate; //the slower the current velocity, the greater the movement

        //rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        rb.AddForce(movement * Vector2.right);



        //VERTICAL VELOCITY

        if (!IsGrounded())
        {
            //CLAMPING VERTICAL VELOCITY WHEN GOING DOWN I.E. FORCES A MAX VERTICAL VELOCITY DOWNWARDS
            if (rb.velocity.y <= -12f) //may make global variables out of drag value and y threshol
            { rb.drag = 20f; } //uses drag, higher value means object slows down more
            else
            { rb.drag = 0f; }

            //HANG TIME, INCREASE UPWARDS FORCE
            if (Mathf.Abs(rb.velocity.y) <= 2f)
            {
                rb.AddForce(5f * Vector2.up);
            }
        }


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



    // public GameObject Blade1; //referencing the Blade Object's weapon script
    // private Weapon weaponScript;
    private void Flip() //flip and squeeze sprite model
    {
        //weaponScript = Blade1.GetComponent<Weapon>();
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
        float squeezeSoften = 0.7f; //softening constant to affect HOW MUCH the player squeezes
        float leeWay = 0.1f; //leeway for Squeeze method, value of y can change a certain amount past its limit and the localScale will still change 


        Vector3 localScale = transform.localScale;
        if (horizontal != 0) //only changes when moving
        {
            //0.4f is dependent on the player's x scale value, if you change that, change this accordingly
            localScale.x = (horizontal * charScale) / ((speed + Mathf.Abs(rb.velocity.x) * squeezeSoften) / speed);
            //scale.x = 1 - 1 / (SPEED - Math.abs(velocity.x)*softeningConstant) / SPEED;
        }
        else
        {
            if (isFacingRight)
            { localScale.x = charScale; }
            else
            { localScale.x = -charScale; }
        }

        localScale.y = charScale / (1 + 0.05f * rb.velocity.y);
        if (Mathf.Abs(localScale.y) <= charScale + leeWay && Mathf.Abs(localScale.x) <= charScale + leeWay)
        { //can only can be as wide as the initial width and height
            transform.localScale = localScale;
        }

    }

    private IEnumerator Dash() //interface to control coroutine execution over a period of time, custom iterations
    {

        tr = Player.GetComponent<TrailRenderer>(); //change trail effect
        Color origStartColor = tr.startColor;
        Color origEndColor = tr.endColor;
        tr.emitting = true;
        tr.startColor = new Color(255, 0, 0);
        tr.endColor = new Color(200, 80, 80, 0);

        canDash = false;
        isDashing = true;
        float origGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        //rb.AddForce(horizontal * 2f* dashingPower * Vector2.right);
        rb.velocity = new Vector2(horizontal * 0.5f * dashingPower, rb.velocity.y);
        if (vertical != 1)
        // rb.AddForce(vertical * 0.8f * dashingPower * Vector2.up);
        { rb.velocity = new Vector2(rb.velocity.x, vertical * 0.3f * dashingPower); }
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        rb.gravityScale = origGravity;
        yield return new WaitForSeconds(0.4f);
        tr.startColor = origStartColor;//revert back color of trail
        tr.endColor = origEndColor;
        tr.emitting = false;
        rb.gravityScale = origGravity;
        yield return new WaitForSeconds(playerStats.dashCooldown);
        tr.startColor = origStartColor;//revert back
        tr.endColor = origEndColor;
        rb.gravityScale = origGravity;
        canDash = true;
    }
}



