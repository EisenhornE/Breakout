using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private float launchSpeed = 5f;
    private Rigidbody2D _ballRb;
    private Vector2 _origPosition;

    void Start()
    {
        _ballRb = GetComponent<Rigidbody2D>();
        StartCoroutine(Pause());
        _origPosition = transform.position;
    }

    void Update()
    {
        if (_ballRb.velocity.magnitude > launchSpeed)
        {
            _ballRb.velocity = Vector2.ClampMagnitude(_ballRb.velocity, launchSpeed);
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1);
        LaunchBall();
        Debug.Log("Pause is working");
    }

    void ResetBallPosition()
    {
        transform.position = _origPosition;
        _ballRb.velocity = Vector2.zero;
    }

    void LaunchBall()
    {
        float randomAngle = Random.Range(-60f, 60f);
        Vector2 launchDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.up;
        launchDirection.Normalize();
        _ballRb.AddForce(launchDirection.normalized * launchSpeed, ForceMode2D.Impulse);
        Debug.Log("Launch is working");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "RespawnTrigger")
        {
            ResetBallPosition();
            StartCoroutine(Pause());
            Debug.Log("Trigger is working");
        }
    }
}
