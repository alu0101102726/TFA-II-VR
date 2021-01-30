/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se controla el movimiento del jugador.
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @class PlayerMove
* @brief Clase que maneja el movimiento del jugador.
*/
public class PlayerMove : MonoBehaviour {
  /**
  * @brief Movimiento recibido del joystick
  */
  private Vector3 playerInput;
  /**
  * @brief Referencia al controlador del personaje.
  */
  public CharacterController player;
  /**
  * @brief Dirección del movimiento del jugador.
  */
  private Vector3 movePlayer;
  /**
  * @brief Velocidad de movimiento
  */
  public float speed = 6f;
  /**
  * @brief Última sala visitada.
  */
  public int lastRoom = -1;    
  /**
  * @brief Gravedad
  */
  public float gravity = 9.81f;
  /**
  * @brief Velocidad de caída
  */
  public float fallSpeed;
  /**
  * @brief Fuerza de salto.
  */
  public float jumpForce;
  /**
  * @brief Referencia a la cámara.
  */
  public Camera mainCamera;
  /**
  * @brief Posición delantera de la cámara.
  */
  private Vector3 camForward;
  /**
  * @brief Posición ubicada a la derecha de la cámara.
  */
  private Vector3 camRight;
  /**
  * @brief Función que se ejecuta en cada frame
  *  Recoge los ejes horizontales y verticales para poder mover al jugador.
  */
  void FixedUpdate () {

    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    Move(h, v);
  }
  /**
  * @brief Permite al jugador moverse según unos ejes recibidos.
  * @param h eje horizontal
  * @param v eje vertical
  */
  public void Move(float h, float v) {
    playerInput = new Vector3(h, 0f, v);
    playerInput = Vector3.ClampMagnitude(playerInput, 1);

    Turning ();

    movePlayer = playerInput.x * camRight + playerInput.z * camForward;
    movePlayer = movePlayer * speed;

    SetGravity();

    PlayerSkills();
    player.Move(movePlayer * Time.deltaTime);
  }   

  /**
  * @brief Permite al jugador girar sobre sí mismo.
  */
  void Turning ()  {
    camForward = mainCamera.transform.forward;
    camRight = mainCamera.transform.right;

    camForward.y = 0;
    camRight.y = 0;
  }
  /**
  * @brief Asigna el valor de la gravedad según este en el suelo o en mitad
  * de un salto.
  */
  void SetGravity() {
    if(player.isGrounded) {
      fallSpeed = -gravity * Time.deltaTime;
      movePlayer.y = fallSpeed;
    }
    else {
      fallSpeed -= gravity * Time.deltaTime;  
      movePlayer.y = fallSpeed;          
    }
  }
  /**
  * @brief Permite al jugador saltar.
  */
  void PlayerSkills() {
    if(player.isGrounded && Input.GetButtonDown("Jump")) {
      fallSpeed = jumpForce;
      movePlayer.y = fallSpeed;
    }
  }
}
