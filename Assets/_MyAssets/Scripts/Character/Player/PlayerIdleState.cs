using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Player
{
    /**
     * プレイヤーのステート
     * アイドル
     */
    public class PlayerIdleState : IStateBase
    {
        private PlayerCtl _playerCtl = null;

        public PlayerIdleState(PlayerCtl playerCtl)
        {
            _playerCtl = playerCtl;
        }
        
        public void OnStateEnter()
        {
            
        }

        public void OnStateUpdate()
        {
            var state = PlayerInput.MouseButtonState;
            var buttonDown = PlayerInput.ButtonDown;
            
            /*if (buttonDown)
            {
                // マウス押下時のみ
                // 弾を発射
                if (_playerCtl != null)
                {
                    _playerCtl.Shot();
                }
            }*/
            
            if (state.Equals(MouseButtonState.Press))
            {
                // マウスを押下中
                if (_playerCtl != null)
                {
                    // 射撃する
                    _playerCtl.ShotCtl();
                    // 移動
                    _playerCtl.MoveCtl(PlayerInput.MouseWorldPoint);
                }
            } else if (state == MouseButtonState.Void)
            {
                // マウスを操作していないとき
                if (_playerCtl != null)
                {
                    // 弾を停止
                    _playerCtl.Idle();
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