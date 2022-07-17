using System.Collections;
using System.Collections.Generic;
using TMPro;
using UdemyProje3.Managers;
using UnityEngine;
using UdemyProje3.Controllers;
using UdemyProje3.Abstracts.Combats;

namespace UdemyProje3.Uis
{
    public class QuestionPanel : MonoBehaviour
    {
        [SerializeField] ResultPanel resultPanel;
        TextMeshProUGUI _messageText;
        IHealth _playerhealth;
        int _lifeCount;
        private void Awake()
        {
            //_messageText = GetComponentInChildren<TextMeshProUGUI>();
            _messageText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }
        private void OnDisable()
        {
            _lifeCount = 0;
            _playerhealth = null;
        }
        public void SetLifeCountAndHealth(int lifeCount,IHealth playerHealth)
        {
            _lifeCount = lifeCount;
            _messageText.text = $"Do you want buy {_lifeCount} life?";
            _playerhealth = playerHealth;
        }
        public void YesClick()
        {
            resultPanel.gameObject.SetActive(true);
            if (_lifeCount<=GameManager.Instance.Score)
            {
                resultPanel.ResultMessage($"You have bought {_lifeCount} have a good day.");
                GameManager.Instance.DeCreaseScore(_lifeCount);
                Debug.Log($"{_lifeCount} life was taken");
                _playerhealth.Heal(_lifeCount);
            }
            else
            {
                resultPanel.ResultMessage("you don't have enough diamonds please try again later...");
            }
            this.gameObject.SetActive(false);
        }
    }
}