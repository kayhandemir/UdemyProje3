using System.Collections;
using System.Collections.Generic;
using UdemyProje3.Managers;
using UnityEngine;

namespace UdemyProje3.Uis
{/// <summary>
/// Menu Start ve Quit Methodlari için yazılmıştır!!!
/// </summary>
    public class MenuButtonObjects : MonoBehaviour
    {
        public void StartGame()
        {
            GameManager.Instance.SplashScreen(Enums.SceneTypeEnum.Game);
        }
        public void Quit()
        {
            Application.Quit();
        }
    }
}