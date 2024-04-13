using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DevPlayerMovement_Tutorial : MonoBehaviour
{
    public static bool couldJump = false;
    public static bool couldShowJumpIns = false;
    public Transform final;
    public float tolerance = 1f;
    public Shadowing Shadowing;
    private float horizontal;
    public float speed = 6f;
    private float jumpingPower = 13f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public TextMeshProUGUI winGameText;
    public GameObject winGameObject;
    public GameObject jumpInstruction1;
    public GameObject jumpInstruction2;
    public GameObject jumpImage;

    //public GameObject scene1;
    //public GameObject scene2;
    private bool switchFlag = false;
    private bool keyPressed = false;
    
    private KeyCode disableKey = KeyCode.F;
    
    public float climbSpeed = 5f; // Climbing Speed
    
    private bool isClimbing = false; // Check is on climbing
    // public GameObject Win_UIObject;
    // public GameObject Ins_UIObject;

    // Start is called before the first frame update
    void Start()
    {
        // Win_UIObject.SetActive(false);
        PauseGameOnEnter_Tutorial.gamePause = false;
        Global.gamePause = false;

    }

    void Update() 
    {
        if(couldJump)
        {
            jumpInstruction1.SetActive(true); // give jump tips
            jumpInstruction2.SetActive(true); // give jump tips
            jumpImage.SetActive(true);
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded() && couldJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if(Input.GetButtonDown("Jump") && rb.velocity.y > 0f && couldJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        
        
        Switch();
        Climbing();
        //CheckIfLevelCompleted();
    }
    
    void Climbing()
    {
        if (isClimbing)
        {
            float inputVertical = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbSpeed);
        }
    }
    
    void Switch()
    {
        // Check if press the bottom
        if (Input.GetKeyDown(disableKey) && !keyPressed)
        {
            // According to switchFlag to switch scenes
            if (!switchFlag)
            {
                //scene1.SetActive(false);
                //scene2.SetActive(true);
                switchFlag = true;
            }
            else
            {
                //scene1.SetActive(true);
                //scene2.SetActive(false);
                switchFlag = false;
            }

            keyPressed = true; // Flag keyPressed
        }
        else if (Input.GetKeyUp(disableKey))
        {
            keyPressed = false; // Release keyPressed
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity= new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Door")
        {
            Debug.Log("You touched the door");
            // Win_UIObject.SetActive(true);
            // Ins_UIObject.SetActive(false);
            Time.timeScale = 0;
        }
        if (collision.tag == "Climbable") // tag is "Climbable"
        {
            Debug.Log("Ladder");
            isClimbing = true;
            rb.gravityScale = 0; // disable the graviry
        }
        
        
        if (collision.tag == "TimeGel")
        {
            Debug.Log("Hit Gel");
            Shadowing.gelFlag = 1;
        }
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Climbable")
        {
            isClimbing = false;
            rb.gravityScale = 4; // restore the gravity
        }

        
        if (other.tag == "TimeGel")
        {
            Debug.Log("Leave Gel");
            Shadowing.gelFlag = 0;
        }
        
    }

    //void CheckIfLevelCompleted()
    //{
    //    if (final.gameObject.tag == "Player")
    //    {
    //        Debug.Log("物体开始重叠");
    //        winGameObject.SetActive(true);
    //    }

    //    // 检查X轴对齐
    //    bool isXAligned = Mathf.Abs(gameObject.transform.position.x - final.position.x) < tolerance;

    //    // 检查Y轴对齐
    //    bool isYAligned = Mathf.Abs(gameObject.transform.position.y - final.position.y) < tolerance;

    //    if (isXAligned && isYAligned)
    //    {
    //        Debug.Log("Success！");
    //        Time.timeScale = 0;
    //        winGameText.enabled = true;
    //        winGameObject.SetActive(true);
    //    }


    //    //if (Mathf.Abs(transform.position.x - 4.8f) < 0.1f && transform.position.y > 3.2f)
    //    //{
    //    //    if (Global.yellowKey && Global.redKey)
    //    //    {
    //    //        Debug.Log("Success！");
    //    //        Time.timeScale = 0;
    //    //        winGameText.enabled = true;
    //    //        winGameObject.SetActive(true);
    //    //    }
    //    //}
    //}
}
