using System;
using System.Collections;
using System.Collections.Generic;
using General;
using Project.Scripts;
using Project.Scripts.Player;
using TMPro;
using UnityEngine;

public class TestShootStateDisplay : MonoBehaviour
{

	#region Fields

	private const string AddText = "+";
	private const string SubstructText = "-";
	[SerializeField] private TextMeshProUGUI text;
	private PlayerShooting playerShooting;

	#endregion

	#region Unity Lifecycle

	private void Start()
	{
		SL.GetSingle(out playerShooting);
		playerShooting.OnShootStateChange += ChangeText;
	}

	private void OnDestroy() => playerShooting.OnShootStateChange -= ChangeText;

	#endregion

	private void ChangeText(ShootState state)
		=> text.text = state == ShootState.Addition ? AddText : SubstructText;
}