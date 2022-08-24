using UnityEngine;

namespace GameSettings
{
    public class GameSpeed : MonoBehaviour
    {
        public void ResumeTime() => ChangeTimeScale(1);

        public void StopTime() => ChangeTimeScale(0);

        public void SetTime(float value) => ChangeTimeScale(value);

        private void Awake()
        {
            ResumeTime();
        }

        private void ChangeTimeScale(float value) => Time.timeScale = value;
    }
}