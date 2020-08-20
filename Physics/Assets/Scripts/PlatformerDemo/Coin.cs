using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points;

    private void OnTriggerEnter(Collider other)
    {
        // TODO: Destroy the game object and increment the score in ScoreManager (singleton)
        if (other.gameObject.tag == Constants.PLAYER_TAG)
        {
            Destroy(gameObject);
            ScoreManager.instance.IncrementScore(points);
        }
    }
}
