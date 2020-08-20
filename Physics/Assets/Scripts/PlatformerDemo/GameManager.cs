using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent onGameWon;
    private bool gameWon;

    void Start()
    {
        gameWon = false;
    }

    void Update()
    {

        // Super inefficient but works for this demo
        if (!gameWon)
        {
            int numCountsLeft = GameObject.FindGameObjectsWithTag("Coin").Length;
            if(numCountsLeft == 0)
            {
                gameWon = true;
                onGameWon?.Invoke();
            }
        }
    }
}
