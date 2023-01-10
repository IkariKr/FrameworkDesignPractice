using FrameworkDesignPractice;
using UnityEngine;

namespace FrameworkDesign.Practice
{
    public class GameModel
    {
        public BindableProperty<int> killCount = new BindableProperty<int>();
        public BindableProperty<int> Gold = new BindableProperty<int>();
        public BindableProperty<int> Score = new BindableProperty<int>();
        public BindableProperty<int> BestScore = new BindableProperty<int>();
    }
}