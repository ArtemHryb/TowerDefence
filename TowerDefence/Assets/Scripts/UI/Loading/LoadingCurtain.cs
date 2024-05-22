using System.Collections;
using UnityEngine;

namespace UI.Loading
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtain;
        private readonly float _disappearSpeed = 0.01f;

        public void Show()
        {
            gameObject.SetActive(true);
            _curtain.alpha = 1;
        }

        public void Hide() =>
            StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            while (_curtain.alpha > 0)
            {
                _curtain.alpha -= 0.01f;
                yield return new WaitForSeconds(_disappearSpeed);
            }
            
            gameObject.SetActive(false);
        }
    }
}