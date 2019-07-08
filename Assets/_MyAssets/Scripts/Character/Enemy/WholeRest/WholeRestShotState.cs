using System;
using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Enemy.WholeRest
{
    /// <summary>
    /// 全休符の射撃ステート
    /// </summary>
    [Serializable]
    public class WholeRestShotState : IStateBase
    {
        private WholeRestCtl _ctl;
        private WholeRestStateMachine _stateMachine;

        // ステート遷移を始める座標
        [SerializeField]
        private int _offsetY = 120;
        // ステート遷移前の待機時間
        private float _waitSec = 1f;
        private float _currentSec = 0f;
        
        public WholeRestShotState(WholeRestCtl ctl, WholeRestStateMachine stateMachine)
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
                var shooting = _ctl.ShotCtl();
                if (shooting)
                {
                    // なにもしない
                }
                else
                {
                    // 射撃が終わったら
                    // ステート遷移
                    var state = new WholeRestExitState(_ctl, _stateMachine);
                    _stateMachine.Transition(state);
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