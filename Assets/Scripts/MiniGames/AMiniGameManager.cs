using UnityEngine;

namespace Minigame
{
    public delegate void MinigameCallBack();
    public abstract class AMiniGameManager : MonoBehaviour
    {
        public abstract void RunMinigame(MinigameCallBack cb_result);
    }
}
