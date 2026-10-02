using UnityEngine;
using UnityEngine.UI;              
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")]
    public Text lifeText;                 
    public Transform player;              

    [Header("Respawn")]
    public Transform[] respawnPoints;     
    public float respawnLockSeconds = 1f; 

    private PlayerDamage playerDamage;
    private Rigidbody2D playerBody;
    private Vector3 startPosition;
    private float lockUntil;
    private bool isGameOver;

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    void Start()
    {
        playerDamage = player.GetComponent<PlayerDamage>();
        playerBody = player.GetComponent<Rigidbody2D>();
        startPosition = player.position;   
    }

    
    void Update()
    {
        if (!isGameOver && TryGetLives(out int lives) && lives <= 0)
        {
            GameOver();
        }
    }

    public void PlayerFell(Vector3 fallPosition)
    {
        if (isGameOver || Time.time < lockUntil)
        {
            return;
        }
        lockUntil = Time.time + respawnLockSeconds;

        playerDamage.DealDamage();

        if (TryGetLives(out int lives) && lives <= 0)
        {
            GameOver();
        }
        else
        {
            Respawn(fallPosition);
        }
    }

    void Respawn(Vector3 fallPosition)
    {
        player.position = GetRespawnPosition(fallPosition);
        playerBody.linearVelocity = Vector2.zero;

        Camera cam = Camera.main;
        if (cam != null)
        {
            Vector3 camPos = cam.transform.position;
            cam.transform.position = new Vector3(player.position.x, camPos.y, camPos.z);
        }
    }


    Vector3 GetRespawnPosition(Vector3 fallPosition)
    {
        Transform best = null;
        float bestDistance = float.MaxValue;

        foreach (Transform point in respawnPoints)
        {
            if (point == null) continue;
            if (point.position.x > fallPosition.x) continue;  

            float distance = fallPosition.x - point.position.x;
            if (distance < bestDistance)
            {
                bestDistance = distance;
                best = point;
            }
        }

        return best != null ? best.position : startPosition;
    }

    bool TryGetLives(out int lives)
    {
        string digits = lifeText.text.Replace("x", "").Trim();
        return int.TryParse(digits, out lives);
    }

    void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("EndScene");
    }
}
