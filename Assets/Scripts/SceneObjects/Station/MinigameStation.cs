using AnatomyJam.Player;
using UnityEngine;
using System;

namespace AnatomyJam.SceneObjects.Station
{
    public class MinigameStation : AStation
    {
        [SerializeField]
        private GameObject minigame;
        public override void Deposit(PlayerController pc, SceneObject obj)
        {
            var result = GetRecipe(obj);
            pc.CanMove = false;

            Minigame.MinigameCallBack cb = () =>
            {
                pc.CanMove = true;
                ThrowOnFloor(pc, obj, result);
            };

            minigame.GetComponent<Minigame.AMiniGameManager>()?.RunMinigame(cb, 1);
            // TODO: Launch minigame
            // TODO: Once minigame is complete, call:
            // pc.CanMove = true;
            // ThrowOnFloor(pc, obj, result);
        }

    }
}

