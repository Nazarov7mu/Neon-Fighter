using DG.Tweening;
using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PanelAnimation : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private Image _tintImage;
        
        public static PanelAnimation Instance { get; private set; }
        
        public void OpenPanel(bool value, CanvasGroup canvasGroup, GameObject panel)
        {
            canvasGroup.alpha = value ? 0 : 1;
            
            if (value) panel.SetActive(true);

            Sequence sequence = DOTween.Sequence();
            sequence.SetUpdate(true);
            sequence.SetDelay(value ? Constants.AnimSpeed / 2 : 0);
            sequence.Append(DOTween
                .To(() => canvasGroup.alpha, x => 
                    { canvasGroup.alpha = x; }, value ? 1 : 0, Constants.AnimSpeed)
                .SetUpdate(true).SetEase(_curve).OnComplete(() =>
                {
                    if (!value) panel.SetActive(false);
                }));
        }

        public void EnableTint(bool value)
        {
            if (value) _tintImage.gameObject.SetActive(true);
        
            byte alpha = (byte)(value ? 240 : 0);
            _tintImage.DOColor(new Color32(0, 0, 0, alpha),
                    Constants.AnimSpeed).
                SetUpdate(true).SetEase(_curve).OnComplete(() => 
                    { if (!value) _tintImage.gameObject.SetActive(false); });
        }
        
        private void Awake()
        {
            Instance = this;
        }
    }
}