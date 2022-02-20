using AnatomyJam.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace AnatomyJam.SceneObjects.Station
{
    public class MinigameStation : AStation
    {
        [SerializeField]
        private GameObject minigame;

        [SerializeField]
        private GameObject minigameBG;
        public override void Deposit(PlayerController pc, SceneObject obj)
        {
            var result = GetRecipe(obj);
            pc.CanMove = false;

            PlayerInput PI = minigame.GetComponent<PlayerInput>();

            minigameBG.SetActive(true);
           // minigame.SetActive(true);
            Minigame.MinigameCallBack cb = () =>
            {
                minigameBG.SetActive(false);
                pc.CanMove = true;
                ThrowOnFloor(pc, obj, result);
            };
            Minigame.AMiniGameManager manager = minigame.GetComponent<Minigame.AMiniGameManager>();
            manager.RunMinigame(cb, 1);
            // TODO: Launch minigame
            // TODO: Once minigame is complete, call:
            // pc.CanMove = true;
            // ThrowOnFloor(pc, obj, result);
        }

    }
}

