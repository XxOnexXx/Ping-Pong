using TMPro;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ScoreText : MonoBehaviour
{   


    public static ScoreText Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    TMP_Text scoreTextLeft;
    TMP_Text scoreTextRight;

    void Start()
    {
        scoreTextLeft = FindFirstObjectByType<TMP_Text>();
        scoreTextRight = FindFirstObjectByType<TMP_Text>();
    }
    public void SetGoalLeft(int score)
    {
        score++;
        scoreTextLeft.text = score.ToString("D1");
    }

    public void SetGoalRight(int score)
    {
        score++;
        scoreTextRight.text = score.ToString("D1");
    }
}
