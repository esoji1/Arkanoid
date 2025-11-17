using System.Collections.Generic;
using System.Linq;
using _Project.GameFeatures.EndOfGame;
using UnityEngine;
using Zenject;

namespace _Project.GameFeatures.DestructionTiles
{
    public class CalculationOfTileDestruction : MonoBehaviour
    {
        private EndOfGameManager _endOfGameManager;

        private List<Tile> _tiles = new();
        private int _numberTiles;

        [Inject]
        public void Construct(EndOfGameManager endOfGameManager) =>
            _endOfGameManager = endOfGameManager;

        private void Awake() =>
            ExtractComponents();

        private void Start()
        {
            _numberTiles = _tiles.Count;

            foreach (Tile tile in _tiles)
            {
                tile.OnTileDeath += OnTileDeath;
            }
        }

        private void OnDestroy()
        {
            foreach (Tile tile in _tiles)
            {
                tile.OnTileDeath -= OnTileDeath;
            }
        }

        private void ExtractComponents() =>
            _tiles = GetComponentsInChildren<Tile>().ToList();

        private void OnTileDeath()
        {
            _numberTiles--;

            if (_numberTiles <= 0)
            {
                _endOfGameManager.Victory();
            }
        }
    }
}