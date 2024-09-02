using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Cube _cubePrefab;

        [SerializeField] private List<Cube> _cubes;

        private ColorGenerator _colorGenerator;

        private void Start() =>
            _colorGenerator = new ColorGenerator();

        private void OnEnable()
        {
            foreach (var cube in _cubes)
                cube.Destroyed += OnCubeDestroyed;
        }

        private Cube Spawn(Transform transform, int separationChance)
        {
            int scaleDivider = 2;

            Cube cube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
            cube.Init(_colorGenerator.GetRandomColor(), transform.localScale / scaleDivider, separationChance);

            cube.Destroyed += OnCubeDestroyed;

            return cube;
        }

        private void OnCubeDestroyed(Cube cube)
        {
            cube.Destroyed -= OnCubeDestroyed;
            
            if (cube.ChanсeOfSeparation < Random.Range(0, cube.MaxChanсeOfSeparation))
                return;

            Explode(cube.transform.position, SpawnCubes(cube));

        }

        private List<Cube> SpawnCubes(Cube cube)
        {
            int chanceDivider = 2;

            int minRandomValue = 2;
            int maxRandomValue = 6;

            int spawnCount = Random.Range(minRandomValue, maxRandomValue + 1);

            List<Cube> cubes = new List<Cube>();

            for (int i = 0; i < spawnCount; i++)
                cubes.Add(Spawn(cube.transform, cube.ChanсeOfSeparation / chanceDivider));

            return cubes;
        }

        private void Explode(Vector3 position, List<Cube> cubes)
        {
            int force = 100;
            int radius = 20;

            foreach (var cube in cubes)
                cube.Rigidbody.AddExplosionForce(force, position, radius);
        }
    }
}