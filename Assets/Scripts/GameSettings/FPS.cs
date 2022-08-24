using TMPro;
using UnityEngine;

namespace GameSettings
{
    public class FPS : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _fpsText;
    
        private float _deltaTime;

        private void Awake()
        {
            Application.targetFrameRate = 120;
        }

        private void Update()
        {
            if (Time.timeScale != 0) ShowFPS();
        }

        private void ShowFPS()
        {
            _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
            float fps = 1.0f / _deltaTime;
            _fpsText.text = $"{Mathf.Ceil(fps)}";
        }
    }
}
