using System.Collections;
using System.Collections.Generic;
using UdemyProje3.Enums;
using UdemyProje3.Managers;
using UnityEngine;

namespace UdemyProje3.Controllers
{
    public class CanvasSceneController : MonoBehaviour
    {
        [SerializeField] SceneTypeEnum sceneTypeEnum;
        [SerializeField] GameObject canvasObject;

        private void Start()
        {
            GameManager.Instance.OnSceneChanged += HandleSceneChanged;
        }
        private void OnDestroy()
        {
            GameManager.Instance.OnSceneChanged -= HandleSceneChanged;
        }
        void HandleSceneChanged(SceneTypeEnum sceneType)
        {
            if (sceneType==this.sceneTypeEnum)
            {
                canvasObject.SetActive(true);
            }
            else
            {
                canvasObject.SetActive(false);
            }
        }
    }
}