using AnatomyJam.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AnatomyJam.SceneObjects.Station
{
    public class MinigameStation : AStation
    {
        [SerializeField]
        private Minigame.AMiniGameManager minigame;

        [SerializeField]
        private GameObject minigameBG;
        public override void Deposit(PlayerController pc, SceneObject obj)
        {
            var result = GetRecipe(obj);
            pc.CanMove = false;

            minigameBG.SetActive(true);
           // minigame.SetActive(true);
            Minigame.MinigameCallBack cb = () =>
            {
                minigameBG.SetActive(false);
                pc.CanMove = true;
                ThrowOnFloor(pc, obj, result);
            };
            minigame.RunMinigame(cb, 1);
            // TODO: Launch minigame
            // TODO: Once minigame is complete, call:
            // pc.CanMove = true;
            // ThrowOnFloor(pc, obj, result);
        }

    }
}

