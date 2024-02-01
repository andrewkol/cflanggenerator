# cflanggenerator
Context Free Language Chain Generator

Generation of CF-language strings by program method.
Task: 
Write a program that will generate all chains of a language in some range of lengths according to a given context-free grammar.
Input data:
- List of terminals, non-terminals.
- The starting symbol of the grammar.
- Length, of the chains to be generated.
- Type of output (right-handed, left-handed).
- Inference rules.
Algorithm:
The algorithm generates strings by replacing non-terminal characters in the input string with their corresponding rules. The initial character is added to the list and then for each element in the list, the nonterminal characters are identified and replaced using the rules. The resulting strings are added to a new list and again checked for non-terminals. This process is repeated until no non-terminal characters remain or until the length of the strings exceeds a given maximum.
Result:
A list of generated KC-language strings of a given length.


Генерация цепочек КС-языка программным методом.
Задача: 
Написать программу, которая по заданной контекстно-свободной грамматике будет генерировать все цепочки языка в некотором диапазоне длин.
Входные данные:
•	Список терминалов, нетерминалов.
•	Стартовый символ грамматики.
•	Длина, генерируемых цепочек.
•	Тип вывода (правосторонний, левосторонний).
•	Правила вывода.
Алгоритм:
Алгоритм генерирует строки путем замены нетерминальных символов во входной строке соответствующими им правилами. Начальный символ добавляется в список, а затем для каждого элемента в списке идентифицируются нетерминальные символы и заменяются с использованием правил. Результирующие строки добавляются в новый список и снова проверяются на наличие нетерминалов. Этот процесс повторяется до тех пор, пока не останутся нетерминальные символы или пока длина строк не превысит заданный максимум.
Результат:
Список, сгенерированных цепочек КС-языка заданной длины.
