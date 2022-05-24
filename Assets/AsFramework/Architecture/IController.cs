namespace AsFrameWork
{ 
    public interface IController : IBelongToArchitecture,ICanGetSystem,ICanGetModel,ICanSendCommand,ICanRegisterEvent 
    {
        
    }

    public abstract class AbstractController : IController
    {
        private IArchitecture _architecture;

        IArchitecture IBelongToArchitecture.GetArchitecture() // -+
        {
            return _architecture;
        }
    }
/*
        需要在子类实现接口阉割
      IArchitecture IBelongToArchitecture.GetArchitecture() // -+
        {
            return App.Interface;
        }

 */
}