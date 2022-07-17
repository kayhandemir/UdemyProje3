using UdemyProje3.Abstracts.Animations;
using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.Movements;
using UdemyProje3.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProje3.StateMachines.EnemyStates
{
    public class ChasePlayer : IState
    {
        IMover _mover;
        IFlip _flip;
        IAnimation _animation;
        IStopEdge _stop;
        System.Func<bool> _isPlayerRightSide;
        public ChasePlayer(IMover mover,IFlip flip,IAnimation animation,IStopEdge stopEdge,System.Func<bool> isPlayerRightSide)
        {
            _mover = mover;
            _flip = flip;
            _animation = animation;
            _stop = stopEdge;
            _isPlayerRightSide = isPlayerRightSide;
        }
        public void OnEnter()
        {
            _animation.MoveAnimation(1.0f);
        }

        public void OnExit()
        {
            _animation.MoveAnimation(0f);
        }

        public void Tick()
        {
            if (_stop.ReachEdge())
            {
                _animation.MoveAnimation(0f);
                return;
            }
            if (_isPlayerRightSide.Invoke())
            {
                _mover.Tick(1.1f);
                _flip.FlipCharacter(1f);
            }
            else
            {
                _mover.Tick(-1.1f);
                _flip.FlipCharacter(-1f);
            }
            Debug.Log("Chase Player Tick");
        }
    }
}