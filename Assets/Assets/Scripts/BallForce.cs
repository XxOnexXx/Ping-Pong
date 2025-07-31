
using UnityEngine;
using TMPro;

public class BallForce : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float force = 8f;
    TrailRenderer trailRenderer;
    [SerializeField] private float multipliedForce = 1.03f;
    [SerializeField] private Transform startPos;
    [SerializeField] private float minAngle = 2f;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject hitVfx;
    int p1Score = 0;
    int p2Score = 0;
    [SerializeField] TMP_Text scoreTextLeft;
    [SerializeField] TMP_Text scoreTextRight;


    CameraShake shake;

    void Awake()
    {
        Time.timeScale = 1;
        SoundManager.Instance.PlayMusic();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
        gameOverScreen.SetActive(false);
        trailRenderer = GetComponent<TrailRenderer>();


        Launch();


    }


    void Update()
    {
        GameWon();
    }

    public void Launch()
    {
        //float xSpeed = Random.Range(0f, maxAngle) == 0 ? 1f : -1f;
        //float ySpeed = Random.Range(0f, maxAngle) == 0 ? 1f : -1f;

        //rb.linearVelocity = new Vector2(xSpeed, ySpeed) * force;
        Vector2 facingDir = Vector2.left;
        facingDir.y = Random.Range(-minAngle, minAngle);

        rb.linearVelocity = facingDir * force;

    }

    public void LaunchRight()
    {
        Vector2 facingDir = Vector2.right;
        facingDir.y = Random.Range(-minAngle, minAngle);

        rb.linearVelocity = facingDir * force;
    }

    public void LaunchLeft()
    {
        Vector2 facingDir = Vector2.left;
        facingDir.y = Random.Range(-minAngle, minAngle);

        rb.linearVelocity = facingDir * force;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        shake.Shake();
        SoundManager.Instance.Bounce();
        GameObject collisionVfx = Instantiate(hitVfx, transform.position, Quaternion.identity);
        Destroy(collisionVfx, 1f);
        PlayerControll paddle = collision.gameObject.GetComponent<PlayerControll>();
        OppController oppPaddle = collision.gameObject.GetComponent<OppController>();
        if (paddle || oppPaddle)
        {
            rb.linearVelocity *= multipliedForce;
            float maxSpeed = 40f;

            if (rb.linearVelocity.magnitude < maxSpeed)
            {
                rb.linearVelocity *= multipliedForce;
            }
            else
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }


        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        SoundManager.Instance.GoalSound();
        SoundManager.Instance.ClapSound();
        if (collision.gameObject.CompareTag("GoalLeft"))
        {
            SetGoalRight();
            ResetBallPos();
            Invoke("LaunchRight", 2f);
        }

        if (collision.gameObject.CompareTag("GoalRight"))
        {
            SetGoalLeft();
            ResetBallPos();
            Invoke("LaunchLeft", 2f);
        }
    }

    void ResetBallPos()
    {
        trailRenderer.Clear();
        rb.linearVelocity = new Vector3(0, 0, 0);
        transform.position = startPos.position;
    }

    public void SetGoalLeft()
    {  
        p1Score++;
        scoreTextLeft.text = p1Score.ToString("D1");
    }

    public void SetGoalRight()
    {
        p2Score++;
        scoreTextRight.text = p2Score.ToString("D1");
    }

    void GameWon()
    {
        SoundManager.Instance.StopMusic();
        if (p1Score >= 5)
        {
            Debug.Log("P1 won the game");
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
        if (p2Score >= 5)
        {
            Debug.Log("P2 won the game");
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
            
        }
    }

    
}
