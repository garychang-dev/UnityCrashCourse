using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static ScoreManager instance;

    [SerializeField]
    private int score;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    public void IncrementScore(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }
}
