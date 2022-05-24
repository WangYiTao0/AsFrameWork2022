namespace AsFrameWork
{
    public interface IModel : IBelongToArchitecture, ICanSetArchitecture, ICanGetUtility,ICanSendEvent
    {
        void Init();
    }

    public abstract class AbstractModel : IModel
    {
        private IArchitecture mArchitecture = null;
        
        //显示表现
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecture;
        }
        
        //显示表现
        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }

        void IModel.Init()
        {
            OnInit();
        }

        protected abstract void OnInit();

    }

}