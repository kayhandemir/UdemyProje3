using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UdemyProje3.Uis
{
    public class ResultPanel : MonoBehaviour
    {
        TextMeshProUGUI _resultMessage;

        private void Awake()
        {
            _resultMessage = transform.GetChild(0).GetComponent<TextMeshProUGUI>();  
        }
        public void ResultMessage(string resultX)
        {
            _resultMessage.text = resultX;
        }
    }
}