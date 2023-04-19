using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace LittleHunter
{
    public sealed class SplashScene : MonoBehaviour
    {
        [SerializeField] private GameObject _bootstrapGameObject;
        [SerializeField] private Image _logoImage;

        private readonly Stopwatch _stopwatch = new Stopwatch();
        private bool _isLoading;

        private void Awake()
        {
            _logoImage.SetAlpha(0f);
        }

        private void Start()
        {
            _logoImage.DOFade(1f, 1f).OnComplete(delegate
            { 
                _stopwatch.Start();
                _bootstrapGameObject.SetActive(true);
                _stopwatch.Stop();
                float delay = Mathf.Max(0f, Mathf.Min(2f - _stopwatch.ElapsedMilliseconds, 2f));
                _logoImage.DOFade(0f, 1f).SetDelay(delay).OnComplete(OnLogoImageFadeOut);
            });
        }

        private void OnLogoImageFadeOut()
        {
            LoadSceneData();
        }

        private void LoadSceneData()
        {
            if (!_isLoading)
            {
                _isLoading = true;
                SceneManager.UnloadSceneAsync("Bootstrap");
            }
        }
    }
}