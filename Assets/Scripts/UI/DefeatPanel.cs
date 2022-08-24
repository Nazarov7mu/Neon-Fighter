using System.Collections;
using GameSettings;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class DefeatPanel : MonoBehaviour
    {
        [Header("Scripts")]
        [SerializeField] private GameSpeed _gameSpeed;
        
        [Header("Panels")]
        [SerializeField] private GameObject _defeatPanel;

        [Header("Buttons")] 
        [SerializeField] private Button _restartButton;

        #region Event subscription

        private void OnEnable()
        {
            PlayerHealth.OnPlayerDeath += OpenDefeatPanel;
        }

        private void OnDisable()
        {
            PlayerHealth.OnPlayerDeath -= OpenDefeatPanel;
        }

        #endregion
        
        private void Awake()
        {
            _restartButton.onClick.AddListener(()=> SceneManager.LoadScene(SceneManager.GetActiveScene().name));
        }

        private void OpenDefeatPanel()
        {
            StartCoroutine(WaitForParticles());
            
            IEnumerator WaitForParticles()
            {
                yield return new WaitForSeconds(0.7f);
                _gameSpeed.StopTime();
                _defeatPanel.SetActive(true);
            }
            
        }
    }
}