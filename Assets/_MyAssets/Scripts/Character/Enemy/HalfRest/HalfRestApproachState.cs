using System;
using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Enemy.HalfRest
{
    /// <summary>
    /// プレイヤーへ接近するステート
    /// </summary>
    [Serializable]
    public class HalfRestApproachState: IStateBase
    {
        private HalfRestCtl _ctl;
        private HalfRestStateMachine _stateMachine;

        [SerializeField] private float _waitSec = 1f;
        private float _currentSec = 0;

        [SerializeField] private int _approachCnt = 10;
        private int _cnt = 0;

        public HalfRestApproachState(HalfRestCtl ctl, HalfRestStateMachine stateMachine)
        {
            _ctl = ctl;
            _stateMachine = stateMachine;
        }
        
        public void OnStateEnter()
        {
        }

        public void OnStateUpdate()
        {
            if (_ctl != null)
            {
                if (_currentSec == 0f)
                {
                    // 角度を変えてプレイヤーに接近する
                    _ctl.StartApproach();
                }
                
                _currentSec += Time.deltaTime;

                if (_currentSec > _waitSec)
                {
                    _currentSec = 0;
                    _cnt++;
                }

                if (_cnt > _approachCnt)
                {
                    // アプローチ回数を超えたら
                    // プレイヤーへの接近を終了
                    _ctl = null;
                }
            }
        }

        public void OnStateFixedUpdate()
        {
        }

        public void OnStateExit()
        {
        }
    }
}