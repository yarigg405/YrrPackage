using TMPro;
using UnityEngine;
using Yrr.Utils;

namespace Yrr.UI.Elements
{
    public sealed class TickableText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tmp;
        private string _preffix;
        private string _postfix;
        private float _targetCounter;
        private float _counter;



        private void Update()
        {
            if (_targetCounter == _counter) return;

            var delta = Mathf.Abs(_targetCounter - _counter) * 2;
            if (delta < 10) delta = 10;

            _counter = Mathf.MoveTowards(_counter, _targetCounter, delta * Time.unscaledDeltaTime);
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            tmp.text = $"{_preffix}{_counter.ToIntString()}{_postfix}";
        }

        public void InitValue(int value)
        {
            _targetCounter = value;
            _counter = value;
            UpdateVisual();
        }

        public void SmoothChangeValue(int value)
        {
            _targetCounter = value;
        }

        public void SetPreffix(string preffix)
        {
            _preffix = preffix;
        }

        public void SetPostfix(string postfix)
        {
            _postfix = postfix;
        }
    }
}
