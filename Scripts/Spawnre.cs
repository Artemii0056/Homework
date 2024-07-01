using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        private const int StartSeparationChance = 100; //Название так себек

        [SerializeField] private Cube _cubePrefab;
        [SerializeField] private Transform _startSpawnPoint;

        private ColorGenerator _colorGenerator;

        private void Start()
        {
            _colorGenerator = new ColorGenerator();

            Spawn(_startSpawnPoint, StartSeparationChance);
            Spawn(_startSpawnPoint, StartSeparationChance);
        }

        private void Spawn(Transform transform, int separationChance) //не spawnPoint
        {
            Cube cube = Instantiate(_cubePrefab, transform.position, Quaternion.identity);
            cube.Init(_colorGenerator.GetRandomColor(), transform, separationChance);

            cube.Destroyed += OnCubeDestroyed;
        }

        private void OnCubeDestroyed(Cube cube)
        {
            int minRandomValue = 2;
            int maxRandomValue = 6;

            if (cube.ChanсeOfSeparation < Random.Range(0, StartSeparationChance))
                return;

            int spawnCount = Random.Range(minRandomValue, maxRandomValue);

            for (int i = 0; i < spawnCount; i++)
            {
                Spawn(cube.transform, cube.ChanсeOfSeparation / 2);
            }

            cube.Destroyed -= OnCubeDestroyed;
        }
    }
}