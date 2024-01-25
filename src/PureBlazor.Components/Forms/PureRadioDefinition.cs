namespace PureBlazor.Components.Forms
{
    public class PureRadioDefinition
    {
        public string Name
        {
            //Remove spacial characeres?
            //Remove spaces in between?
            get { return Title.Trim(); }            
        }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsChecked { get; set; } = false;
    }
}