using System.Collections.Generic;

namespace Danil.Scripts
{
    public static class AllStatic
    {
        public static readonly string DRINK = "я не буду пить";
        public static readonly string SMOKE = "я не буду курить";
        public static readonly string USE = "я не буду употреблять";

        public static readonly List<char> ALPHABET = new List<char>()
        {
            'й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ', 
            'ф', 'ы', 'в', 'а', 'п', 'р', 'о', 'л', 'д', 
            'ж', 'э', 'я', 'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю', 'ё'
        };

        public static int LEVEL;
    }
}