using System;
using _MyAssets.Scripts.Base;

namespace _MyAssets.Scripts.Character.Enemy.EighthRest
{
    /// <summary>
    /// 全休符の待機ステート
    /// プレイヤーを見つけたらプレイヤーに接近
    /// </summary>
    [Serializable]
    public class EighthRestIdleState : IStateBase
    {
        private EighthRestCtl _ctl;
        private EighthRestStateMachine _stateMachine;

        // ステート遷移前の待機時間
        private float _waitSec = 1f;
        private float _currentSec = 0f;
        
        public EighthRestIdleState(EighthRestCtl ctl, EighthRestStateMachine stateMachine)
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
            var idle = _ctl.CanIdle();

            if (idle)
            {
                // 待機中のとき
                // なにもしない
            }
            else 
            {
                // 待機状態が終わったら
                // ステート遷移
                var state = new EighthRestShotState(_ctl, _stateMachine);
                _stateMachine.Transition(state);
            }
        }

        public void OnStateExit()
        {
        }
    }
}