namespace AsFrameWork
{
    public interface ICommand : IBelongToArchitecture, ICanSetArchitecture
        ,ICanGetSystem,ICanGetModel,ICanGetUtility,ICanSendEvent,ICanSendCommand // +
    {
        void Execute();
    }

    
    public abstract class AbstractCommand : ICommand
    {
        private IArchitecture _architecture;

        IArchitecture IBelongToArchitecture.GetArchitecture() // -+
        {
            return _architecture;
        }
        
        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture) // -+
        {
            _architecture = architecture;
        }

        void ICommand.Execute()
        {
            OnExecute();
        }

        protected abstract void OnExecute();

    }

}

