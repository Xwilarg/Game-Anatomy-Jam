using UnityEngine;

namespace AnatomyJam.SO
{
    /// <summary>
    /// Represent a zone the character are going through on the 2D view
    /// Party go to the next zone once they beat the boss of the current one
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObject/MapZone", fileName = "MapZone")]
    public class MapZone : ScriptableObject
    {
        [Tooltip("Size of the pixel of a tile")]
        public float PixelSize;

        [Tooltip("Number of line a group of tile contain")]
        public int NbOfLines;

        [Tooltip("Scrolling speed")]
        public float ScrollingSpeed;

        [Tooltip("Y value before object is moved on top")]
        public float MinBeforeReset;
    }
}
