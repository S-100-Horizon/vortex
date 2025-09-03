using System.ComponentModel;

namespace S100Framework.Applications
{
    internal interface IDangers
    {
        /// <summary>
        /// Height
        /// </summary>
        [Description("Height")]
        internal double? HEIGHT { get; set; }

        /// <summary>
        /// Value of sounding
        /// </summary>
        [Description("Value of sounding")]
        internal double? VALSOU { get; set; }

        /// <summary>
        /// Water level effect
        /// </summary>
        [Description("Water level effect")]
        internal int? WATLEV { get; set; }


    }
}