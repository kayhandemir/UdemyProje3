using UdemyProje3.Abstracts.Animations;
using UdemyProje3.Abstracts.Combats;
using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.Movements;
using UdemyProje3.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProje3.StateMachines.EnemyStates
{
    public class Attack : IState
    {
        IAnimation _animation;
        IAttacker _attacker;
        IHealth _playerHealth;
        IFlip _flip;
        System.Func<bool> _isPlayerRightSide;

        float _currentAttackTime;
        float _maxAttackTime;

        public Attack(IHealth playerHealth,IFlip flip, IAnimation animation,IAttacker attacker,float maxAttackTime,System.Func<bool> IsPlayerRightSide)
        {
            _playerHealth = playerHealth;
            _flip = flip;
            _animation = animation;
            _attacker = attacker; 
            _maxAttackTime = maxAttackTime;
            _isPlayerRightSide = IsPlayerRightSide;
        }
        public void OnEnter()
        {
            _currentAttackTime = 0;
        }

        public void OnExit()
        {
          
        }

        public void Tick()
        {
            _currentAttackTime += Time.deltaTime;
            if (_currentAttackTime > _maxAttackTime)
            {
                _flip.FlipCharacter(_isPlayerRightSide.Invoke() ? 1f:-1f);
                _animation.AttackAnimation();
                _attacker.Attack(_playerHealth);
                _currentAttackTime = 0;
            }
            Debug.Log("Attack Tick");
        }
    }
}