namespace Manager
{
    public interface IFsmState
    {
        void Start();
        void Exit();
    }
}