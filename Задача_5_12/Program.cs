//В некоторых странах Дальнего Востока (Китае, Японии и др.) использовался (и неофициально используется в настоящее время) календарь, 
//отличающийся от применяемого нами. Этот календарь представляет собой 60-летнюю циклическую систему. 
//Каждый 60-летний цикл состоит из пяти 12-летних подциклов. В каждом подцикле года носят названия животных: 
//Крыса, Корова, Тигр, Заяц, Дракон, Змея, Лошадь, Овца, Обезьяна, Петух, Собака и Свинья. 
//Кроме того, в названии года фигурируют цвета животных, которые связаны с пятью элементами природы — 
//Деревом (зеленый), Огнем (красный), Землей (желтый), Металлом (белый) и Водой (черный). 
//В результате  каждое животное (и его год) имеет символический цвет, причем цвет этот часто совершенно не совпадает 
//с его «естественной» окраской — Тигр может быть черным, Свинья — красной, а Лошадь — зеленой. 
//Например, 1984 год — год начала очередного цикла — назывался годом Зеленой Крысы. 
//Каждый цвет в цикле (начиная с зеленого) «действует» два года, поэтому через каждые 60 лет имя года (животное и его цвет) повторяется. 
//Составить программу, которая по заданному номеру года нашей эры n печатает его название по описанному календарю в виде: 
//«Крыса, Зеленый». Рассмотреть два случая:
// а) значение n >= 1984;
// б) значение n может быть любым натуральным числом.

string[] subCycle = { "Крыса", "Корова", "Тигр", "Заяц", "Дракон", "Змея", "Лошадь", "Овца", "Обезьяна", "Петух", "Собака", "Свинья" };
string[] subColor = { "Зеленый", "Красный", "Желтый", "Белый", "Черный" };

int year;

while (true)
{
    Console.Write("Введите год: ");
    string? input = Console.ReadLine();
    bool result = int.TryParse(input, out year);
    if (result == true)
    {
        break;
    }
    else
    {
        Console.WriteLine("Попробуйте еще раз! ");
    }
}

int indexYear = 1864;
int convertYear;
int convertColorYear;
int cycle = 60;
int countColor = 2;

ToConvertYear(year, out convertYear, out convertColorYear);
PrintYaer(convertYear, convertColorYear);

void ToConvertYear(int year, out int convertYear, out int convertColorYear)
{
    while (true)
    {
        if (year >= indexYear + cycle)
        {
            year -= cycle;
        }
        else if (year < indexYear)
        {
            year += cycle;
        }
        else
        {
            convertYear = year - indexYear;
            convertYear = convertYear % 12;
            ToConvertColorYear(year, out convertColorYear);
            return;
        }
    }

    void ToConvertColorYear(int year, out int convertColorYear)
    {
        int count = indexYear;
        int index = 0;
        while (count < year - 1)
        {
            count += countColor;
            index++;
        }

        convertColorYear = index % 5;
    }
}

void PrintYaer(int convertYear, int convertColorYear)
{ 
    Console.WriteLine($"Год {year}: {subCycle[convertYear]}, {subColor[convertColorYear]}");
}
