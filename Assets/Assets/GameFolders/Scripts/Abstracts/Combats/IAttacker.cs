namespace UdemyProje3.Abstracts.Combats
{
    public interface IAttacker
    {
        void Attack(ITakeHit takehit);
        int Damage { get; }
    }
}