using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] public float launchSpeed = 5f;
    private Rigidbody2D _ballRb;
    private Vector2 _origPosition;
    private AudioManager _audioManager;
    private GameManager _gameManager;
    private bool launchEnabled = true;

    void Start()
    {
        _ballRb = GetComponent<Rigidbody2D>();
        _origPosition = transform.position;
        _audioManager = FindObjectOfType<AudioManager>();
        _gameManager = FindObjectOfType<GameManager>();
        if (launchEnabled)
        {
            StartCoroutine(Pause());
        }
    }

    void Update()
    {
        if (_ballRb.velocity.magnitude > launchSpeed)
        {
            _ballRb.velocity = Vector2.ClampMagnitude(_ballRb.velocity, launchSpeed);
        }

        if (_gameManager.Lives == 0)
        {
            launchEnabled = false;
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1);
        LaunchBall();
    }

    void ResetBallPosition()
    {
        if (_gameManager.Lives > 1)
        {
            transform.position = _origPosition;
            _ballRb.velocity = Vector2.zero;
        }
        else if (_gameManager.Lives == 1)
        {
            _ballRb.velocity = Vector2.zero;
            GameObject ball = GameObject.Find("Ball");
            ball.GetComponent<SpriteRenderer>().enabled = false;
        }
        launchEnabled = true;
    }

    void LaunchBall()
    {
        if (launchEnabled)
        {
            float randomAngle = Random.Range(-60f, 60f);
            Vector2 launchDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.down;
            launchDirection.Normalize();
            _ballRb.AddForce(launchDirection.normalized * launchSpeed, ForceMode2D.Impulse);
            launchEnabled = false;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "RespawnTrigger")
        {
            ResetBallPosition();
            _audioManager.Play("OutOfBounds");
            _gameManager.LoseLife();
            if (launchEnabled)
            {
                StartCoroutine(Pause());
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            float randomAngle = Random.Range(-90f, 90);
            Vector2 launchDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.up;
            launchDirection.Normalize();
            _ballRb.AddForce(launchDirection.normalized * launchSpeed, ForceMode2D.Impulse);
            _audioManager.Play("Bump");
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            _audioManager.Play("Bump");
        }
    }
}
