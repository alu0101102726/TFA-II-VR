/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se recogen las funciones que se encargann del
 * movimiento de los enemeigos
 **/
using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.Events;

/**
* @class EnemyMovement
* @brief Clase encargada de controlar el movimiento de los enemigos
*/
public class EnemyMovement : MonoBehaviour  {
  /**
  * @brief Rango de visión
  */
  public float visionRange = 10f;
  /**
  * @brief Rango de escucha
  */
  public float hearingRange = 20f;
  /**
  * @brief Distancia de deambulación
  */
  public float wanderDistance = 10f;
  /**
  * @brief Velocidad de movimiento
  */
  public float speed = 5f;
  /**
  * @brief Tiempo para el enemigo estando quieto
  */
  public Vector2 idleTimeRange;
  [Range(0f,1f)]
  /**
  * @brief Nivel de escucha mejorado del enemigo
  */
  public float psychicLevels = 0.2f;
  /**
  * @brief Delegado principal
  */
  public MainDelegate navStart;
  /**
  * @brief Visión actual
  */
  public float currentVision;
  /**
  * @brief Elemento Transform del jugador.
  */ 
  public Transform player;
  /**
  * @brief Referencia a la clase PlayerHealth
  */
  public PlayerHealth playerHealth;
  /**
  * @brief Referencia a la clase EnemyHealth 
  */
  public EnemyHealth enemyHealth;
  /**
  * @brief Referencia al componente NavMesh
  */
  public NavMeshAgent nav;
  /**
  * @brief Cronómetro
  */
  public float timer = 0f;
  /**
  * @brief Función Awake, se ejecuta antes de la función Start. 
  * Se asigna la referencia al jugador, la salud del jugador y el mapa
  * de navegación.
  */
  void Awake () {
    player = GameObject.FindGameObjectWithTag ("Player").transform;
    playerHealth = player.GetComponent <PlayerHealth> ();
    enemyHealth = GetComponent <EnemyHealth> ();
    nav = GetComponent<NavMeshAgent>();
    // navStart.enemyMoveEvent += StartPath;

  }
  /**
  * @brief Función que se ejecuta cuando el enemigo se activa.
  */
  void OnEnable() {
    nav.enabled = true;
    ClearPath();
    ScaleVision(1f);
    IsPsychic();
    timer = 0f;
  }

  /**
  * @brief Función que resetea el camino del enemigo.
  */
  void ClearPath() {
    if (nav.hasPath)
      nav.ResetPath();
  }
   /**
  * @brief Función que se ejecuta en cada frame, se comprueba si el enemigo
  * y eljugador estan vivos para que el enemigo pueda moverse adecuadamente. 
  * En caso contrario, cancelamos el camino del enemigo.
  */
  void Update () {
    if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
      LookForPlayer();
      WanderOrIdle();
    }
    else {
      nav.enabled = false;
    }
  }

  /**
  * @brief Función que se ejecuta cuando el enemigo se destruye.
  */
  void OnDestroy() {
    nav.enabled = false;
  }
  /**
  * @brief Función que hace que el enemigo busque al jugador.
  */
  private void LookForPlayer() {
    TestSense(player.position, currentVision);
  }
  /**
  * @brief Representa el área de escucha que tiene en enemigo
  * @param position Posicion actual del enemigo
  */
  private void HearPoint(Vector3 position) {
    TestSense(position, hearingRange);
  }
  /**
  * @brief Comprobamos la distancia entre el jugador y el enemigo para
  *        ver si está dentro del rango visual
  * @params position Posicion del enemigo
  * @params senseRange Rango visual
  */
  private void TestSense(Vector3 position, float senseRange) {
    if (Vector3.Distance(this.transform.position, position) <= senseRange)  {
      GoToPosition(position);
    }
  }
  /**
  * @brief Función que hace que el enemigo se dirija hacia el jugador.
  */
  public void GoToPlayer() {
    GoToPosition(player.position);
  }
  /**
  * @brief Función que hace que el enemigo se dirija a una posición.
  * @param position Vector3 de la posición.
  */
  private void GoToPosition(Vector3 position) {
    timer = -1f;
    SetDestination(position);
  }
  /**
  * @brief Función que asigna el destino al cual se debe mover el enemigo.
  * @param position Vector3 de la posición.
  */
  private void SetDestination(Vector3 position) {
    if (nav.isOnNavMesh)  {
      float step =  speed * Time.deltaTime;
      transform.position = Vector3.MoveTowards(transform.position, player.position, step);
      nav.SetDestination(position);
    }
  }
  /**
  * @brief Función que decide si el enemigo debe deambular y esperar.
  */
  private void WanderOrIdle() {
    if (!nav.hasPath) {
      if (timer <= 0f) {
        SetDestination(GetRandomPoint(wanderDistance, 5));
        if (nav.pathStatus == NavMeshPathStatus.PathInvalid) {
          ClearPath();
        }
        timer = Random.Range(idleTimeRange.x, idleTimeRange.y);
      }
      else {
        timer -= Time.deltaTime;
      }
    }
  }
  /**
  * @brief Hace que el enemigo se desplace hasta el jugador
  */
  private void IsPsychic() {
    GoToPlayer();
  }

  /**
  * @brief Función que genera un punto aleatorio en el mapa para asignarlo
  * al mapa de nvegación.
  */
  private Vector3 GetRandomPoint(float distance, int layermask)  {
    Vector3 randomPoint = UnityEngine.Random.insideUnitSphere * distance + this.transform.position;

    NavMeshHit navHit;
    NavMesh.SamplePosition(randomPoint, out navHit, distance, layermask);

    return navHit.position;
  }
  /**
  * @brief Representa la visión del enemigo escalada
  * @param scale Nuevo valor a escalar su vision
  */
  public void ScaleVision(float scale)  {
    currentVision = visionRange * scale;
  }
}