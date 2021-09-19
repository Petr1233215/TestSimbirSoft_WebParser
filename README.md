# TestSimbirSoft_WebParser
# Задание:
Приложение, которое позволяет скачивать произвольную HTML-страницу
посредством HTTP-запроса на жесткий диск компьютера и выдает статистику по
количеству уникальных слов в консоль.
Требования к приложению:
1. В качестве входных данных в приложение принимает строку с адресом web-страницы. Пример входной строки: https://www.simbirsoft.com/
2. Приложение разбивает текст страницы на отдельные слова с помощью списка разделителей.
  Пример списка:
  {' ', ',', '.', '! ', '?','"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t'}
3. В качестве результата работы пользователь должен получить статистику по
  количеству уникальных слов в тексте.
  Пример:
  РАЗРАБОТКА -1
  ПРОГРАММНОГО - 2
  ОБЕСПЕЧЕНИЯ - 4
4. Приложение должно быть реализовано с помощью стандартных классов(не стоит добавлять собственные реализации списков, словарей и т.п.)
5. Приложение написано в соответствии с принципами ООП

# Пример входных данных:
1. Вводим путь до файла(через пробел указывается название файла): D:/ exampleFile
2. Вводим url страницы, например: https://www.simbirsoft.com/
