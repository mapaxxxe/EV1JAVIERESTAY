using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //events
    public static event System.Action<Vector2> OnPlayerMovement;
    public static event System.Action<bool> OnJump;
    public static event System.Action Onpause;
   

     [SerializeField] private PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput.onActionTriggered += HandleInput;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= HandleInput;
    }

    private void HandleInput(InputAction.CallbackContext context)
    {
        string action = context.action.name;


        switch (action)
        {
            case "Move" :
                Vector2 input = context.ReadValue<Vector2>();
                OnPlayerMovement?.Invoke(input);
                break;

           case "Jump" :
                if(context.started)OnJump?.Invoke(true);
                else if(context.canceled)OnJump?.Invoke(false);
                break;
                
          case "Pause": if(context.started) Onpause?.Invoke(); 
                        break;
        }

    }





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





}
