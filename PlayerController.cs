using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private MouseLook _mouseLook;
    public Vector3 mainCameraEyePosition;

    public GameObject FirstPersonCamera;        //Players FPS Camera
    public GameObject CutsceneCamera;           //Cutscene with BRAIN
    public GameObject CutscenePlayerCamera;     //Cutscene from Players FPS
    public GameObject ThirdPersonCamera;        //Players TPS Camera (when playing dice)

    private void Awake()
    {
        Instance = this;
        
    }
    private void Update()
    {
        mainCameraEyePosition = (new Vector3(0f, 0.71f, 0f) + transform.position);
    }

    public void Activate()
    {
        _playerMovement.enabled = true;
        _mouseLook.enabled = true;
    }

    public void Deactivate()
    {
        _playerMovement.enabled = false;
        _mouseLook.enabled = false;
    }
}
