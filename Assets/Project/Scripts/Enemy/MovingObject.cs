using UnityEngine;

public enum Direction
{
	Left,
	Right,
	Up,
	Down
}

public enum MovementType
{
	Horizontal,
	Vetrtical
}

public class MovingObject : MonoBehaviour
{
	[SerializeField] private Transform point1;
	[SerializeField] private Transform point2;
	[SerializeField] private float speed;
	[SerializeField] private float stopTime;
	[SerializeField] private MovementType movementType = MovementType.Horizontal;
	private bool isStopped;
	private Direction currentDirection;
	private float t;
	private Vector3 pos;


	private void Start()
	{
		point1.parent = null;
		point2.parent = null;
	}

	void Update()
	{
		if (isStopped)
			return;
		if (movementType == MovementType.Horizontal)
			HorizontalMove();
		else
			VerticalMove();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
		collision.transform.parent = null;

	}

	private void VerticalMove()
	{
		if (currentDirection == Direction.Down)
		{
			pos.y = Time.deltaTime * speed;
			transform.position -= pos;
			if (transform.position.y < point1.position.y)
			{
				currentDirection = Direction.Up;
				isStopped = true;
				Invoke("ContinueWalk",stopTime);

			}
		}
		else
		{
			pos.y = Time.deltaTime * speed;
			transform.position += pos;
			if (transform.position.y > point2.position.y)
			{
				currentDirection = Direction.Down;
				isStopped = true;
				Invoke("ContinueWalk", stopTime);
			}
		}
	}

	private void HorizontalMove()
	{
		if (currentDirection == Direction.Left)
		{
			pos.x = Time.deltaTime * speed;
			transform.position -= pos;
			if (transform.position.x < point1.position.x)
			{
				currentDirection = Direction.Right;
				isStopped = true;

				Invoke("ContinueWalk", stopTime);
			}
		}
		else
		{
			pos.x = Time.deltaTime * speed;
			transform.position += pos;
			if (transform.position.x > point2.position.x)
			{
				currentDirection = Direction.Left;
				isStopped = true;

				Invoke("ContinueWalk", stopTime);
			}
		}
	}

	private void ContinueWalk() => isStopped = false;
}