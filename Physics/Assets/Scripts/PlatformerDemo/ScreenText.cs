using TMPro;
using UnityEngine;

public class ScreenText : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    public TMP_Text victoryText;

    public void Start()
    {
        scoreText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        scoreText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        victoryText.gameObject.SetActive(false);
    }

    public void ShowVictoryText()
    {
        scoreText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        victoryText.gameObject.SetActive(true);
    }
}
