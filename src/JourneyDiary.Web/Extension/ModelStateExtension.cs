using System.Text;
using System.Web.Mvc;

namespace JourneyDiary.Web.Extension
{
    public static class  ModelStateExtension
    {
        public static string ToErrorMessage(this ModelStateDictionary modelStateDictionary)
        {
            var stringBuilder=new StringBuilder();

            foreach (var value in modelStateDictionary.Values)
            {
                foreach (var error in value.Errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
