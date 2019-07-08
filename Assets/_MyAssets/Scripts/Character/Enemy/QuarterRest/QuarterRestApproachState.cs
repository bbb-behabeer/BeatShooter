using System;
using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Enemy.QuarterRest
{
    /// <summary>
    /// プレイヤーへ接近するステート
    /// </summary>
    [Serializable]
    public class QuarterRestApproachState: IStateBase
    {
        private QuarterRestCtl _ctl;
        private QuarterRestStateMachine _stateMachine;

        [SerializeField] private float _waitSec = 2f;
        private float _currentSec = 0;

        [SerializeField] private int _approachCnt = 10;
        private int _cnt = 0;

        public QuarterRestApproachState(QuarterRestCtl ctl, QuarterRestStateMachine stateMachine)
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
                _ctl.LookAtPlayer();
                
                _currentSec += Time.deltaTime;

                if (_currentSec > _waitSec)
                {
                    _currentSec = 0;
                    // プレイヤーへの接近を開始する。
                    _ctl.StartApproach();
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