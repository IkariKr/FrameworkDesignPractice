using System;
using FrameworkDesignPractice;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Practice
{
    public class CounterViewController : MonoBehaviour
    {
        private Button btnAdd;
        private Button btnSub;
        private Text countText;
        private ICounterModel mCounterModel;
        
        private void Start()
        {
            btnAdd = transform.Find("BtnAdd").GetComponent<Button>();
            btnSub = transform.Find("BtnSub").GetComponent<Button>();
            countText = transform.Find("CountText").GetComponent<Text>();
            
            mCounterModel = CounterApp.Get<ICounterModel>();
            
            btnAdd.onClick.AddListener(() =>
            {
                new AddCountCommand().Execute();
            });
            
            btnSub.onClick.AddListener(() =>
            {
                new SubCountCommand().Execute();
            });
            
            mCounterModel.Count.OnValueChangedEvent += OnCountChanged;

            OnCountChanged(mCounterModel.Count.Value);//初始化

        }

        private void OnCountChanged(int value)
        {
            countText.text = value.ToString();
        }


        private void OnDestroy()
        {
            mCounterModel.Count.OnValueChangedEvent -= OnCountChanged;
        }
    }

    public interface ICounterModel : IModel
    {
        BindableProperty<int> Count { get; }
    }

    public class CounterModel:ICounterModel
    {
        public BindableProperty<int> Count { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        public IArchitechiture Architechiture { get; set; }
        public void Init()
        {
            Count.Value = Architechiture.GetUtility<IStorage>().LoadInt("COUNTER_VALUE", 0);
            Count.OnValueChangedEvent += count =>
            {
                Architechiture.GetUtility<IStorage>().SaveInt("COUNTER_VALUE", count);
            };
        }
    }

 
    
}