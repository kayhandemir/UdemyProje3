using UdemyProje3.Abstracts.Animations;
using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProje3.StateMachines.EnemyStates
{
    public class Dead : IState
    {
        IAnimation _animation;
        IEntityController _entityController;
        System.Action _deadCallback;

        float _currentDestoryTime = 0f;
        float _maxDestoryTime = 1.0f;

        public Dead(IEntityController entityController,IAnimation animation,System.Action deadCallback)
        {
            _entityController = entityController;
            _animation = animation;
            _deadCallback = deadCallback;
        }
        public void OnEnter()
        {
            _animation.DeadAnimation();
            _deadCallback?.Invoke();
        }

        public void OnExit()
        {
            _currentDestoryTime = 0;
        }

        public void Tick()
        {
            _currentDestoryTime += Time.deltaTime;
            if (_currentDestoryTime>_maxDestoryTime)
            {
                Object.Destroy(_entityController.transform.gameObject);
            }
            Debug.Log("Dead Tick");
        }
    }
}