using System;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _MyAssets.Scripts.Character.Enemy
{
    /// <summary>
    /// 時間待機ステート
    /// 指定時間を待機する
    /// </summary>
    [Serializable]
    public class TimeState : StateBase
    {
        [SerializeField]
        private SerialStateMachine _stateMachine;
        
        // 遷移時間
        [SerializeField] private float _duration = 4f;

        public override void OnStateUpdate()
        {
            // 時間経過
            _duration -= Time.deltaTime;

            if (_duration < 0)
            {
                // 指定時間が経過したら
                if (_stateMachine != null)
                    _stateMachine.Next();
            }
        }
    }
}