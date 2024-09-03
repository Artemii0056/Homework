using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ColorGenerator
    {
        private List<Color> _colors;

        public ColorGenerator()
        {
            _colors = new List<Color>();
            Fill();
        }

        public Color GetRandomColor() => 
            _colors[Random.Range(0, _colors.Count)];

        private void Fill()
        {
            _colors.Add(Color.blue);
            _colors.Add(Color.cyan);
            _colors.Add(Color.green);
            _colors.Add(Color.red);
            _colors.Add(Color.yellow);
            _colors.Add(Color.white);
            _colors.Add(Color.magenta);
        }
    }
}