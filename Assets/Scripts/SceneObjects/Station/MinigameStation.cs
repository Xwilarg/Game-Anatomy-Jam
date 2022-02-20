using AnatomyJam.Material;
using AnatomyJam.Player;
using TMPro;
using UnityEngine;

namespace AnatomyJam.SceneObjects.Station
{
    public class MinigameStation : AStation
    {
        [SerializeField]
        private Minigame.AMiniGameManager minigame;

        [SerializeField]
        private StationPolishAction _polish;

        [SerializeField]
        private GameObject minigameBG;

        public override bool IsValid(SceneObject obj)
        {
            if (obj.GetComponentInChildren<TMP_Text>() == null) return true;
            if (_polish == StationPolishAction.None)
            {
                return true;
            }
            if (_polish == StationPolishAction.Sharpen) // Sharpen add a +
            {
                return !obj.GetComponentInChildren<TMP_Text>().text.Contains('+');
            }
            return !obj.GetComponentInChildren<TMP_Text>().text.Contains('2');
        }

        public override void Deposit(PlayerController pc, SceneObject obj)
        {
            var result = GetRecipe(obj);
            pc.CanMove = false;

            float val = 0f;
            var armor = obj.GetComponent<Armor>();
            if (armor != null)
            {
                val = armor.Value + .5f;
            }

            minigameBG.SetActive(true);
           // minigame.SetActive(true);
            Minigame.MinigameCallBack cb = () =>
            {
                minigameBG.SetActive(false);
                pc.CanMove = true;
                ThrowOnFloor(pc, obj, result, val, _polish);
            };
            minigame.RunMinigame(cb, 1);
        }

    }
}

