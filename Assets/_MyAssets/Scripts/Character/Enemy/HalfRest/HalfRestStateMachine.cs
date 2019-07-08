using _MyAssets.Scripts.Base;
using _MyAssets.Scripts.Common;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Enemy.HalfRest
{
    public class HalfRestStateMachine: StateMachineBase
    {
        // 敵キャラクター制御
        [SerializeField] private HalfRestCtl _ctl;
        
        public void Start()
        { 
            if (_ctl != null)
                _state = new HalfRestIdleState(_ctl, this);
        }
    }
}