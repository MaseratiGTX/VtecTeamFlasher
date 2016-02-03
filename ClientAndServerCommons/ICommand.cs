namespace ClientAndServerCommons
{
    public delegate void ICommandDelegate();

    public interface ICommand
    {
        void Execute();
    }
}