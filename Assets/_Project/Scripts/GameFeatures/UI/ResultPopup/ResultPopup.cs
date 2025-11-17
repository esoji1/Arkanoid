using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Project.GameFeatures.UI.ResultPopup
{
    public class ResultPopup : MonoBehaviour
    {
        private const string VictoryText = "Победа";
        private const string GameOverText = "Поражение";

        [SerializeField] private TMP_Text _resultTileText;
        [SerializeField] private TMP_Text _numberPointsText;
        [SerializeField] private Button _restartButton;

        public event UnityAction OnRestartClicked
        {
            add { _restartButton.onClick.AddListener(value); }
            remove { _restartButton.onClick.RemoveListener(value); }
        }

        public void Show() =>
            gameObject.SetActive(true);
        
        public void ChangeNumberPoints(string numberPoints) => 
            _numberPointsText.text = numberPoints;

        public void ChangeResult(bool isResult) =>
            _resultTileText.text = isResult ? VictoryText : GameOverText;
    }
}