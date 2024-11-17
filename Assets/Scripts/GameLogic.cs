using UnityEngine;

public class GameLogic : MonoBehaviour
{
    void Start()
    {
        // Inicialización: Mostrar la puntuación actual y nivel al inicio del juego
        Debug.Log("Puntuación inicial: " + GameManager.Instance.score);
        Debug.Log("Nivel inicial: " + GameManager.Instance.currentLevel);

        // Añadir puntos y avanzar al siguiente nivel (simulación de eventos del juego)
        SimulateGameEvents();
    }

    void SimulateGameEvents()
    {

        // Obtener la puntuación actual (solo para mostrar en consola)
        int currentScore = GameManager.Instance.score;
        Debug.Log("Puntuación después de sumar: " + currentScore);

        // Avanzar al siguiente nivel
        GameManager.Instance.NextLevel();

        // Mostrar el nivel actual después de avanzar
        Debug.Log("Nivel después de avanzar: " + GameManager.Instance.currentLevel);
    }
}
