using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace LittleHunter
{
    public sealed class SplashScene : MonoBehaviour
    {
        [SerializeField] private GameObject bootstrapGameObject;
        [SerializeField] private Image logoImage;

        private Stopwatch _stopwatch = new Stopwatch();
        private bool isLoading;

        private void Awake()
        {
            logoImage.SetAlpha(0f);
        }

        private void Start()
        {
            logoImage.DOFade(1f, 1f).OnComplete(delegate
            { 
                _stopwatch.Start();
                bootstrapGameObject.SetActive(true);
                _stopwatch.Stop();
                float delay = Mathf.Max(0f, Mathf.Min(2f - _stopwatch.ElapsedMilliseconds, 2f));
                logoImage.DOFade(0f, 1f).SetDelay(delay).OnComplete(OnLogoImageFadeOut);
            });
        }

        private void OnLogoImageFadeOut()
        {
            LoadSceneData();
        }

        private void LoadSceneData()
        {
            if (!isLoading)
            {
                isLoading = true;
                SceneManager.UnloadSceneAsync("Bootstrap");
            }
        }
    }
}