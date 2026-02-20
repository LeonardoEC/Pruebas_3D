using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    /* -----------------------Movimiento por Transform------------------------ */
    // Velocidad de movimiento del jugador
    Player_Data playerData;

    float playerVelocities;

    float playerDirectionHorizontal;
    float playerDirectionVertical;

    bool isPlayerJumped;
    bool isPlayerRuined;

    private void Awake()
    {
        playerData = GetComponentInChildren<Player_Data>();
    }

    private void Update()
    {
        PlayerSprint();
    }

    public void HandleInput(string florTag, bool inAir)
    {
        playerDirectionHorizontal = Input.GetAxisRaw("Horizontal");
        playerDirectionVertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && florTag == "Floor" && inAir == false)
        {
            isPlayerJumped = true;
        }
        isPlayerRuined = Input.GetKey(KeyCode.LeftShift);
    }




    // Metodo para el movimiento del jugador por transform.Translate
    public void PlayerWalkin(Transform playerTrasnfor)
    {
        // Movimiento del jugador con las teclas WASD o las flechas del teclado
        Vector3 playerDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        // Normalizar la direccion del jugador para evitar que se mueva mas rapido en diagonal
        if (playerDirection.magnitude > 1f)
        {
            playerDirection.Normalize();
        }
        // Mover al jugador
        playerTrasnfor.Translate(playerDirection * playerVelocities * Time.deltaTime);
    }

    // Metodo para que el juegador pueda correr al presionar la tecla Shift
    public void PlayerSprint()
    {
        playerVelocities = isPlayerRuined ? playerData.playerSprintSpeed : playerData.playerWalkin;
        
    }

    /* ------------------------ Movimiento por fisica ----------------------- */

    public void PlayerWalk(Transform playerTransform, Rigidbody playerRB)
    {

        // Dirección relativa al transform del jugador
        Vector3 moveDirection = (playerTransform.forward * playerDirectionVertical + playerTransform.right * playerDirectionHorizontal).normalized;

        // Aplicar velocidad manteniendo la gravedad
        Vector3 velocity = moveDirection * playerVelocities;
        velocity.y = playerRB.velocity.y; // conservar componente vertical

        playerRB.velocity = velocity;
    }

    public void PlayerJump(bool isPlayerGrounded, Rigidbody playerRB)
    {

        if (isPlayerGrounded && isPlayerJumped) 
        {
            playerRB.AddForce(Vector3.up * playerData.playerJumForece, ForceMode.Impulse);

            isPlayerJumped = false;
        }
    }


}
