using UnityEngine;
using FrameworkDesignPractice;

namespace FrameworkDesign.Practice
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            Register(new CounterModel());
        }
    }
}