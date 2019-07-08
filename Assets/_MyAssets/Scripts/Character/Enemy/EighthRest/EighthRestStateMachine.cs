using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Character.Enemy.WholeRest;
using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Enemy.EighthRest
{
    /// <summary>
    /// 全休符のステートマシン
    /// </summary>
    public class EighthRestStateMachine: StateMachineBase
    {
        // 敵キャラクター制御
        [SerializeField] private EighthRestCtl _ctl;
        
        public void Start()
        { 
            if (_ctl != null)
                _state = new EighthRestIdleState(_ctl, this);
        }
    }
}