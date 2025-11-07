using UnityEngine;

public class PlayerPaddle : Paddle
{
    private Vector2 _direction;

    // Factor to control how fast the paddle follows touch
    [SerializeField] private float touchFollowSpeed = 10f;

    // Update is called once per frame
    private void Update()
    {
        _direction = Vector2.zero;

        // Keyboard input
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }

        // Touch input with smoothing
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);

            // Calculate difference along Y-axis
            float deltaY = touchWorldPos.y - transform.position.y;

            // Normalize to direction (-1 or 1)
            _direction = new Vector2(0, Mathf.Clamp(deltaY * touchFollowSpeed, -1f, 1f));
        }
    }

    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0)
        {
            _rigidbody.AddForce(_direction * this.speed);
        }
    }
}
