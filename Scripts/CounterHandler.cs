using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class CounterHandler : MonoBehaviour
    {
        [SerializeField] private Counter _counter;
        [SerializeField] private ButtonListener _buttonListener;

        [SerializeField] private TextMeshProUGUI _text;

        private bool _counterIsActive;

        private void Start()
        {
            _text.text = 0.ToString();
            _counterIsActive = false;
        }

        private void OnEnable()
        {
            _buttonListener.Clicked += OnClicked;
            _counter.Changed += OnChanged;
        }

        private void OnDisable()
        {
            _buttonListener.Clicked -= OnClicked;
            _counter.Changed -= OnChanged;
        }

        private void OnChanged(int value) =>
            _text.text = value.ToString();

        private void OnClicked()
        {
            _counterIsActive = !_counterIsActive;

            if (_counterIsActive == true)
                _counter.StartTimer();
            else
                _counter.StopTimer();
        }
    }
}