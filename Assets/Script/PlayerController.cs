using UnityEngine;

// As you can see, this script is very simple. It's just for the player to move left and right.

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _horizontalInput;
    [SerializeField] private float _speed = 10f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_horizontalInput * _speed, 0);
        if (_horizontalInput == 0f)
        {
            _rb.velocity = Vector2.zero;
        }
    }
}
