using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.Gameplay.UI.Scripts
{
    public class CountVisualizer : MonoBehaviour
    {
        [SerializeField] private Text _text;

        [SerializeField] private int _initialCount;
        [SerializeField] private bool _visualizeOnStart;
        [SerializeField] private int _defaultValue;
        [SerializeField] private string _prefix;
        [SerializeField] private string _suffix;

        private void Start()
        {
            if (_visualizeOnStart)
            {
                VisualizeCount(_defaultValue);
            }
        }

        public void VisualizeCount(int count)
        {
            _text.text = $"{_prefix}{_initialCount + count}{_suffix}";
        }
    }
}
