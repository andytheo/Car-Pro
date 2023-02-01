using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text mainScore;

    public void IncreaseScore()
    {
        score++;
        mainScore.text = score.ToString();
    }
}
