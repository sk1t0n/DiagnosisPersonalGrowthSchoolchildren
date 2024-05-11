namespace DiagnosisPersonalGrowthSchoolchildren
{
    internal class FakeUser
    {
        public static int[] GetAnswers()
        {
            var answers = new int[91];
            var random = new Random();

            for (var i = 0; i < answers.Length; i++)
            {
                answers[i] = random.Next(-4, 5);
            }

            return answers;
        }
    }
}
