using Shared.Models;

namespace Shared.Helpers
{
    public static class CaterPillarFactory
    {
        private static CaterPillar? CaterPillar { get; set; }
        public static CaterPillar GetCaterPillar(bool restart = false)
        {
            Semaphore semaphore = new Semaphore(1, 1);

            semaphore.WaitOne();

            if (restart)
            {
                var map = MapFactory.GetMap();

                CaterPillar = new CaterPillar(map);
            }

            if (CaterPillar == null)
            {
                var map = MapFactory.GetMap();

                CaterPillar = new CaterPillar(map);
            }

            semaphore.Release();

            return CaterPillar;

        }
    }
}
