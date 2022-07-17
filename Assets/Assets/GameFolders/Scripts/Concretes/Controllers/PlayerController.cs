using System.Collections;
using System.Collections.Generic;
using UdemyProje3.Abstracts.Animations;
using UdemyProje3.Abstracts.Combats;
using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.Inputs;
using UdemyProje3.Abstracts.Movements;
using UdemyProje3.Animations;
using UdemyProje3.Inputs;
using UdemyProje3.Managers;
using UdemyProje3.Movements;
using UdemyProje3.Uis;
using UnityEngine;

namespace UdemyProje3.Controllers
{
    public class PlayerController : MonoBehaviour,IEntityController
    {
        [SerializeField] float moveSpeed = 3.0f;
        float _horizontal;

        IPlayerInput _input;
        IMover _mover;
        IAnimation _animation;
        IFlip _flip;
        IOnGround _onGround;
        IJump _jump;
        IHealth _health;

        private void Awake()
        {
            _input = new MobileInput();
            _mover = new Mover(this,moveSpeed);
            _animation = new CharacterAnimation(GetComponent<Animator>());
            _flip = new Flip(this);
            _onGround = GetComponent<IOnGround>();
            _jump = new Jump(this,_onGround);
            _health = GetComponent<IHealth>();
        }
        void OnEnable()
        {
            _health.OnDead += _animation.DeadAnimation;
            _health.OnDead += GameManager.Instance.SaveScore;
        }
        private void Start()
        {
            GameOverObject overObject = FindObjectOfType<GameOverObject>();
            overObject.SetPlayerHealth(_health);
        }     
        private void Update()
        {
            if (_health.IsDead) return;
            _horizontal = _input.Horizontal;
            if (_input.AttackButtonDown&&_horizontal==0f) _animation.AttackAnimation();
            if (_input.JumpButtonDown)
            {
                _jump.IsJump = true;
            }
            _animation.JumpAnimation(!_onGround.IsGround);
            _animation.MoveAnimation(_horizontal);
        }
        private void FixedUpdate()
        {
            _flip.FlipCharacter(_horizontal);
            _mover.Tick(_horizontal);
            _jump.TickWithFixedUpdate(); 
        }
    }
}