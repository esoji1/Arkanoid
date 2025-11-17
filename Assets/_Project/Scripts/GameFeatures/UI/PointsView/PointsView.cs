using TMPro;
using UnityEngine;

namespace _Project.GameFeatures.UI.PointsView
{
    public class PointsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _pointsText;

        public void AddPoints(string points) =>
            _pointsText.text = points;
    }
}