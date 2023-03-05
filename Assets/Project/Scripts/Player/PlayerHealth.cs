using System;
using General;
using UnityEngine;

namespace Project.Scripts.Player
{
	public class PlayerHealth : MonoBehaviour, IService
	{
		#region Fields

		[SerializeField] private GameObject[] healthIcons;
		private int healthCount = 2;

		#endregion

		public event Action OnLost;
		
		private void Awake() => SL.AddSingle(this, SetMode.Force);

		public void TakeDamage()
		{
			healthIcons[healthCount].SetActive(false);
			healthCount--;
			if (healthCount < 0)
				OnLost?.Invoke();
			
		}
	}
}