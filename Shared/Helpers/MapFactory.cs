using Shared.Models;

namespace Shared.Helpers
{
    public static class MapFactory
    {
        private static char[,]? _map { get; set; }
        public static char[,] GetMap()
        {
            Semaphore semaphore = new Semaphore(1, 1);

            semaphore.WaitOne();

            if (_map == null)
            {
                var mapObj = new Map(30, 30);

                _map = mapObj.InitializeMap();

                Map.Print(_map);
            }

            semaphore.Release();

            return _map;
        }
    }
}
