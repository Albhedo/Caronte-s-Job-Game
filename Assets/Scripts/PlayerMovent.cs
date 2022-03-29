using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovent : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform groundCheckD1;
    [SerializeField] Transform groundCheckD2;
    [SerializeField] Transform groundCheckLeft;
    [SerializeField] Transform groundCheckRight;
    [SerializeField] Transform groundCheckUp;
    [SerializeField] Transform groundCheckUp1;
    [SerializeField] Transform groundCheckUp2;


    [SerializeField] float groundCheckDistance;

    [SerializeField] LayerMask whatIsRock;

    Vector3 posicionini;

    bool moveUp = false;
    bool moveLeft = false;
    bool moveRight = false;
    bool moveDown = false;
  

    // Start is called before the first frame update
    void Start()
    {
        posicionini = transform.position;
    }

  


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) //Para que se mueva con las flechas
        {
           moveUp = true;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            moveRight = true;
        }
         else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            moveLeft = true;
        }
         else if(Input.GetKeyDown(KeyCode.DownArrow)  || Input.GetKeyDown(KeyCode.S) && transform.position.y > posicionini.y)
        {
            moveDown = true;

        }


     Debug.DrawLine(groundCheck.position, groundCheck.position - new Vector3(0, groundCheckDistance, 0), Color.red);
     Debug.DrawLine(groundCheckD1.position, groundCheckD1.position - new Vector3(0, groundCheckDistance, 0), Color.red);
     Debug.DrawLine(groundCheckD2.position, groundCheckD2.position - new Vector3(0, groundCheckDistance, 0), Color.red);

    
     Debug.DrawLine(groundCheckLeft.position, groundCheckLeft.position - new Vector3(groundCheckDistance, 0, 0), Color.red);
     Debug.DrawLine(groundCheckRight.position, groundCheckRight.position - new Vector3(groundCheckDistance, 0, 0), Color.red);
     Debug.DrawLine(groundCheckUp.position, groundCheckUp.position - new Vector3(0, groundCheckDistance, 3), Color.red);
     Debug.DrawLine(groundCheckUp1.position, groundCheckUp1.position - new Vector3(0, groundCheckDistance, 3), Color.red);
     Debug.DrawLine(groundCheckUp2.position, groundCheckUp2.position - new Vector3(0, groundCheckDistance, 3), Color.red);


        
    }

   
    void FixedUpdate()
    {
        RaycastHit2D groundRaycast = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsRock);
        RaycastHit2D groundRaycastD1 = Physics2D.Raycast(groundCheckD1.position, Vector2.down, groundCheckDistance, whatIsRock);
        RaycastHit2D groundRaycastD2 = Physics2D.Raycast(groundCheckD2.position, Vector2.down, groundCheckDistance, whatIsRock);

      
        RaycastHit2D groundRaycastL = Physics2D.Raycast(groundCheckLeft.position, Vector2.left, groundCheckDistance, whatIsRock);
        RaycastHit2D groundRaycastR = Physics2D.Raycast(groundCheckRight.position, Vector2.right, groundCheckDistance,whatIsRock);
        
        RaycastHit2D groundRaycastUp = Physics2D.Raycast(groundCheckUp.position, Vector2.up, groundCheckDistance,whatIsRock);
        RaycastHit2D groundRaycastUp1 = Physics2D.Raycast(groundCheckUp1.position, Vector2.up, groundCheckDistance,whatIsRock);
        RaycastHit2D groundRaycastUp2 = Physics2D.Raycast(groundCheckUp2.position, Vector2.up, groundCheckDistance,whatIsRock);

        
      
        ///IZQUIERDA
        if(moveLeft)
        {
            moveLeft = false;
            if(!groundRaycastL)
            {
                rb.MovePosition(rb.position + Vector2.left);
            }
        }
        //DERECHA
       if(moveRight)
        {    moveRight = false;
                if(!groundRaycastR)
                rb.MovePosition(rb.position + Vector2.right);
        }

        //ARRIBA
        if(moveUp)
         {  moveUp = false;
            if(!groundRaycastUp && !groundRaycastUp1)
            rb.MovePosition(rb.position + Vector2.up);
         }

        //ABAJO
        if(moveDown && transform.position.y > posicionini.y)
         {   moveDown = false;
              if(!groundRaycast && !groundRaycastD2 )
             rb.MovePosition(rb.position + Vector2.down);
         }
    }

  
  

public  void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {

            Debug.Log("we lost");
            Death();
            
        }

        if(col.tag == "Win")
        {
            GameManager.instance.Win();
        }

        if(col.gameObject.tag == "Rock")
        {
            Debug.Log("hit");

        }

        if(col.gameObject.tag == "Coin")
        {
            Debug.Log("coin");

        }
      
        
    }

        
        
    

       void Death()
    {
        GameManager.instance.GameOver();
        Destroy(this.gameObject);

    }

  

   
}
