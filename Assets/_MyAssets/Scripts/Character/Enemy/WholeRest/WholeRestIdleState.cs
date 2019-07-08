using System;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;

namespace _MyAssets.Scripts.Character.Enemy.WholeRest
{
    /// <summary>
    /// 全休符の待機ステート
    /// プレイヤーを見つけたらプレイヤーに接近
    /// </summary>
    [Serializable]
    public class WholeRestIdleState : IStateBase
    {
        private WholeRestCtl _ctl;
        private WholeRestStateMachine _stateMachine;

        // ステート遷移前の待機時間
        private float _waitSec = 1f;
        private float _currentSec = 0f;
        
        public WholeRestIdleState(WholeRestCtl ctl, WholeRestStateMachine stateMachine)
        {
            _ctl = ctl;
            _stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {
        }

        public void OnStateUpdate()
        {
            
        }

        public void OnStateFixedUpdate()
        {
            // アイドル状態を制御
            var idle = _ctl.IdleCtl();
            
            if (!idle)
            {
                // アイドル状態が終わったら
                // ステート遷移
                var state = new WholeRestShotState(_ctl, _stateMachine);
                _stateMachine.Transition(state);
            }
        }

        public void OnStateExit()
        {
        }
    }
}