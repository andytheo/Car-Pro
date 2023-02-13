using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text mainScore;
    public int highScore;
    public Text mainHighScore;

    private void Awake()
    {
        mainHighScore.text = GetHighScore().ToString();
    }
    public void IncreaseScore()
    {
        score++;
        mainScore.text = score.ToString();

        if (score > GetHighScore()) 
        {
            PlayerPrefs.SetInt("highScore", score);
            mainHighScore.text = score.ToString(); 
        }
    }

    private int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("highScore");
        return i;
    }
}
