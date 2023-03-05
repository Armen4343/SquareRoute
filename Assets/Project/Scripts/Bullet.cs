using General;
using Project.Scripts.Player;
using UnityEngine;

namespace Project.Scripts
{
	public class Bullet : MonoBehaviour
	{
		#region Fields

		[SerializeField] private Rigidbody2D rigidbody2D;
		[SerializeField] private Vector2 forcePower = new Vector2(5, 0);
		private PlayerShooting playerShooting;

		#endregion

		#region Unity Lifecycle

		private void Start()
		{
			SL.GetSingle(out playerShooting);
			transform.rotation = Quaternion.Euler(0,transform.rotation.y,transform.rotation.z);
			rigidbody2D.AddRelativeForce(forcePower, ForceMode2D.Impulse);
			Destroy(gameObject,5);
		}

		private void OnCollisionEnter2D(Collision2D col)
		{
			playerShooting.RemoveBullet(gameObject);
			Destroy(gameObject);
		}

		#endregion
	}
}