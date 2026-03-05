namespace S100Framework.Applications
{

    public class DisplayScale
    {
        public int MaximumDisplayScale { get; set; }
        public int OptimumDisplayScale { get; set; }
        public int? MinimumDisplayScale { get; set; } = null;

        public static readonly Dictionary<int, DisplayScale> DisplayScales = new Dictionary<int, DisplayScale>
        {
            { 10000000, new DisplayScale(10000000, 10000000, null) },
            { 3500000, new DisplayScale(3500000, 3500000, 10000000) },
            { 1500000, new DisplayScale(1500000, 1500000, 3500000) },
            { 700000, new DisplayScale(700000, 700000, 1500000) },
            { 350000, new DisplayScale(350000, 350000, 700000) },
            { 180000, new DisplayScale(180000, 180000, 350000) },
            { 90000, new DisplayScale(90000, 90000, 180000) },
            { 45000, new DisplayScale(45000, 45000, 90000) },
            { 22000, new DisplayScale(22000, 22000, 45000) },
            { 12000, new DisplayScale(12000, 12000, 22000) },
            { 8000, new DisplayScale(8000, 8000, 12000) },
            { 4000, new DisplayScale(4000, 4000, 8000) },
            { 3000, new DisplayScale(3000, 3000, 4000) },
            { 2000, new DisplayScale(2000, 2000, 3000) },
            { 1000, new DisplayScale(1000, 1000, 2000) }
        };

        public DisplayScale(int maximumDisplayScale, int optimumDisplayScale, int? minimumDisplayScale) {
            this.MaximumDisplayScale = maximumDisplayScale;
            this.OptimumDisplayScale = optimumDisplayScale;
            this.MinimumDisplayScale = minimumDisplayScale;
        }

        public static DisplayScale? GetDisplayScale(string series) {
            DisplayScale scale = series.ToUpperInvariant() switch {
                "DK4" or "GL4" => new DisplayScale(11000, 22000, 10000000),
                "DK5" or "GL5" => new DisplayScale(6000, 12000, 22000),

                "US4" => new DisplayScale(22000, 45000, 10000000),

                //"dk4" => new DisplayScale(11000, 22000, 90000),
                //"dk5" => new DisplayScale(6000, 12000, 22000),
                //"gl4" => new DisplayScale(11000, 22000, 90000),
                //"gl5" => new DisplayScale(6000, 12000, 22000),
                _ => throw new Exception("unknown series")

            };
            return scale;
        }

        /// <summary>
        /// Deprecated
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static DisplayScale? GetNearestBelowKey(int key) {
            // Find all keys less than or equal to the provided key
            var nearestKey = DisplayScales.Keys
                                          .Where(k => k <= key)
                                          .OrderByDescending(k => k)
                                          .FirstOrDefault();

            // If a key is found, return the corresponding DisplayScale; otherwise, return null
            return nearestKey != 0 ? DisplayScales[nearestKey] : null;
        }

    }
}
