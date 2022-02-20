using UnityEngine;

namespace AnatomyJam.SO
{
    [CreateAssetMenu(menuName = "ScriptableObject/RetreatInfo", fileName = "RetreatInfo")]
    public class RetreatInfo : ScriptableObject
    {
        public float FadeTimeBackground;
        public float FadeTimeText;
    }
}
