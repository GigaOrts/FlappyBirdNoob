using System.Collections.Generic;

namespace _Scripts.Core
{
    public class PipeSpawner
    {
        public float SpawnDelay { get; } = 2.3f;
        public List<PipeView> Pipes { get; } = new List<PipeView>();
    }
}