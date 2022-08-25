using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class StartPanelUI : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private CanvasGroup _startPanelCanvasGroup;

        [Header("Buttons")]
        [SerializeField] private Button _startGameButton;

        #region Event subscription

        private void OnEnable()
        {
            PlayerHealth.OnPlayerDeath += OpenStartPanelWithDelay;
        }

        private void OnDisable()
        {
            PlayerHealth.OnPlayerDeath -= OpenStartPanelWithDelay;
        }

        #endregion
        
        public void OpenPanel(float delay)
        {
            StartCoroutine(WaitDelay());
            IEnumerator WaitDelay()
            {
                yield return new WaitForSecondsRealtime(delay);
                PanelAnimation.Instance.EnableTint(true);
                PanelAnimation.Instance.OpenPanel(true, _startPanelCanvasGroup, _startPanel);
            }
        }
        
        private void Awake()
        {
            _startGameButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }

        private void OpenStartPanelWithDelay()
        {
            OpenPanel(0.77f);
        }
    }
}