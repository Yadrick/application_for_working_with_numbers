# Testing_task

Здесь я опишу принцип работы программы, а чуть ниже суть смого задания:<br/>
<br/>
1.При запуске приложения, открывается консоль, где выводится краткая вводная по функционалу программы:<br/>
"Програма ищет уникальные числа, остаток от деления на 4 у которых равняется 3.<br/>
Получившийся набор будет отсортирован в порядке убывания<br/>
и сохранен в файл result.txt, в каталоге с рассматриваемыми текстовыми файлами."<br/>
Далее будет предложен ввод пути до папки, содержащей текстовые файлы для анализа. Путь можно ввести вручную, но проще будет скопировать и вставить.
Если ввести несуществующий путь до папки, то выйдет исключение.<br/>
<br/>
2.После ввода существующего пути, в консоли выведится краткая информация по числам, содержащимся в файлах в следующем формате:<br/>
"Всего чисел в файлах: n<br/>
Количество уникальных чисел: k<br/>
Количество подходящих чисел по условию: l"<br/>
А также выйдет уведомление пользователя о том, что результаты сохранены:<br/>
"Получившийся результат сохранен в введенном вами каталоге в файле result.txt."<br/>
<br/>
3.Также есть возможность автогенерации текстовых файлов в папке, введенной пользователем. Я не вписал эту возможность в программный интерфейс, хотя можно было сделать на подобии меню с выбором действий.
Для включения этого функционала, необходимо расскомментировать 23 строку в коде, тогда предложится ввести число файлов, какое пользователю нужно сгенерировать. В каждом файле появится рандомной количество строчеек с числами в пределах от 100 до 1000, величина чисел от 1 до 1000. Ну и следом программа вычислит необходимые данные по заданию.
_______________________________________________
Задание, C#:<br/>
Каталог с текстовыми файлами с расширением .txt, в каждом из которых записаны от 100 
до 1000 целых чисел, каждое на новой строке.

Написать консольную утилиту, которая:

1. Считает из консольной строки путь к каталогу, в котором находятся эти текстовые 
файлы<br/>
2. По этому пути прочтёт содержимое всех файлы и составит список из тех чисел, которые:<br/>
2.1. Являются уникальными<br/>
2.2. Имеют остаток от деления на 4 равным 3<br/>
3. Отсортирует получившиеся числа в порядке убывания<br/>
4. Запишет результат в тот же каталог в файл result.txt, каждое число на новой строке<br/>

Бонус:<br/>
Можно написать отдельно функцию для генерации исходных данных.
