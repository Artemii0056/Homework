using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Purchasing;

namespace DefaultNamespace
{
    public class Counter : MonoBehaviour
    {
        private WaitForSeconds _waitForSeconds;
        private float _delay = 0.5f;
        private int _timeCounter;

        private Coroutine _coroutine;

        public event Action<int> Changed;

        private void Start() =>
            _waitForSeconds = new WaitForSeconds(_delay);

        public void StopTimer()
        {
            if (_coroutine == null)
                throw new NullReceiptException();

            StopCoroutine(_coroutine);
        }

        public void StartTimer()
        {
            _coroutine = StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            while (true)
            {
                yield return _waitForSeconds;

                _timeCounter++;
                Changed?.Invoke(_timeCounter);
            }
        }
    }
}