using System;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Enemy.EighthRest
{
    /// <summary>
    /// 全休符の射撃ステート
    /// </summary>
    [Serializable]
    public class EighthRestShotState : IStateBase
    {
        private EighthRestCtl _ctl;
        private EighthRestStateMachine _stateMachine;

        // ステート遷移を始める座標
        [SerializeField]
        private int _offsetY = 120;
        // ステート遷移前の待機時間
        private float _waitSec = 1f;
        private float _currentSec = 0f;
        
        public EighthRestShotState(EighthRestCtl ctl, EighthRestStateMachine stateMachine)
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
                // 射撃をする
                _ctl.ShotCtl();
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