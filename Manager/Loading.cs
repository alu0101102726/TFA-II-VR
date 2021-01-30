/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se establece la carga entre escenas
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
* @class Loading
* @brief Clase encargada de gestionar el cambio entre escenas
*/
public class Loading : MonoBehaviour {

	/**
	* @brief Texto que establece el porcentaje de carga de escenas
	*/
	[SerializeField]
	private Text percentText;

	/**
	* @brief Imagen que representa el progreso de carga
	*/
	[SerializeField]
	private Image progressImage;

	/**
	* @brief En cuanto se active el objeto, se inciará el cambio de escena
	*/
	void Start () {
		//Iniciamos una corrutina, que es un método que se ejecuta 
		//en una línea de tiempo diferente al flujo principal del programa
		StartCoroutine(LoadScene());
	}

	/**
	* @brief Corrutina que va a hacer la carga de escenas
	* @param sceneToLoad Representa la escena a la que vamos a cambiar
	*/
	public IEnumerator LoadScene(string sceneToLoad = "")	{
		AsyncOperation loading;

		//Iniciamos la carga asíncrona de la escena y guardamos el proceso en 'loading'
		loading = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);

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

}
