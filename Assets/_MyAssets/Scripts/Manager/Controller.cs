using _MyAssets.Scripts.Character.Player;
using _MyAssets.Scripts.Note;
using UnityEngine;

namespace _MyAssets.Scripts.Manager
{
    public class Controller: MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Shooter _shooter;

        private int _offset = 0;

        private void FixedUpdate()
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            
            var dir = new Vector2(h, v);
            
            _player.Move(dir);
            
            if (Input.GetButtonDown("Fire1"))
            {
                Shot();
            }
        }

        private void Aim()
        {
            // 照準をあわせる
            NoteManager.Instance.Aim();  
        }

        private void Shot()
        {
            if (NoteManager.Instance.CanShot())
                _shooter.Shot();
        }
    }
}