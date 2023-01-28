namespace RateMatch.Mvc.Data
{
    //this classed is used for select list of rating //
    public class RatingChoice
    {
        public RatingChoice(int value, string choiceCaption)
        {
            Value = value;
            ChoiceCaption = choiceCaption;
        }
        public override string ToString()
        {
            return this.Value + " - " + ChoiceCaption;
        }

        public int Value { get; set; } = 0;
        public string ChoiceCaption { get; set; } = "";
    }




}
