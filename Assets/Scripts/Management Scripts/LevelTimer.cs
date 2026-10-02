using UnityEngine;
using TMPro;                          
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public TMP_Text timerText;        
    public float startSeconds = 180f; 
    private float timeRemaining;
    private bool running = true;      

    void Start()
    {
        if (timerText == null)
        {
            timerText = GetComponent<TMP_Text>();
        }

        timeRemaining = startSeconds;
        ShowTime();
    }

    void Update()
    {
        if (!running) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;       
            running = false; 
            ShowTime();
            SceneManager.LoadScene("EndScene");
            return;
        }

        ShowTime();
    }

    void ShowTime()
    {
        int totalSeconds = Mathf.CeilToInt(timeRemaining);

        int minutes = totalSeconds / 60;   
        int seconds = totalSeconds % 60;   

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
