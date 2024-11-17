using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalHole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            // Aquí puedes incrementar la puntuación o mostrar un mensaje de "Gol"
            Debug.Log("Gol!");

            // Cargar el siguiente nivel
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("Has completado todos los niveles.");
                // Opcional: Reiniciar el juego o regresar al menú principal
                SceneManager.LoadScene(0); // Volver al primer nivel o menú
            }
        }
    }
}
