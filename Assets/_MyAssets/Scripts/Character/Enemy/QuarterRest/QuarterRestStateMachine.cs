using _MyAssets.Scripts.Base;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Enemy.QuarterRest
{
    public class QuarterRestStateMachine: StateMachineBase
    {
        // 敵キャラクター制御
        [SerializeField] private QuarterRestCtl _ctl;
        
        public void Start()
        { 
            if (_ctl != null)
                _state = new QuarterRestIdleState(_ctl, this);
        }
    }
}