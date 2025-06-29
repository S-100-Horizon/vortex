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
    public class TestQualityOfBathymetricDataViewModel : QualityOfBathymetricDataViewModel
    {
        private Random _random = new Random();

        protected override void Validate() {
            base.Validate();

            //base.AddError("dataAssessment", "dataAssessment is invalid.");
        }

    }
}
