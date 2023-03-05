using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
	[SerializeField] private Button startButton;
	private void Start() 
		=> startButton.onClick.AddListener(()=>SceneManager.LoadScene("TEST"));
}
