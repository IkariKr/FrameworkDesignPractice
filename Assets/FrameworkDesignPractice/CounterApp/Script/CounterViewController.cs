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
        private CounterModel mCounterModel;
        
        private void Start()
        {
            btnAdd = transform.Find("BtnAdd").GetComponent<Button>();
            btnSub = transform.Find("BtnSub").GetComponent<Button>();
            countText = transform.Find("CountText").GetComponent<Text>();
            mCounterModel = CounterApp.Get<CounterModel>();
            
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

    public class CounterModel
    {
        public BindableProperty<int> Count = new BindableProperty<int>()
        {
            Value = 0
        };
    }

 
    
}