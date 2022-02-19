using UnityEngine;

namespace AnatomyJam.SO
{
    [CreateAssetMenu(menuName = "ScriptableObject/MapInfo", fileName = "MapInfo")]
    public class MapInfo : ScriptableObject
    {
        /// <summary>
        /// Size of the pixel of a tile
        /// </summary>
        public float PixelSize;
        /// <summary>
        /// Number of line a group of tile contain
        /// </summary>
        public int NbOfLines;
        /// <summary>
        /// Scrolling speed
        /// </summary>
        public float ScrollingSpeed;

        /// <summary>
        /// Y value before object is moved on top
        /// </summary>
        public float MinBeforeReset;
    }
}
