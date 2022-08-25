using UI;
using UnityEngine;

namespace GameSettings
{
    public class GameStarter : MonoBehaviour
    {
        private bool _isNewSession;
    
        private void Awake()
        {
            GameStarter[] objs = FindObjectsOfType<GameStarter>();

            if (objs.Length > 1)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);

            if (_isNewSession) return;
        
            _isNewSession = true;
        }

        private void Start()
        {
            StartPanelUI startPanelUI = FindObjectOfType<StartPanelUI>();
            startPanelUI.OpenPanel(0);
        
            GameSpeed gameSpeed = FindObjectOfType<GameSpeed>();
            gameSpeed.StopTime();
        }      
    }
}