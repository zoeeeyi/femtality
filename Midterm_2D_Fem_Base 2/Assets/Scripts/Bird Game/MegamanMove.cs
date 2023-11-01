using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegamanMove : MonoBehaviour
{

//public allows you to change the value in the inspector
    public int speed = 5;
    public int jumpForce = 30; 
  //iFrames are windows of time in which your character cannot be hurt, e.g. if it's powering up or has already been shot 
    public float recoveryTime = .3f; //these are iFrames
    public bool hurt = false; 

//to check which direction we're facing 
    private int dir = 1; 

//will tell you if you're touching ground
    public bool grounded;

    public LayerMask ground;

    public Transform feet;


    Rigidbody2D rb;

    Animator anim;

    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xSpeed = -speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            xSpeed = speed;
        }

        if (!hurt)
        {
            rb.velocity = new Vector2(xSpeed, rb.velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(xSpeed));
        }

        if ((xSpeed < 0 && transform.localScale.x > 0) || (xSpeed > 0 && transform.localScale.x < 0))
        {
            transform.localScale *= new Vector2(-1, 1);
            dir *= -1;
        }

        //stops your movement when you're hurt 
        if (!hurt){
//need rb.velocity.y; if you just do 0 it reloads to 0 at each frame so is super slow
      rb.velocity = new Vector2(xSpeed, rb.velocity.y);  
      //This is saying take my xSpeed value and set it to my parameter which decides which animation to trigger
      //Need Abs value of xSpeed to make sure it runs left, otherwise it just goes right not left (if you just have xSpeed as 2nd parameter)
      anim.SetFloat("Speed", Mathf.Abs(xSpeed));
      }
      

/*
//This method only works if character is scaled at 1 -> need multiplier so that you can adjust within inspector
//Instead of = new Vector 2(x,y), we need multiplier *= new Vector 2(x,y)
    If(xSpeed < 0 && transform.localScale.x > 0)
    {
//we change x to -1 to flip the sprite to get it to look in opposite direction
    transform.localScale *= new Vector2(-1,1);
    }
    //Need another statement to make it flip back to the original direction when you move right,
    //otherwise it just flips once and then stays flipped.
     If(xSpeed > 0 && transform.localScale.x < 0)
    {
    transform.localScale *= new Vector2(-1,1);
    }
    */

    //More efficient way of flipping method above
    //Basically method = if you're facing wrong direction, flip. Multiply your scale by -1 in each case
    if (xSpeed < 0 && transform.localScale.x > 0 ||xSpeed > 0 && transform.localScale.x < 0 )
    {
      transform.localScale *= new Vector2(-1,1);
      dir *= -1;
    }

    //1st variable is where you're starting to draw circle, 2nd is radius (aka height of your sprite), 3rd is layermask
    grounded = Physics2D.OverlapCircle(feet.position, .3f, ground);
    anim.SetBool("Grounded", grounded);
      if(Input.GetKey(KeyCode.RightShift) && grounded)
      {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpForce)); 
      }

//To control shooting; Fire1 is a preset which maps to mouse click
  if(Input.GetButtonDown("Fire1"))
  {
    anim.SetTrigger("Shoot");
  }
    }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if(other.gameObject.CompareTag("Enemy") && !hurt)
    {
        StartCoroutine(IFrames());
    }
  }

  //Need coroutine to bring us back to normal state from hurt state 
  IEnumerator IFrames()
  {
    hurt = true;
    anim.SetBool("Hurt", hurt);
    //rb.AddForce to add throwback when character is hurt 
    rb.AddForce(new Vector2(dir * -200, 100));
    //Add color to show hurt, color is in RGB
    rend.color = new Color (1, .5f, .5f);
    yield return new WaitForSeconds(recoveryTime);
    hurt = false;
    anim.SetBool("Hurt", hurt);
    //Color.white is just default that will return character to normal color
    rend.color = Color.white;
  }

}
