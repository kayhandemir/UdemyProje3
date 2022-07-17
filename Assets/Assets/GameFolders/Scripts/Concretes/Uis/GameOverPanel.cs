using System.Collections;
using System.Collections.Generic;
using UdemyProje3.Managers;
using UnityEngine;

namespace UdemyProje3.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
       public void YesButton()
       {
            GameManager.Instance.SplashScreen(Enums.SceneTypeEnum.Game);
       }
       public void NoButton()
       {
            GameManager.Instance.SplashScreen(Enums.SceneTypeEnum.Menu);
       }
    }
}