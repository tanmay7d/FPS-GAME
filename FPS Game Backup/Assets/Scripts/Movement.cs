using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public CharacterController controller;
    public float JumpHeight = 3f;
    public float speed = 12f;
    Vector3 velocity;
    public float Gravity = -10f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField]bool isGrounded;
    public Animator animator;

    public void Update()
    {

        animator = GetComponent<Animator>();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = transform.right * x + transform.forward * z;

        controller.Move(moveDir * speed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded )
        {
            
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }

        velocity.y += Gravity * Time.deltaTime;


        controller.Move(velocity * Time.deltaTime);



        if (z == 1)
        {
            
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsBackwards", false);
            
        }
        else
        {
            if (z == 0)
            {
                
                animator.SetBool("IsIdle", true);
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsLeft", false);
                animator.SetBool("IsRight", false);
                animator.SetBool("IsBackwards", false);
                
            }
            if (x == 1)
            {

                animator.SetBool("IsRight", true);
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsLeft", false);
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsBackwards", false);
                
            }
            if (x == 0)
            {

                animator.SetBool("IsIdle", true);
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsLeft", false);
                animator.SetBool("IsRight", false);
                animator.SetBool("IsBackwards", false);
                
            }
            if (z == -1)
            {
                animator.SetBool("IsBackwards", true);
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsLeft", false);
                animator.SetBool("IsRight", false);
                
            }
            if (x == -1)
            {

                animator.SetBool("IsLeft", true);
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsIdle", false);
                animator.SetBool("IsBackwards", false);
                animator.SetBool("IsRight", false);
                
            }
        }
        
       
    }
}



