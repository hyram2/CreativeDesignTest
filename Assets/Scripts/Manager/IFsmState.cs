namespace Manager
{
    public interface IFsmState
    {
        void Start();
        void Update();
        void Exit();
    }
}