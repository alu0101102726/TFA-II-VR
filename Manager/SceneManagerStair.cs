/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief Se encarga de gestionar el cambio de escenas en las escaleras
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
* @class SceneManagerStair
* @brief Clase encargada de la carga de escenas en las escaleras
*/
public class SceneManagerStair : MonoBehaviour {
	/**
  * @brief Nombre de la escena
  */
	public string sceneName;
	
	/**
  * @brief Representa el código de la escena de la que se llega
  */
	public int sceneCode;

	/**
  * @brief Panel que representa la carga del Loading
  */
	public GameObject panelBar;

	/**
  * @brief Representa el porcentaje de la escena cargado
  */
	[SerializeField]
	private Text percentText;

	/**
  * @brief Representa el proceso de carga de la escena
  */
	[SerializeField]
	private Image progressImage;
	
	/**
  * @brief Inicialización de los atributos necesarios
  */
	void Start() {        
		panelBar.SetActive(false);
	}

	/**
	* @brief Corrutina que va a hacer la carga de escenas
	*/
	public IEnumerator LoadScene() {
		AsyncOperation loading;

		//Iniciamos la carga asíncrona de la escena y guardamos el proceso en 'loading'
		loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

		//Bloqueamos el salto automático entre escenas para asegurarnos el control durante el proceso
		loading.allowSceneActivation = false;

		//Cuando la escena llega al 90% de carga, se produce el cambio de escena
		while (loading.progress < 0.9f) {
			
			//Actualizamos el % de carga de una forma optima 
			//(concatenar con + tiene un alto coste en el rendimiento)
			percentText.text = string.Format ("{0}%", loading.progress * 100);

			//Actualizamos la barra de carga
			progressImage.fillAmount = loading.progress;

			//Esperamos un frame
			yield return null;
		}

		//Mostramos la carga como finalizada
		percentText.text = "100%";
		progressImage.fillAmount = 1;

		//Activamos el salto de escena.
		loading.allowSceneActivation = true;
	}
  
	/**
	* @brief Función que detecta si el jugador ha entrado en la escalera
	* 			 y si es así, cambia de escena
	* @param collider Objeto con el que se colisiona
	*/
	private void OnTriggerEnter(Collider collider) {
		if(collider.tag == "Player") {
			GameObject.FindWithTag("Player").GetComponent<PlayerMove>().lastRoom = sceneCode;
			panelBar.SetActive(true);
			StartCoroutine(LoadScene());
		}
	}

  /**
	* @brief Cambia de escena (aplicando la función anterior)
	*/  
	public void ChangeScene() {
		panelBar.SetActive(true);
		StartCoroutine(LoadScene());
	}

}
