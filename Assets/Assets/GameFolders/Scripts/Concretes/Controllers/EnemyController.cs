using UdemyProje3.Abstracts.Animations;
using UdemyProje3.Abstracts.Combats;
using UdemyProje3.Abstracts.Controllers;
using UdemyProje3.Abstracts.Movements;
using UdemyProje3.Animations;
using UdemyProje3.Movements;
using UdemyProje3.StateMachines;
using UdemyProje3.StateMachines.EnemyStates;
using UnityEngine;
using System.Collections;

namespace UdemyProje3.Controllers
{
    public class EnemyController : MonoBehaviour,IEntityController
    {
        [Header("Movements")]
        [SerializeField] float moveSpeed = 2.0f;
        [SerializeField] Transform[] patrols;
        [Header("Distance")]
        [SerializeField] float chaseDistance = 3.0f;
        [SerializeField] float attackDistance = 0.7f;
        [SerializeField] float maxAttackTime = 1.0f;
        [Header("Score")]
        [SerializeField] ScoreController scorePrefab;

        IEntityController _player;
        StateMachine _stateMachine;

        private IEnumerator Start()
        {
            IMover _mover = new Mover(this, moveSpeed);
            IAnimation _animation = new CharacterAnimation(GetComponent<Animator>());
            IFlip _flip = new Flip(this);
            IHealth _health = GetComponent<IHealth>();
            IAttacker _attacker = GetComponent<IAttacker>();
            IStopEdge _stopEdge = GetComponent<IStopEdge>();
            _stateMachine = new StateMachine();
            _player = FindObjectOfType<PlayerController>();

            Idle idle = new Idle(_mover,_animation);
            Walk walk = new Walk(this,_mover,_animation,_flip,patrols);
            ChasePlayer chasePlayer = new ChasePlayer(_mover,_flip,_animation,_stopEdge,IsPlayerRightSide);
            Attack attack = new Attack(_player.transform.GetComponent<IHealth>(),_flip,_animation,_attacker,maxAttackTime,IsPlayerRightSide);
            TakeHit takeHit = new TakeHit(_health,_animation);
            Dead dead = new Dead(this,_animation,()=>Instantiate(scorePrefab,transform.position,Quaternion.identity));

            _stateMachine.AddTransition(idle, walk,()=>idle.IsIdle==false);
            _stateMachine.AddTransition(idle, chasePlayer, () => DistanceFromMeToPlayer()< chaseDistance);
            _stateMachine.AddTransition(walk, chasePlayer, () => DistanceFromMeToPlayer() < chaseDistance);
            _stateMachine.AddTransition(chasePlayer, attack, () => DistanceFromMeToPlayer() < attackDistance);

            _stateMachine.AddTransition(walk,idle, () =>walk.IsWalking==false);
            _stateMachine.AddTransition(chasePlayer, idle, () => DistanceFromMeToPlayer() > chaseDistance);
            _stateMachine.AddTransition(attack, chasePlayer, () => DistanceFromMeToPlayer() > attackDistance);

            _stateMachine.AddAnyState(dead, () => _health.IsDead);
            _stateMachine.AddAnyState(takeHit,()=> takeHit.IsTakeHit);

            _stateMachine.AddTransition(takeHit, chasePlayer, () => !takeHit.IsTakeHit);
            _stateMachine.SetState(idle);
            return null;
        }
        private void Update()
        {
            _stateMachine.Ticks();
        }
        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
        private float DistanceFromMeToPlayer()
        {
            return Vector2.Distance(transform.position, _player.transform.position);
        }
        private bool IsPlayerRightSide()
        {
            Vector3 result = _player.transform.position - this.transform.position;
            if (result.x>0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}