using AnatomyJam.Player;
using System.Linq;


namespace AnatomyJam.SceneObjects.Station
{
    public class MinigameStation : AStation
    {
        public override void Deposit(PlayerController pc, SceneObject obj)
        {
            var result = _recipes.FirstOrDefault(x => x.Input.ResourceType == obj.Resource);
            if (result != null) // Craft failed
            {
                pc.CanMove = false;
                // TODO: Launch minigame
                // TODO: Once minigame is complete, call:
                // pc.CanMove = false;
                // ThrowOnFloor(pc, obj, result);
            }
        }
    }
}

