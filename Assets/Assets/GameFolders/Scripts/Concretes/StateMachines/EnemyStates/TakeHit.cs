using UdemyProje3.Abstracts.Animations;
using UdemyProje3.Abstracts.Combats;
using UdemyProje3.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProje3.StateMachines.EnemyStates
{
    public class TakeHit : IState
    {
        IAnimation _animation;
        IHealth _health;
        float _maxDelayTime = 1.0f;
        float _currentDelayTime = 0f;

        public bool IsTakeHit { get; private set; }

        public TakeHit(IHealth health,IAnimation animation)
        {
            _health = health;
            _animation = animation;
            health.OnHealthChanged += (currentHealth, maxHealth) =>
            {
                OnEnter();
                //başka işlemler varsa yapılır!!!
            };
        }

        public void OnEnter()
        {     
            IsTakeHit = true;
        }

        public void OnExit()
        {
            _currentDelayTime = 0f;
        }

        public void Tick()
        {
            _currentDelayTime += Time.deltaTime;
            if (_currentDelayTime > _maxDelayTime&&IsTakeHit)
            {
                _animation.TakeHitAnimation();
                IsTakeHit = false;
                _currentDelayTime = 0f;
            }
            Debug.Log("TakeHit Tick");
        }
    }
}