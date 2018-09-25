using System;

/*
 * БПИ 182
 * БЕнуа Кристиан
 * Написать метод, находящий трехзначное десятичное число s, все цифры которого одинаковы и которое представляет собои
 * ̆ сумму первых членов натурального ряда, то есть s = 1+2+3+4+...
Вывести полученное число, количество членов ряда и условное изображение соответствующей суммы, в которо
й  указаны первые три и последние три члена, а средние члены обозначены многоточием.
 * */
class Program
{

    public static bool Check(int sum) {
        int res = sum % 10;
        while (sum > 0) {
            if (sum % 10 != res) {
                return false;
            }
            sum /= 10;
        }
        return true;
    }

    public static int Solve(out int cntOfNumbers) {
        int sum = 0;
        for (int i = 1; ; i++) {
            sum += i;
            if (sum >= 100 && sum < 1000 && Check(sum)) {
                cntOfNumbers = i;
                return sum;
            }
            if (sum > 1000) {
                break;
            }
        }
        cntOfNumbers = -1;
        return -1;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Calculating...");

        int cnt;
        int ans = Solve(out cnt);
        Console.WriteLine("The number is " + ans);
        Console.WriteLine("1+2+3...{0}+{1}+{2}", cnt - 2, cnt - 1, cnt);


            
    }
}

