using System.Collections;
using General;
using Project.Scripts.Player;
using TMPro;
using UnityEngine;

namespace Project.Scripts
{
	public class Enemy : MonoBehaviour
	{
		#region MyRegion

		[SerializeField] private int value;
		[SerializeField] private TextMeshProUGUI valueText;
		[SerializeField] private SpriteRenderer spriteRenderer;
		private PlayerHealth playerHealth;
		private PlayerShooting playerShooting;
		private float sqrt;

		#endregion

		#region Unity Lifecycle

		private void Start()
		{
			SL.GetSingle(out playerHealth);
			SL.GetSingle(out playerShooting);
			SetValue();
			StartCoroutine(CheckState());
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.GetComponent<CharacterMovement>())
			{
				if (ValueGetSqrt())
				{
					//TODO score logic
				}
				else
					playerHealth.TakeDamage();
				
				Destroy(gameObject);
			}
			else
			{
				if (playerShooting.ShootState == ShootState.Substraction)
					value--;
				else
					value++;
				SetValue();
			}
		}

		#endregion

		#region Methods

		private IEnumerator CheckState()
		{
			while (true)
			{
				yield return null;
				spriteRenderer.color = ValueGetSqrt() ? Color.white : Color.black;
				valueText.color = !ValueGetSqrt() ? Color.white : Color.black;
			}
		}

		private bool ValueGetSqrt()
		{
			sqrt = Mathf.Sqrt(value);
			return sqrt == (int)sqrt;
		}

		private void SetValue() => valueText.text = value.ToString();

		#endregion
	}
}