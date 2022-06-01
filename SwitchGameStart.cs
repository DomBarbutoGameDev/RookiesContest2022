using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(SignalReceiver))]
public class SwitchGameStart : Interactable
{
    public DiceGame diceGame;

    //After interacting with interactable cardboard, Activate switches to third person
    public override void Activate()
    {
        base.Activate();
        PlayerController.Instance.ThirdPersonCamera.SetActive(true);

        diceGame.gameObject.SetActive(true);
        diceGame.isPlaying = true;
        diceGame.canRoll = true;
        
        //PlayerController.Instance.FirstPersonCamera.SetActive(false);
        //Stop player from being able to move
        PlayerController.Instance.Deactivate();
    }
    
    public override void Deactivate()
    {
        base.Deactivate();
        PlayerController.Instance.ThirdPersonCamera.SetActive(false);
        //RESET THE MAIN CAM TO EYE POSITION - It gets all out of whack after using free lock third person cam
        Camera.main.transform.position = PlayerController.Instance.mainCameraEyePosition;
        Camera.main.fieldOfView = 50f;
        diceGame.ClearDice();
        diceGame.ResetUI();
        diceGame.gameObject.SetActive(false);
        diceGame.isPlaying = false;
        //PlayerController.Instance.FirstPersonCamera.SetActive(true);
        //Stop player from being able to move
        PlayerController.Instance.Activate();
    }

}