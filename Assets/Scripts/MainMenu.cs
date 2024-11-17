using UnityEngine;
using TMPro;
using System.Collections.Generic; // Añadir esta línea

public class MainMenu : MonoBehaviour
{
    public TMP_Text leaderboardText; // Para mostrar el ranking
    public TMP_Text levelAttemptsText; // Para mostrar los intentos por nivel
    private List<(string playerName, int attempts)> leaderboard;
    private int[] levelAttempts;

    private void Start()
    {
        leaderboard = GameManager.Instance.GetLeaderboard();
        levelAttempts = GameManager.Instance.GetLevelAttempts();
        DisplayLeaderboard();
        DisplayLevelAttempts();
    }

    private void DisplayLeaderboard()
    {
        leaderboardText.text = "Ránking de los mejores:\n";

        for (int i = 0; i < leaderboard.Count; i++)
        {
            leaderboardText.text += $"{i + 1}. {leaderboard[i].playerName}: {leaderboard[i].attempts} intentos\n";
        }
    }

    private void DisplayLevelAttempts()
    {
        levelAttemptsText.text = "Intentos por nivel:\n";

        for (int i = 0; i < levelAttempts.Length; i++)
        {
            levelAttemptsText.text += $"Nivel {i + 1}: {levelAttempts[i]} intentos\n";
        }
    }
}
