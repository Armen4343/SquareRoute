using System;
using System.Collections.Generic;
using General;
using UnityEngine;

namespace Project.Scripts.Player
{
	public class PlayerShooting : MonoBehaviour, IService
	{
		#region Fields

		[SerializeField] private Transform bulletSpawn;
		[SerializeField] private GameObject bulletPrefab;
		private List<GameObject> bullets = new List<GameObject>(30);
		private ShootState shootState = ShootState.Substraction;
		private Camera camera;
		private Vector3 mousePosition;
		private Vector3 lookVector;
		private GameObject bulletInstance;

		#endregion

		public ShootState ShootState => shootState;

		public event Action<ShootState> OnShootStateChange;

		#region Unity Lifecycle

		private void Awake() => SL.AddSingle(this, SetMode.Force);

		private void Start() => camera = Camera.main;

		private void Update()
		{
			GetMousePos();
			lookVector = (mousePosition - camera.WorldToScreenPoint(transform.position)).normalized;
			transform.right = lookVector;
			if (Input.GetMouseButtonDown(1))
				ChangeShootState();
			if (Input.GetMouseButtonDown(0))
				Shoot();
		}

		private void ChangeShootState()
		{
			shootState = shootState == ShootState.Substraction ? ShootState.Addition : ShootState.Substraction;
			OnShootStateChange?.Invoke(shootState);
		}

		#endregion

		#region Methods

		public void RemoveBullet(in GameObject bullet) => bullets.Remove(bullet);

		private void Shoot()
		{
			bulletInstance = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
			bulletInstance.transform.right = lookVector;
			bullets.Add(bulletInstance);
		}

		private void GetMousePos()
		{
			mousePosition.x = Input.mousePosition.x;
			mousePosition.y = Input.mousePosition.y;
		}

		#endregion
	}
}