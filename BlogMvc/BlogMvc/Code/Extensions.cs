namespace BlogMvc.Code
{
    public static class Extensions
    {
        // "this" a sinistra di un parametro di un metodo static:
        // Fa finta che la classe "string" abbia questo metodo,
        // quindi potrò chiamarlo come <mia stringa>.SafeSubstring()
        public static string SafeSubstring(this string input, int length, bool includeEllipsis = true)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            string ellipsis = "";
            if (includeEllipsis && input.Length > length)
                ellipsis = "...";
            length = input.Length;
            return input.Substring(0, length) + ellipsis;
        }
    }
}
