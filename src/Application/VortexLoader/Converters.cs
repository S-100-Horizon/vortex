using ArcGIS.Core.Data;

namespace VortexLoader
{

    public class ConverterRegistry
    {
        // The extra object is an additional parameter to the converter
        private readonly Dictionary<(Type from, Type to), Func<object, int?, Geodatabase, object>> _converters = [];

        public void Register<TFrom, TTo>(Func<TFrom, int?, Geodatabase, TTo> converter) {
            if (converter == null) {
                throw new ArgumentNullException(nameof(converter));
            }

            this._converters[(typeof(TFrom), typeof(TTo))] = (input, scaleMinimum, geodatabase) => converter((TFrom)input, scaleMinimum, geodatabase)!;
        }

        public TOut Convert<TOut>(object value, int? scaleMinimum = default(int?), Geodatabase geodatabase = null!) {
            var fromType = value.GetType();
            var toType = typeof(TOut);

            if (this._converters.TryGetValue((fromType, toType), out var converter)) {
                return (TOut)converter(value, scaleMinimum, geodatabase);
            }

            throw new InvalidOperationException($"No converter registered from {fromType.Name} to {toType.Name}");
        }

        public object Convert(object value, Type toType, int? scaleMinimum/* = default(int?)*/, Geodatabase geodatabase = null!) {
            var fromType = value.GetType();

            if (this._converters.TryGetValue((fromType, toType), out var converter)) {
                return converter(value, scaleMinimum, geodatabase);
            }

            //return null;
            // TODO: 'No converter registered from PortsAndServicesP to SignalStationTraffic'
            throw new InvalidOperationException($"No converter registered from {fromType.Name} to {toType.Name}");
        }
    }


    //public TOut ConvertList<TOut>(IList<S100Framework.Applications.S57.esri.AidsToNavigationP> related, IList<object> values) {
    //    var fromType = values.First().GetType();
    //    var toType = typeof(TOut);

    //    if (!_listConverters.ContainsKey((fromType, toType))) {
    //        throw new InvalidOperationException($"No converter registered from {fromType.Name} to {toType.Name}");
    //    }

    //    var converter = _listConverters[(fromType, toType)];
    //    return (TOut)converter(values);
    //}

    //public object ConvertList(IList<object> values, Type toType) {
    //    var fromType = values.First().GetType();

    //    if (!_listConverters.ContainsKey((fromType, toType))) {
    //        throw new InvalidOperationException($"No converter registered from {fromType.Name} to {toType.Name}");
    //    }

    //    var converter = _listConverters[(fromType, toType)];
    //    return converter(values);
    //}
}



//public class ConverterRegistry
//{
//    private readonly Dictionary<(Type from, Type to), Func<object, object>> _converters = new();

//    public void Register<TFrom, TTo>(Func<TFrom, TTo> converter) {
//        _converters[(typeof(TFrom), typeof(TTo))] = input => converter((TFrom)input);
//    }

//    public TOut Convert<TOut, TIn>(object value) {
//        var fromType = typeof(TIn);
//        var toType = typeof(TOut);

//        if (_converters.TryGetValue((fromType, toType), out var converter)) {
//            return (TOut)converter((TIn)value);
//        }

//        throw new InvalidOperationException($"No converter registered from {fromType.Name} to {toType.Name}");
//    }
//    public object Convert(object value, Type fromType, Type toType) {
//        if (_converters.TryGetValue((fromType, toType), out var converter)) {
//            return converter(value);
//        }

//        throw new InvalidOperationException($"No converter registered from {fromType.Name} to {toType.Name}");
//    }
//}




