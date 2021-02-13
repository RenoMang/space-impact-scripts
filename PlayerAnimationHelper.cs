using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHelper : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    void Start()
    {
        playerAnimator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        CheckIfBreaks();
        CheckIfUp();
        CheckIfDown();
        
        CheckIfBreaks2();
        CheckIfUp2();
        CheckIfDown2();
    }
    
    private void CheckIfBreaks()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            playerAnimator.Play("space_ship_breaks");
        }
        
        if(Input.GetKeyUp(KeyCode.A))
        {
            playerAnimator.Play("space_ship_idle");
        }
    }
    
    private void CheckIfUp()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            playerAnimator.Play("space_ship_downwards");
        }
        
        if(Input.GetKeyUp(KeyCode.W))
        {
            playerAnimator.Play("space_ship_idle");
        }
    }
    
    private void CheckIfDown()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            playerAnimator.Play("space_ship_upwards");
        }
        
        if(Input.GetKeyUp(KeyCode.S))
        {
            playerAnimator.Play("space_ship_idle");
        }
    }
    
    // Testing checks for key buttons, will fix later
    
    private void CheckIfBreaks2()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerAnimator.Play("space_ship_breaks");
        }
        
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerAnimator.Play("space_ship_idle");
        }
    }
    
    private void CheckIfUp2()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAnimator.Play("space_ship_downwards");
        }
        
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerAnimator.Play("space_ship_idle");
        }
    }
    
    private void CheckIfDown2()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerAnimator.Play("space_ship_upwards");
        }
        
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerAnimator.Play("space_ship_idle");
        }
    }
    

}
