namespace TestLua
{
    public class UnitTest1
    {
        [Fact]
        public void Test1() {
            string lua = @"
                    function validate(instance)
                        if instance == nil then
                            return false
                        end
                        if instance.dataAssessment == nil then
                            return false
                        elseif instance.dataAssessment < 0 then
                            return false
                        end
                        return true
                    end     

                    return validate(Instance)
                ";

            //var qualityOfBathymetricData = new QualityOfBathymetricData {
            //    categoryOfTemporalVariation = default,
            //    dataAssessment = default,
            //    featuresDetected = default,
            //    fullSeafloorCoverageAchieved = default,
            //};

            //UserData.RegisterType<QualityOfBathymetricData>();
            //var dynvalye = UserData.Create(qualityOfBathymetricData);


            //var script = new Script();
            //script.Globals["Instance"] = dynvalye;

            //var result = script.DoString(lua);

            System.Diagnostics.Debugger.Break();

        }
    }
}