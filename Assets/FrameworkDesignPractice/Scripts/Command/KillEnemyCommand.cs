using System.Drawing;
using FrameworkDesign.Practice;
using UnityEngine;

namespace FrameworkDesignPractice.Scripts.Command
{
    public class KillEnemyCommand : ICommand
    {
        public void Execute()
        {
            PointGame.Get<GameModel>().killCount.Value++;
            if (PointGame.Get<GameModel>().killCount.Value == 10)
            {
                GamePassEvent.Trigger();
            }
        }
    }
}