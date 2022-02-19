using AnatomyJam.Character;
using AnatomyJam.Player;
using System.Linq;
using UnityEngine;


namespace AnatomyJam.SceneObjects.Station
{
    public class TimerStation : AStation
    {
        [SerializeField]
        private ProgressBar _progress;

        private float _timer = -1f;

        private SceneObject _obj;
        private PlayerController _pc;

        private const float _maxTimer = 3f;

        public override void Deposit(PlayerController pc, SceneObject obj)
        {
            _pc = pc;
            _obj = obj;
            _timer = _maxTimer;
            _progress.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (_timer > 0f)
            {
                _timer -= Time.deltaTime;
                if (_timer <= 0f)
                {
                    _timer = 0f;
                    var result = _recipes.FirstOrDefault(x => x.Input.ResourceType == _obj.Resource);
                    if (result != null) // Craft failed
                    {
                        _obj.Resource = result.Output.ResourceType;
                        _obj.GameObject = Instantiate(result.Output.GameObject, _output.position, Random.rotation);
                        var opDir = (_output.position - transform.position).normalized;
                        _obj.GameObject.GetComponent<Rigidbody>().AddForce((opDir + Vector3.up).normalized * 2f, ForceMode.Impulse);
                        _obj.GameObject.GetComponent<Interactible>().AddListener(() =>
                        {
                            Destroy(_obj.GameObject);
                            _pc.ResetInteraction();
                            var instance = ScriptableObject.CreateInstance<SO.ObjectInfo>();
                            instance.GameObject = result.Output.GameObject;
                            instance.Gem = _obj.Gem;
                            instance.Metal = _obj.Metal;
                            instance.ResourceType = _obj.Resource;
                            instance.Name = result.Output.Name;
                            _pc.AddObjectInHands(instance);
                        });
                    }
                    _progress.gameObject.SetActive(false);
                }
                else
                {
                    _progress.SetValue(_timer / _maxTimer);
                }
            }
        }
    }
}

