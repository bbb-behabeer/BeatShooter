using _MyAssets.Scripts.Base;
using UnityEngine;

namespace _MyAssets.Scripts.Character.Player
{ 
    /**
     * プレイヤーのステートマシン
    */
    public class PlayerStateMachine: StateMachineBase
    {
        // プレイヤー制御
        [SerializeField] private PlayerCtl _PlayerCtl;
        
        public void Start()
        { 
            _state = new PlayerIdleState(_PlayerCtl);
        }

    }
}