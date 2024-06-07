namespace SF_HW03_Task2
{
    internal class Program
    {
        static void Main()
        {
            // инициализируем словарь "слово - количество"
            Dictionary<string, int> words = new Dictionary<string, int>();

            // считываем текст из файла в строку
            string text = File.ReadAllText("C:\\Users\\Polina\\source\\Text1.txt");
            text.ToUpper();

            // массив разделителей
            char[] separators = { ' ', '\n', '\r' };

            // текст без знаков пунктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            noPunctuationText.ToString();

            // массив слов
            string[] wordsArray = noPunctuationText.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // в хэш-сет передаём массив слов
            // остались только уникальные слова
            HashSet<string> unicWords = new HashSet<string>(wordsArray);

            // добаляем слова в словарь с нулевыми счётчиками
            foreach (var word in unicWords)
            {
                words.Add(word, 0);
            }

            // сравниваем слова из текста со словами-ключами из словаря
            // увеличиваем значения-счётчики в случае равенства
            foreach (var wordKey in words.Keys)
            {
                foreach (var word in wordsArray)
                {
                    if (wordKey == word)
                    {
                        words[wordKey] += 1;
                    }
                }
            }

            Console.WriteLine("10 слов из текста, встретившихся наибольшее количество раз");
            foreach (var word in words.OrderByDescending(c => c.Value).Take(10))
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
