namespace App.Service.LinkedIn
{
    using App.Common;

    public class LinkedVisibility
    {
        public string Code { get; set; }
        public LinkedVisibility(VisibilityType type)
        {
            this.Code = type.ToString().ToLower();
        }
    }
}