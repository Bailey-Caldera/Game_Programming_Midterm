using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Transform gameOverScreen;
    private Transform winScreen;
    private Transform statusUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverScreen = transform.GetChild(0);
        winScreen = transform.GetChild(1);
        statusUI = transform.GetChild(2);
    }

    private void OnEnable()
    {
        PlayerHealth.onPlayerDeath += DisplayGameOver;
        LevelController.onCompleteWave += DisplayWinScreen;
    }

    private void OnDisable()
    {
        PlayerHealth.onPlayerDeath -= DisplayGameOver;
        LevelController.onCompleteWave -= DisplayWinScreen;
    }

    private void DisplayGameOver()
    {
        statusUI.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
    }

    private void DisplayWinScreen()
    {
        statusUI.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(true);
    }

    
}
