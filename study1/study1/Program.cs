// See https://aka.ms/new-console-template for more information
//Console.WriteLine("숫자 두개를 입력해주세요 : ");

//string input = Console.ReadLine();
//string[] numbers = input.Split(' ');

//if (numbers.Length != 2)
//{
//    Console.WriteLine("숫자 2개가 제대로 입력되지 않았습니다. \n 다시 입력해주세요");
//    return;

//}
//else
//{
//    int num1 = int.Parse(numbers[0]);
//    int num2 = int.Parse(numbers[1]);

//    //큰 수 출력
//    if (num1 > num2)
//    {
//        Console.WriteLine($"큰수는 {num1} 입니다.");
//    }
//    else
//    {
//        Console.WriteLine($"큰수는 {num2} 입니다.");
//    }

//}

//Console.WriteLine("숫자를 입력해주세요");
//string input = Console.ReadLine();
//int a = int.Parse(input);

//if (a > 0)
//{
//    Console.WriteLine("양수입니다");
//}
//else if (a < 0)
//{
//    Console.WriteLine("음수입니다.");
//}
//else
//    Console.WriteLine("0 입니다.");



//Console.WriteLine("숫자 세개를 입력해주세요");

//string ThreeNum = Console.ReadLine();
//string[] numbers = ThreeNum.Split(' ');

//if (numbers.Length != 3)
//{
//    Console.WriteLine("숫자 3개가 제대로 입력되지 않았습니다.");
//}
//int a = int.Parse(numbers[0]);
//int b = int.Parse(numbers[1]);
//int c = int.Parse(numbers[2]);  

//if (a > b && a > c)
//{
//    Console.WriteLine($"가장 큰 수는 {a}입니다.");
//} else if (b > a && b > c)
//{
//    Console.WriteLine($"가장 큰 수는 {b}입니다.");
//}
//else
//{
//    Console.WriteLine($"가장 큰 수는 {c}입니다.");
//}


//Console.WriteLine("숫자를 입력해주세요 : ");
//string strmax = Console.ReadLine();
//int max = int.Parse(strmax);

//Console.WriteLine("두번째 숫자를 입력해주세요 : ");
//string strA = Console.ReadLine();
//int a = int.Parse(strA);

//if (max > a)
//{
//    Console.WriteLine($"큰 수는 {max}입니다.");
//}
//else
//{
//    Console.WriteLine($"큰 수는 {a}입니다.");
//}

//Console.WriteLine("숫자를 입력해주세요 ");
//string a = Console.ReadLine();
//int num = int.Parse(a);
//if (num % 2 == 0)
//{
//    Console.WriteLine("입력하신 숫자는 짝수입니다.");
//}
//else
//{
//    Console.WriteLine("입력하신 숫자는 홀수입니다.");
//}

//for (int i = 1; i <=10; i++)
//{
//    Console.Write(i);

//}

//for (int i = 10; i >= 1; i--)
//{
//    Console.WriteLine(i);   
//}

//int sum = 0;
//for (int i = 1; i <= 100; i++)
//{

//    sum += i;
//}
//Console.WriteLine(sum);

//int sum = 0; 
//for (int i = 2; i <= 100; i+=2)
//{
//    sum += i;
//}
//Console.WriteLine(sum);

//int sum = 0;
//for (int i = 1; i<=100; i++)
//{
//    if (i % 2 == 0)
//    {
//        sum += i;
//    }
//}
//Console.WriteLine(sum);


//int sum = 0;
//for (int i = 1; i<= 100; i++)
//{
//    if (i % 2 == 1)
//    {
//        sum += i;
//    }
//    else if (i % 2 == 0)
//    {
//        sum -= i;
//    }
//}
//Console.WriteLine(sum); 


//int fact = 1; 
//for (int i = 5; i >=1; i--)
//{
//    fact =fact * i;
//}
//Console.WriteLine(fact);

//int a = 10; 
//for (int i = 1; i <= a; i++)
//{
//    if (a % i == 0)
//        Console.Write(i );
//}

//Console.WriteLine("숫자 2개를 입력해주세요 :");
//string[] input = Console.ReadLine().Split(' ');
//int a = int.Parse(input[0]);
//int b = int.Parse(input[1]);

//int max = 0;
//for (int i = 1; i <= a; i++)
//{
//    if (a % i == 0 && b % i == 0)
//    {
//        max = i;
//    }
//}
//Console.WriteLine(max);

//for (int i = 2; i<8; i++)
//{
//    if (i == 2 || i % 2 != 0)
//    {
//        Console.WriteLine($"{i}는 소수입니다.");
//    }
//}

//피보나치수열
//int n = 20;
//int a = 0, b = 1;

//for (int i = 2; i <= n; i++)
//{
//    int next = a + b;
//    Console.Write($" {next} ");
//    a = b;
//    b = next;
//}


//int max = 0;
//int cnt = 0;


//for (cnt = 0; cnt < 10; cnt++)
//{
//    Console.WriteLine("숫자를 입력해주세요");
//    string a = Console.ReadLine();
//    int num = int.Parse(a);


//    if (num > max)
//    {
//        max = num;
//        Console.WriteLine($" 가장 큰 수는 {max} 입니다.");
//    }
//    if (max > num)
//    {
//        Console.WriteLine($" 가장 큰 수는 {max} 입니다.");
//    }

//}


//for (int i = 1; i<=5; i++)
//{
//    for (int j = 1; j<=i; j++)
//    {
//        Console.Write(j);
//    }
//    Console.WriteLine();

//}

//for (int i = 1; i <=10; i++)
//{
//    Console.Write($"{i}의 약수");
//    for (int j = 1; j<=i; j++)
//    {

//        if (i % j == 0)
//        {
//            Console.Write($" {j}");
//        }
//    }
//    Console.WriteLine();
//}


//for (int i = 2; i<=100; i++)
//{
//    bool isPrime = true;
//    for (int j = 2; j * j <= i; j++)
//    {
//        if (i % j == 0)
//        {
//            isPrime = false;
//            break;
//        }
//    }
//    if (isPrime)
//    {
//        Console.Write($" {i}");
//    }
//}

//int[] a = new int[10];
//for (int i = 1; i<=10; i++)
//{
//    a[i - 1] = i;
//    Console.Write(a[i-1]);
//}


//int[] a = new int[10];
//for (int i = 1; i <= 10; i++)
//{
//    a[i - 1] = i * 10;
//}

//for (int i = 9; i >=0; i--)
//{
//    Console.WriteLine(a[i]);
//}


//배열을 뒤집어서 출력하기
//int[] a = new int[10];

//for (int i = 0; i < 10; i++)
//{
//    a[i] = i+1;
//}

//for (int i = 0; i<=4; i++)
//{
//    var temp = a[i];
//    a[i] = a[9 - i];
//    a[9 - i] = temp;


//}
//Console.WriteLine(string.Join(", ", a));


//int[] a = new int[10];
//int[] b = new int[10];

//for (int i = 0; i < 10; i++)
//    a[i] = i+1;

//for (int i = 0; i < 10; i++)
//    b[i] = a[9 - i];
//Console.WriteLine(string.Join(", ", b));

//using System;
//class program 
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("숫자를 입력해주세요");
//        string[] input = Console.ReadLine().Split(' ');
//        int a = int.Parse(input[0]);
//        int b = int.Parse(input[1]);

//        int result = calc(a,b);
//        Console.WriteLine(result);
//    }

//    static int calc(int a, int b)
//    {

//        if (a < b)
//        {
//            return b;
//        }
//        else
//        {
//            return a;
//        }

//    }
//}

//using System;
//class program
//{
//    static void Main(String[] args)
//    {
//        Console.WriteLine("숫자를 입력해주세요");
//        string[] inputNum = Console.ReadLine().Split(' ');
//        int a = int.Parse(inputNum[0]);
//        int b = int.Parse(inputNum[1]);
//        int c = int.Parse(inputNum[2]); 

//        findnum(a,b,c);

//    }

//    static int findnum(int a, int b, int c)
//    {
//        if (a > b && a > c)
//        {
//            Console.WriteLine($"가장 큰수는 {a}입니다.");
//        }
//        else if(b > a && b > c)
//        {
//            Console.WriteLine($"가장 큰수는 {b}입니다.");
//        }
//        else
//        {
//            Console.WriteLine($"가장 큰수는 {c}입니다.");
//        }
//        return a;

//    }
    
//}

