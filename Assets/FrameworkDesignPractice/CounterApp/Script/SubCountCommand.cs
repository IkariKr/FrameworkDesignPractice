using FrameworkDesignPractice;
using UnityEngine;

namespace FrameworkDesign.Practice
{
    public class SubCountCommand : ICommand
    {
        public void Execute()
        {
            CounterApp.Get<CounterModel>().Count.Value--;
        }
    }
}