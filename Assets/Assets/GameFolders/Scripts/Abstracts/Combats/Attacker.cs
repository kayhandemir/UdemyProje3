using UnityEngine;

namespace UdemyProje3.Abstracts.Combats
{
    public class Attacker : MonoBehaviour,IAttacker
    {
        [SerializeField] int damage = 1;

        public int Damage => damage;

        public virtual void Attack(ITakeHit takehit)
        {
            takehit.TakeHit(this);
        }
    }
}