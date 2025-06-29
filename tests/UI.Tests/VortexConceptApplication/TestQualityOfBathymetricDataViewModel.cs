using S100Framework.WPF.ViewModel.S101;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexConceptApplication
{
    public class TestQualityOfBathymetricDataViewModel : QualityOfBathymetricDataViewModel, INotifyDataErrorInfo
    {
        private Random _random = new Random();

        [Browsable(false)]
        public bool HasErrors => true;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;


        public IEnumerable GetErrors(string? propertyName) {
            return propertyName switch {
                "HasErrors" => Enumerable.Empty<string>(),
                "featuresDetected" => Enumerable.Empty<string>(),
                "surveyDataRange" => Enumerable.Empty<string>(),
                "dataAssessment" or "information" or "fullSeafloorCoverageAchieved" => new string[] { "Error" },
                _ => Enumerable.Empty<string>(),
                //_ =>  _random.Next(0,99) < 50 ? Enumerable.Empty<string>() : new string[] { "Yellow" },
            };
        }
    }
}
