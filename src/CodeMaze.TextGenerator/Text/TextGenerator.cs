using System;
using System.Security.Cryptography;
using System.Text;

namespace CodeMaze.TextGenerator
{
    public sealed class TextGenerator
    {
        internal static readonly string _lower_chars = "abcdefghijklmnopqrstuvwxyz";
        internal static readonly string _uper_chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        internal static readonly string _number_chars = "0123456789";
        internal static readonly string _special_chars = "!@#$%^&*";
        internal static readonly string _hex_chars = "123456789ABCDEF";

        private static char[] GenerateChars(bool useLowerCase = true, bool useUperCase = true, bool useNumbers = true, bool useSpecial = true, bool useHex = false)
        {
            var builder = new StringBuilder();

            if (useLowerCase) builder.Append(_lower_chars);
            if (useUperCase) builder.Append(_uper_chars);
            if (useNumbers) builder.Append(_number_chars);
            if (useSpecial) builder.Append(_special_chars);
            if (useHex) builder.Append(_hex_chars);

            return builder.ToString().ToCharArray();
        }

        private static string RandomeGenerator(int size, char[] chars)
        {
            byte[] data = new byte[4 * size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        public static string Builder(int size)
        {
            var chars = GenerateChars(true, true, true, false, false);
            return RandomeGenerator(size, chars);
        }

        public static string TextBuilder(int size, TextType type)
        {
            char[] chars;

            switch (type)
            {
                case TextType.TextRandom:
                    chars = GenerateChars(true, true, true, false, false);
                    break;

                case TextType.TextUperCase:
                    chars = GenerateChars(false, true, false, false, false);
                    break;

                case TextType.TextLowerCase:
                    chars = GenerateChars(true, false, false, false, false);
                    break;

                case TextType.Numbers:
                    chars = GenerateChars(false, false, true, false, false);
                    break;

                default:
                    chars = GenerateChars(true, true, true, false, false);
                    break;
            }

            return RandomeGenerator(size, chars);
        }

        public static string KeygenBuilder(KeygenType type)
        {
            char[] chars;

            switch (type)
            {
                case KeygenType.MemorablePassword:
                    chars = GenerateChars(true, true, true, false, false);
                    return RandomeGenerator(10, chars);

                case KeygenType.StrongPassword:
                    chars = GenerateChars(true, true, true, true, false);
                    return RandomeGenerator(15, chars);

                case KeygenType.FortKnoxPassword:
                    chars = GenerateChars(true, true, true, true, false);
                    return RandomeGenerator(30, chars);

                case KeygenType.CodeIgniterEncrytion:
                    chars = GenerateChars(true, true, true, false, false);
                    return RandomeGenerator(32, chars);

                case KeygenType.WPA_160bit:
                    chars = GenerateChars(true, true, true, true, false);
                    return RandomeGenerator(20, chars);

                case KeygenType.WPA_504bit:
                    chars = GenerateChars(true, true, true, true, false);
                    return RandomeGenerator(63, chars);

                case KeygenType.WEP_64bit:
                    chars = GenerateChars(false, false, false, false, true);
                    return RandomeGenerator(5, chars);

                case KeygenType.WEP_128bit:
                    chars = GenerateChars(false, false, false, false, true);
                    return RandomeGenerator(13, chars);

                case KeygenType.WEP_152bit:
                    chars = GenerateChars(false, false, false, false, true);
                    return RandomeGenerator(16, chars);

                case KeygenType.WEP_256bit:
                    chars = GenerateChars(false, false, false, false, true);
                    return RandomeGenerator(29, chars);

                default:
                    return string.Empty;
            }
        }
    }
}