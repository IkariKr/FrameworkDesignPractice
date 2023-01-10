using UnityEngine;

namespace FrameworkDesignPractice
{
    /// <summary>
    /// 创建IOC容器
    /// </summary>
    public abstract class Architecture<T> where T:Architecture<T>, new()
    {
        protected abstract void Init();
        
        private static T mArchitecture;

        static void MakeSureArchitecture()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();//为何这里可以用静态成员调用自己的方法？
            }
        }
        
        private IOCContainer mContainer = new IOCContainer();
        
        public static T Get<T>() where T : class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }

        public void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }
        
    }
}