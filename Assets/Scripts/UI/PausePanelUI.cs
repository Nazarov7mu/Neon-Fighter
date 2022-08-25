using GameSettings;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PausePanelUI : MonoBehaviour
    {
        [Header("Scripts")]
        [SerializeField] private GameSpeed _gameSpeed;
        
        [Header("Panels")]
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private CanvasGroup _pausePanelCanvasGroup;

        [Header("Buttons")]
        [SerializeField] private GameObject _pauseButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;
        
        private void Awake()
        {
            AssignButtons();
        }

        private void AssignButtons()
        {
            _restartButton.onClick.AddListener(()=> 
                SceneManager.LoadScene(SceneManager.GetActiveScene().name));
            
            _resumeButton.onClick.AddListener(ResumeGame);
        }

        private void ResumeGame()
        {
            _gameSpeed.ResumeTime();
            _pauseButton.SetActive(true);
            PanelAnimation.Instance.EnableTint(false);
            PanelAnimation.Instance.OpenPanel(false, _pausePanelCanvasGroup, _pausePanel);
        }

        public void StopGame()
        {
            _gameSpeed.StopTime();
            _pauseButton.SetActive(false);
            PanelAnimation.Instance.EnableTint(true);
            PanelAnimation.Instance.OpenPanel(true, _pausePanelCanvasGroup, _pausePanel);
        }
    }
}