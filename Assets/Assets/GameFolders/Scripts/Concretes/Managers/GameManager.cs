using System.Collections;
using System.Collections.Generic;
using UdemyProje3.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProje3.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] int _score;
        public int Score => _score;
        public const string Player_Score = "PlayerScore";
        public System.Action<SceneTypeEnum> OnSceneChanged;
        public event System.Action<int> OnScoreChanged;
        private void Awake()
        {
            SingletonThisObject();
        }
        private void SingletonThisObject()
        {
            if (Instance==null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        private IEnumerator Start()
        {
            yield return SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));

            _score = PlayerPrefs.GetInt(Player_Score, 0);
        }
        public void SplashScreen(SceneTypeEnum sceneTypeEnum)
        {  
            StartCoroutine(SplashScreenAsync(sceneTypeEnum));
        }
        private IEnumerator SplashScreenAsync(SceneTypeEnum sceneType)
        {
            yield return SceneManager.LoadSceneAsync(SceneTypeEnum.SplashScreen.ToString(), LoadSceneMode.Additive);
            OnSceneChanged?.Invoke(SceneTypeEnum.SplashScreen);
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());  
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SplashScreen"));

            yield return new WaitForSeconds(3f);

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            yield return SceneManager.LoadSceneAsync(sceneType.ToString(),LoadSceneMode.Additive);
            OnSceneChanged?.Invoke(sceneType);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneType.ToString()));
        }
        public void QuitGame()
        {
            Application.Quit();
        }
        public void InCreaseScore(int scorePoint)
        {
            _score += scorePoint;
            OnScoreChanged?.Invoke(_score);
        }
        public void DeCreaseScore(int scorePoint)
        {
            _score -= scorePoint;
            OnScoreChanged?.Invoke(_score);
        }
        public void SaveScore()
        {
            PlayerPrefs.SetInt(Player_Score, _score);
        }
    }
}