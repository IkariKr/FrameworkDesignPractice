using UnityEngine;

namespace FrameworkDesignPractice
{
    public interface IModel : IBelongToArchitecture
    {
        void Init();
    }
}