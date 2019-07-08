using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Character.Enemy.EighthRest;
using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Enemy.WholeRest
{
    /// <summary>
    /// 全休符のステートマシン
    /// </summary>
    public class WholeRestStateMachine: StateMachineBase
    {
        // 敵キャラクター制御
        [SerializeField] private WholeRestCtl _ctl;
        
        public void Start()
        { 
            if (_ctl != null)
                _state = new WholeRestIdleState(_ctl, this);
        }
    }
}