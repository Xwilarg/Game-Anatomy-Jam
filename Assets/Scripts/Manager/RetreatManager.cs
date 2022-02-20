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


        private void Start()
        {
            //StartCoroutine(LaunchRetreat());
        }

        private IEnumerator LaunchRetreat()
        {
            _mainText.ResetColor();
            _subText.ResetColor();

            _blackFade.LaunchFade(_info.FadeTimeBackground, true);
            yield return new WaitForSeconds(_info.FadeTimeBackground);

            _mainText.LaunchFade(_info.FadeTimeBackground, true);
            yield return new WaitForSeconds(_info.FadeTimeText);
            _mainText.LaunchFade(_info.FadeTimeBackground, true);
            yield return new WaitForSeconds(_info.FadeTimeText);

            _blackFade.LaunchFade(_info.FadeTimeBackground, false);
            yield return new WaitForSeconds(_info.FadeTimeBackground);
        }
    }
}