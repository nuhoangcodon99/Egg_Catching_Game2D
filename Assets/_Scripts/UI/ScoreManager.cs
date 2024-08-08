using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    // Renamed to ScoreText for clarity
    public TMP_Text ScoreText;
    private int score; // Using an integer for score is more appropriate
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreTextUpdate(); 
    }

    // Method to update the ScoreText with the current score
    public void IncreaseScore()
    {
        score++;
        ScoreTextUpdate();
    }

    // Private method to update the ScoreText with the current score
    private void ScoreTextUpdate()
    {
        ScoreText.text = "SCORE: " + score;
    }
}
