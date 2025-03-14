namespace RecetarioWinformsUI.Helpers
{
    internal static class StringHelper
    {
        public static string TrimLongName(string originalString, int maxLenght = 50)
        {
            if(originalString.Length >= maxLenght)
            {
                return $"{ originalString[..maxLenght] }...";
            }

            return originalString;
        }
    }
}
