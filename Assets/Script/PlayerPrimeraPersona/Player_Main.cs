using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Main : MonoBehaviour
{
    Rigidbody playerRigidbody;
    Player_Main_Detector playerDectero;
    Player_Movement playerMovement;
    Player_Camera_Controller playerCameraController;
    Camera playerCamera;
    Player_Tool_Detector playerToolDetector;


    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerDectero = GetComponentInChildren<Player_Main_Detector>();
        playerMovement = GetComponentInChildren<Player_Movement>();
        playerCameraController = GetComponentInChildren<Player_Camera_Controller>();
        playerCamera = GetComponentInChildren<Camera>();
        playerToolDetector = GetComponentInChildren<Player_Tool_Detector>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.HandleInput(playerDectero.floorTag, playerDectero.inAir);
        playerToolDetector.UseTool();
    }

    private void FixedUpdate()
    {
        playerMovement.PlayerWalk(transform, playerRigidbody);
        playerMovement.PlayerJump(playerDectero.isInFloor, playerRigidbody);
    }

    private void LateUpdate()
    {
        playerCameraController.CameraPlayer(playerCamera, transform);
    }

    private void OnDestroy()
    {
        
    }

}
