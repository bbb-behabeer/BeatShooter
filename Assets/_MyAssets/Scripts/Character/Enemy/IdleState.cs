using System;
using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

namespace _MyAssets.Scripts.Character.Enemy
{
    /// <summary>
    /// 待機ステート
    /// オフセットの位置で次のステートへ
    /// </summary>
    [Serializable]
    public class IdleState : MonoBehaviour, IStateBase
    {
        // オフセット
        [SerializeField] private float _offset = 100f;
        
        // ステートマシン
        [SerializeField]
        private SerialStateMachine _stateMachine;

        public void OnStateEnter()
        {
        }

        public void OnStateUpdate()
        {
            // オフセットまで待機
            if (transform.position.y < _offset)
            {
                // オフセットに入ったら
                // ステート遷移する
                _stateMachine.Next();
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