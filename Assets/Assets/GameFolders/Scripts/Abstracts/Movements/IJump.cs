namespace UdemyProje3.Abstracts.Movements
{
    public interface IJump
    {
        void TickWithFixedUpdate();
        bool IsJump { get; set; }
    }
}
