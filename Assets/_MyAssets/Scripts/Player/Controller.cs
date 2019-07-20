using _MyAssets.Scripts.Note;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace _MyAssets.Scripts.Player
{
    /// <summary>
    /// 
    /// </summary>
    public class Controller: MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Shooter _shooter;

        private int _offset = 0;

        private void Update()
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            
            var dir = new Vector2(h, v);
            
            _player.Move(dir);
            BeatManager.Instance.SpeedCtl(dir.y);
            
            if (Input.GetButtonDown("Fire1"))
            {
                if (_shooter.CanShot())
                    _shooter.Shot();
            }
            else if (Input.GetButton("Fire2"))
            {
                if (_shooter.CanAim())
                    _shooter.Aim();
            }
            else if (Input.GetButtonUp("Fire2"))
            {
                _shooter.Laser();
            }
        }
    }
}