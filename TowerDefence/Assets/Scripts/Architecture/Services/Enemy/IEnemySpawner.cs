namespace Architecture.Services.Enemy
{
    public interface IEnemySpawner
    {
        void SpawnEnemies(int count);
        void SpawnEnemies(int count, int waves,float delay);
    }
}