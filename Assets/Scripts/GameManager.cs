using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int currentLevel = 1;
    public int totalAttempts = 0; // Contador total de intentos
    public int[] levelAttempts = new int[5]; // Intentos por cada nivel
    public string playerName; // Nombre del jugador

    public TMP_InputField nameInputField; // Referencia al TMP_InputField donde el jugador ingresa su nombre
    public Button confirmButton; // Referencia al botón de confirmación
    public Button startButton; // Botón de inicio

    private List<(string playerName, int attempts)> leaderboard = new List<(string, int)>(); // Ránking de los mejores

    private void Awake()
    {
        // Verificar si ya existe una instancia del GameManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destruir este objeto si ya existe una instancia
            return;
        }

        // Asignar la instancia
        Instance = this;
        DontDestroyOnLoad(gameObject); // Evitar que el GameManager se destruya al cargar una nueva escena
    }

    public void AskForName()
    {
        // Mostrar el TMP_InputField y el botón de confirmación
        nameInputField.gameObject.SetActive(true);
        confirmButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
    }

    public void SetPlayerName()
    {
        // Obtener el nombre del jugador desde el TMP_InputField
        playerName = nameInputField.text;

        if (string.IsNullOrEmpty(playerName)) // Si no se ingresa un nombre, asignar un valor predeterminado
        {
            playerName = "Jugador_" + Random.Range(1, 1000); // Nombre predeterminado si no se ingresa uno
        }

        nameInputField.gameObject.SetActive(false);
        confirmButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); // Carga la escena de juego

        score = 0; // Restablecer la puntuación
        currentLevel = 1; // Iniciar en el nivel 1
        totalAttempts = 0; // Restablecer los intentos

        Debug.Log("Juego Iniciado con nombre: " + playerName);
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Puntuación actual: " + score);
    }

    public void NextLevel()
    {
        levelAttempts[currentLevel - 1]++; // Incrementar el contador de intentos para el nivel actual
        currentLevel++;
        Debug.Log("Nivel actual: " + currentLevel);
    }

    public void ResetGame()
{
    score = 0;
    currentLevel = 1;
    totalAttempts = 0;
    playerName = "";  // Restablecer el nombre del jugador
    for (int i = 0; i < levelAttempts.Length; i++)
    {
        levelAttempts[i] = 0; // Restablecer los intentos por nivel
    }
    Debug.Log("Juego reiniciado.");
}


    public void CheckGameOver()
    {
        if (currentLevel > 5) // Si se ha completado el último nivel
        {
            SaveScore();
            SceneManager.LoadScene("MainMenu"); // Regresar al menú principal
        }
    }

    private void SaveScore()
    {
        leaderboard.Add((playerName, totalAttempts));
        leaderboard.Sort((x, y) => x.Item2.CompareTo(y.Item2)); // Ordenar por el número de intentos (menor es mejor)

        // Limitar el ránking a los 5 primeros
        if (leaderboard.Count > 5)
        {
            leaderboard.RemoveAt(leaderboard.Count - 1);
        }

        Debug.Log("Ránking de los mejores jugadores:");
        foreach (var entry in leaderboard)
        {
            Debug.Log($"{entry.playerName}: {entry.attempts} intentos");
        }
    }

    public List<(string playerName, int attempts)> GetLeaderboard()
    {
        return leaderboard;
    }

    // Obtener los intentos por cada nivel
    public int[] GetLevelAttempts()
    {
        return levelAttempts;
    }
}
