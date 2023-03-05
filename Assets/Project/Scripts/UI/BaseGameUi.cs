using General;
using Project.Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
   public class BaseGameUi : MonoBehaviour
   {

      #region Fields

      [SerializeField] private Button pause;
      [SerializeField] private Button exit;
      [SerializeField] private Button restart;
      [SerializeField] private Button resume;
      [SerializeField] private GameObject pausePanel;
      [Space] 
      [SerializeField] private GameObject gameOverPanel;
      [SerializeField] private Button exitGame;
      [SerializeField] private Button restartGame;

      private PlayerHealth playerHealth;

      #endregion


      #region Unity Lifecycle

      private void Start()
      {
         SL.GetSingle(out playerHealth);
         playerHealth.OnLost += GameOver;
         PausePanelEventsHandler();
         GameOverPanelEventsHandler();
      }

      private void OnDestroy() => playerHealth.OnLost -= GameOver;

      #endregion

      #region Methods

      private void PausePanelEventsHandler()
      {
         pause.onClick.AddListener(Pause);
         exit.onClick.AddListener(Exit);
         restart.onClick.AddListener(Restart);
         resume.onClick.AddListener(Resume);
      }

      private void GameOverPanelEventsHandler()
      {
         exitGame.onClick.AddListener(Exit);
         restartGame.onClick.AddListener(Restart);
      }
   
      private void GameOver()
      {
         Time.timeScale = 0;
         gameOverPanel.SetActive(true);
      }

      private void Resume()
      {
         Time.timeScale = 1;
         pausePanel.SetActive(false);
      }

      private void Restart()
      {
         Time.timeScale = 1;
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }

      private void Exit()
      {
         Time.timeScale = 1;
         SceneManager.LoadScene("Start");
      }

      private void Pause()
      {
         Time.timeScale = 0;
         pausePanel.SetActive(true);
      }
   
      #endregion

   }
}
