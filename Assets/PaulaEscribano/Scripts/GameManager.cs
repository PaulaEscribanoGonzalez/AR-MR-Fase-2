using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int collectedGems = 0;
    public int totalGems = 0;
    public float timeRemaining = 60f;
    public bool gameEnded = false;

    [Header("UI References")]
    public Text gemCounterText;
    public Text timerText;
    public GameObject endGamePanel;
    public Text endGameMessage;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        totalGems = PlayerPrefs.GetInt("GemasHorizontales") + PlayerPrefs.GetInt("GemasVerticales");
        gemCounterText.text = $"0 / {totalGems}";
        endGamePanel.SetActive(false);

        timeRemaining = PlayerPrefs.GetInt("Time", 60); // Usa el tiempo configurado
    }

    void Update()
    {
        if (gameEnded) return;

        timeRemaining -= Time.deltaTime;
        timerText.text = $"Tiempo: {Mathf.CeilToInt(timeRemaining)}";

        if (timeRemaining <= 0)
        {
            EndGame(false); // Derrota por tiempo agotado
        }
    }

    public void CollectGem()
    {
        collectedGems++;
        gemCounterText.text = $"{collectedGems} / {totalGems}";

        if (collectedGems >= totalGems)
        {
            EndGame(true); // Victoria
        }
    }

    void EndGame(bool won)
    {
        gameEnded = true;
        endGamePanel.SetActive(true);

        if (won)
        {
            endGameMessage.text = "¡Has ganado!";
        }
        else
        {
            endGameMessage.text = "¡Has perdido!";
        }
    }

    public void SalirJuego()
    {
        SceneManager.LoadScene("ScnSetup");
    }
}
