using System;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Character.Enemy.HalfRest;

namespace _MyAssets.Scripts.Character.Enemy.QuarterRest
{
    /// <summary>
    /// 4分休符の待機ステート
    /// プレイヤーを見つけたらプレイヤーに接近
    /// </summary>
    [Serializable]
    public class QuarterRestIdleState : IStateBase
    {
        private QuarterRestCtl _ctl;
        private QuarterRestStateMachine _stateMachine;

        public QuarterRestIdleState(QuarterRestCtl ctl, QuarterRestStateMachine stateMachine)
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
                var state = new QuarterRestApproachState(_ctl, _stateMachine);
                _stateMachine.Transition(state);
            }
        }

        public void OnStateExit()
        {
        }
    }
}