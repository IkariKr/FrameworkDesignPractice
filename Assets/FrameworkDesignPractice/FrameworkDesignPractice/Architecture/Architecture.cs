using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesignPractice
{
    public interface IArchitechiture
    {
        void RegisterModel<T>(T model) where T : IModel;
        T GetUtility<T>() where T : class;
    }
    
    /// <summary>
    /// 创建IOC容器
    /// </summary>
    public abstract class Architecture<T> : IArchitechiture where T:Architecture<T>, new()
    {
        protected abstract void Init();
        
        private static T mInstance;

        private bool mInit = false;

        private List<IModel> mModels = new List<IModel>();
        
        static void MakeSureArchitecture()
        {
            if (mInstance == null)
            {
                mInstance = new T();
                mInstance.Init();
                
                foreach (var VARIABLE in mInstance.mModels)
                {
                    VARIABLE.Init();
                }

                mInstance.mModels.Clear();
                mInstance.mInit = true;
                
            }



        }
        
        private IOCContainer mContainer = new IOCContainer();
        
        public static T1 Get<T1>() where T1 : class
        {
            MakeSureArchitecture();
            return mInstance.mContainer.Get<T1>();
        }

        public void Register<T2>(T2 instance)
        {
            MakeSureArchitecture();
            mInstance.mContainer.Register<T2>(instance);
        }

        public void RegisterModel<T1>(T1 model) where T1 : IModel
        {
            model.Architechiture = this;
            mInstance.mContainer.Register<T1>(model);
            if (!mInstance.mInit)
            {
                mModels.Add(model);
            }
            else
            {
                model.Init();
            }
            
        }

        public T GetUtility<T>() where T : class
        {
            return mInstance.mContainer.Get<T>();
        }
    }
}