using System;
using Architecture.Services.Audio;
using Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.MainMenu
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IAudioService _audioService;
        
        [Inject]
        public void Construct(IAudioService audioService)
        {
            _audioService = audioService;
        }
        private void Awake() => 
            _button.onClick.AddListener(Close);

        private void Start()
        {
            gameObject.transform.localScale = Vector3.zero;
            LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f),1.5f).setDelay(0.7f).setEaseOutElastic();
        }

        private void Close()
        {
            _audioService.PlaySfx(SfxType.Click);
            Destroy(transform.parent.gameObject);
        }
    }
}