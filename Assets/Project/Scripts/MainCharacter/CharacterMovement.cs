using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float jumpSpeed;
	Rigidbody2D _rb;
	float _dir;

	[SerializeField] LayerMask ground;
	[SerializeField] float groundCheckRadius;
	bool _jumped;

	bool _isGrounded;
	Transform _groundCheck;

	[SerializeField] float hangTime;
	float _hangCounter;


	// Start is called before the first frame update
	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		_groundCheck = GameObject.Find("GroundCheck").transform;
	}


	// Update is called once per frame
	void FixedUpdate()
	{
		//movement
		_dir = Input.GetAxis("Horizontal");
		if (_dir > 0)
		{
			_rb.velocity = new Vector2(_dir * speed, _rb.velocity.y);
		}
		else if (0 > _dir)
		{
			_rb.velocity = new Vector2(_dir * speed, _rb.velocity.y);
		}
		else
			_rb.velocity = new Vector2(0, _rb.velocity.y);

		//ground check
		_isGrounded = Physics2D.OverlapCircle(_groundCheck.position, groundCheckRadius, ground) || _rb.velocity.y == 0;
		//_isGrounded = Physics2D.Linecast(transform.position, _groundCheck.position, ground);
		if (_isGrounded)
		{
			_hangCounter = hangTime;
		}
		else
		{
			_hangCounter -= Time.deltaTime;
		}

		_jumped = !_isGrounded;
		//jump
		if (Input.GetAxisRaw("Jump") != 0 && _hangCounter > 0 && !_jumped)
		{
			_jumped = true;
			Debug.Log("jump");
			_rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
		}

		if (Input.GetAxisRaw("Jump") == 0 && _rb.velocity.y > 0)
			_rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * .5f);
	}
}