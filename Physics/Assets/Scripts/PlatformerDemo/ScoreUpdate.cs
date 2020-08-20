using TMPro;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    public TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        int score = ScoreManager.instance.GetScore();
        text.text = $"Score: {score}";
    }
}
