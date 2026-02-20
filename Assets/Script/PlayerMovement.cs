using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables del teclado
    private float playerSpeed = 15f;
    // Variables del joystick
    public float joystickDeadZone = 0.2f;
    // Otros controles
    public GameObject Player_interaccion;

    // 

    public Player_Tool_Detector Player_Tool_Detector;
    public string rol;

    // Variables del mouse
    private void OnEnable()
    {
        if (Player_Tool_Detector == null)
        {
            Player_Tool_Detector = GetComponentInChildren<Player_Tool_Detector>();
            rol = Player_Tool_Detector.rol;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        playerMovementTeclado();
        Player_Tool_Detector.UseTool();
        
    }

    public void InteracticWith(GameObject interactor)
    {
        Player_interaccion = interactor;
        if(interactor != null)
        {
            Debug.Log("Estoy interactuando con " + Player_interaccion.name);
        }
    }

    public void playerMovementTeclado()
    {
        Vector3 playerDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (playerDirection.magnitude > 1f)
        {
            playerDirection.Normalize();
        }

        transform.Translate(playerDirection * playerSpeed * Time.deltaTime);
    }

    public void playerMovementJoystick()
    {
        Vector3 playerDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (playerDirection.magnitude < joystickDeadZone)
        {
            playerDirection = Vector3.zero;
        }
        else
        {
            playerDirection = playerDirection.normalized;
        }

        transform.Translate(playerDirection * playerSpeed * Time.deltaTime);
    }







}
