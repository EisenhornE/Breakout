using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// This script is for the Ball GameObject. This is for its movement and collision with other GameObjects.

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

    // In the Update function, here you can see that I used the Vector2.ClampMagnitude function to clamp the ball's velocity as
    // the ball, probably due to how Unity's physics engine works, can go faster than the launchSpeed variable if it collides
    // multiple times with the player platform. This is to prevent the ball from going too fast and breaking the game.
    // I also used the launchEnabled bool to prevent the ball from launching when the player loses all their lives.

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

    // This Coroutine here is so that there is a short pause after the ball is lost. This is so that the player can prepare.

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1);
        LaunchBall();
    }

    // This function here is called in the GameManager script when the ball collides with the below the player platform.
    // It returns to its original location. If the player has only 1 life, then the ball will be destroyed instead.

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
            Destroy(gameObject);
        }
        launchEnabled = true;
    }

    // This function is if the launchEnabled bool is true, then the ball will be launched at a random angle between -60 and 60 degrees.
    // The launchEnabled bool will then be set to false.

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

    // This is when the ball goes out of bounds, it will call the ResetBallPosition function and play the OutOfBounds sound effect.

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

    // This function is so that there is a random angle when the ball collides with the player platform. This is to prevent the ball
    // from having a predictable angle when it collides with the player platform. This is also to almost copy the same feel of the original
    // Breakout game. The Audio named "Bump" in the AudioManager is also played.

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
