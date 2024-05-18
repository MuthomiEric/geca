using Shared.Models;

namespace Shared.Helpers
{
    public static class CaterPillarFactory
    {
        private static CaterPillar? CaterPillar { get; set; }
        public static CaterPillar GetCaterPillar()
        {
            Semaphore semaphore = new Semaphore(1, 1);

            semaphore.WaitOne();

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
