namespace AsFramework.Utils.SimpleRefCounter
{
    public interface IRefCounter
    {
        int RefCount { get; }
        
        /// <summary>
        /// ref增加
        /// </summary>
        /// <param name="refOwner"></param>
        void Retain(object refOwner = null);
        /// <summary>
        /// ref减少
        /// </summary>
        /// <param name="refOwner"></param>
        void Release(object refOwner = null);
    }
    
    public class SimpleRefCounter : IRefCounter
    {
        public SimpleRefCounter()
        {
            RefCount = 0;
        }

        public int RefCount { get; private set; }
        public void Retain(object refOwner = null)
        {
            RefCount++;
        }

        public void Release(object refOwner = null)
        {
            RefCount--;
            if (RefCount == 0)
            {
                OnZeroRef();
            }
        }

        protected  virtual void OnZeroRef()
        {
        }
    }
}