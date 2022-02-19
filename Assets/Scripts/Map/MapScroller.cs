using AnatomyJam.SO;
using UnityEngine;

namespace AnatomyJam.Map
{
    public class MapScroller : MonoBehaviour
    {
        [SerializeField]
        private Transform[] _background;

        [SerializeField]
        private MapInfo _mapInfo;

        public bool IsScrolling { private get; set; } = true;

        private void FixedUpdate()
        {
            if (IsScrolling)
            {
                foreach (var t in _background)
                {
                    t.Translate(Vector2.down * _mapInfo.ScrollingSpeed);
                    if (t.position.y < _mapInfo.MinBeforeReset)
                    {
                        t.position = new(t.position.x, t.position.y + (_background.Length * _mapInfo.PixelSize * _mapInfo.NbOfLines), t.position.z);
                    }
                }
            }
        }
    }
}
