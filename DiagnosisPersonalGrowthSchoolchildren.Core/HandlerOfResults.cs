namespace DiagnosisPersonalGrowthSchoolchildren
{
    public class HandlerOfResults
    {
        public const int NumberOfScales = 13;

        public int[] CalculateResult(int[] data)
        {
            var values = Scales.GetValues();
            var result = new int[NumberOfScales];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = values[i].Item2 ? -data[i] : data[i];
                result[values[i].Item1 - 1] += data[i];
            }

            return result;
        }
    }
}
