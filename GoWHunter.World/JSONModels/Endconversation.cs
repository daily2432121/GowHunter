namespace GoWHunter.World.JSONModels
{
    public class Endconversation
    {
        public int NumSteps { get; set; }
        public string[] StepActions { get; set; }
        public int[] StepCharacters { get; set; }
        public string[] StepTexts { get; set; }
    }
}