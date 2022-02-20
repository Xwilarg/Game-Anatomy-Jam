using AnatomyJam.SO;
using System.Collections;
using TMPro;
using UnityEngine;

namespace AnatomyJam.Manager
{
    public class RetreatManager : MonoBehaviour
    {
        [SerializeField]
        private RetreatInfo _info;

        [SerializeField]
        private FadeImage _blackFade;

        [SerializeField]
        private FadeText _mainText, _subText;

        [SerializeField]
        private TMP_Text _percentText;

        private int _currentRetreatChances;

        private float _timer = -1;
        private int _startChanceNb;


        private void Start()
        {
            /StartCoroutine(LaunchRetreat());
        }

        private IEnumerator LaunchRetreat()
        {
            _startChanceNb = _currentRetreatChances;
            _currentRetreatChances -= _info.RetreatChanceMinus;

            if (Random.Range(0, 100) < _currentRetreatChances)
            {
                // TODO: Gameover
            }

            _mainText.ResetColor();
            _subText.ResetColor();

            _blackFade.LaunchFade(_info.FadeTimeBackground, true);
            yield return new WaitForSeconds(_info.FadeTimeBackground);

            _mainText.LaunchFade(_info.FadeTimeBackground, true);
            yield return new WaitForSeconds(_info.FadeTimeText);
            _mainText.LaunchFade(_info.FadeTimeBackground, true);
            yield return new WaitForSeconds(_info.FadeTimeText);

            _timer = _info.PercentTimer;
            yield return new WaitForSeconds(_info.PercentTimer);

            _blackFade.LaunchFade(_info.FadeTimeBackground, false);
            yield return new WaitForSeconds(_info.FadeTimeBackground);
        }

        private void Update()
        {
            if (_timer > 0f)
            {
                _timer -= Time.deltaTime;
                if (_timer < 0f)
                {
                    _timer = 0f;
                }
                var diff = _startChanceNb - _currentRetreatChances;
                var t = _info.PercentTimer - _timer;
                var nb = _currentRetreatChances + Mathf.RoundToInt(_timer * diff / t);
                _percentText.text = $"{nb}%";
            }
        }
    }
}