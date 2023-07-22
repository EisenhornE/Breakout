using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _horizontalInput;
    private AudioManager _audioManager;
    [SerializeField] private float _speed = 10f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_horizontalInput * _speed, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _audioManager.Play("Bump");
    }
}
