using AnatomyJam.Player;


namespace AnatomyJam.SceneObjects.Station
{
    public class MinigameStation : AStation
    {
        public override void Deposit(PlayerController pc, SceneObject obj)
        {
            var result = GetRecipe(obj);
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

