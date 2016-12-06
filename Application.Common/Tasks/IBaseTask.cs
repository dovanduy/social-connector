namespace App.Common.Tasks
{
    public interface IBaseTask<ContextType>
    {
        int Order { get; }
        void Execute(ContextType context);
        bool IsValid(ApplicationType type);
    }
}