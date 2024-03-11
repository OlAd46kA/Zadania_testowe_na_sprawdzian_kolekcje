using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania_testowe_na_sprawdzian_kolekcj {
    internal class Program{
        static void Main(string[] args){
            // zad 1
            Console.Write("Wpisz dlugosc listy: ");
            int userNumber = int.Parse(Console.ReadLine());
            int[] n = new int[userNumber];
            for (int i = 0; i < n.Length; i++) {
                n[i] = int.Parse(Console.ReadLine());
            }
            List<int> nList = n.ToList();
            for (int i = 1; i < n.Length; i += 2) {
                if (n[i - 1] + 2 == n[i]) {
                    nList.Remove(n[i - 1]);
                    nList.Remove(n[i]);
                }
                if (n[i + 1] - 2 == n[i]) {
                    nList.Remove(n[i + 1]);
                    nList.Remove(n[i]);
                }
            }
            foreach (int num in nList) {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // zad 2
            Console.Write("Wprowadz wers z Pana Tadeusza: ");
            string wersTadeusz = Console.ReadLine();
            char[] wtChar = wersTadeusz.ToCharArray();
            Dictionary<char, int> wtCharDictionary = new Dictionary<char, int>();
            for (int i = 0; i < wtChar.Length; i++) {
                if (wtChar[i] == ' ') {
                    continue;
                }
                if (!(wtCharDictionary.ContainsKey(wtChar[i]))) {
                    wtCharDictionary.Add(wtChar[i], 0);
                }
                if (wtCharDictionary.ContainsKey(wtChar[i])) {
                    wtCharDictionary[wtChar[i]]++;
                }
            }
            foreach (var item in wtCharDictionary) {
                if (item.Value >= 3) {
                    Console.WriteLine($"Litera {item.Key} pojawia sie co najmniej 3 razy, a dokladniej {item.Value} razy");
                }
            }

            // zad 3
            Console.Write("Podaj pierwsza liczbe brytyjska: ");
            int numBritish = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Podaj druga liczbe brytyjska: ");
            int numBritish2 = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine($"liczby pierwzse z zakresu od {numBritish} do {numBritish2} ");
            for (int i = numBritish; i <= numBritish2; i++) {
                if (isPrime(i)) {
                    Console.Write(i + " ");
                }
            }

            // zad 4
            Random random = new Random();
            List<Osoba> osoby = new List<Osoba>();
            string letters = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i <= 4; i++) {
                int age = random.Next(20, 51);
                string firstName = "a";
                string lastName = "";
                for (int j = 1; j <= 4; j++) {
                    firstName += letters[random.Next(0, letters.Length)];
                }
                List<char> lastNameList = firstName.ToCharArray().ToList();
                lastNameList.Reverse();
                foreach (char c in lastNameList) {
                    lastName += c;
                }
                Osoba osoba = new Osoba(age, firstName, lastName);
                osoby.Add(osoba);
            }

            foreach (var osoba in osoby) {
                Console.Write($"{osoba.age}; {osoba.firstName}; {osoba.lastName}");
                Console.WriteLine();
            }
            Console.WriteLine();

            // zad 5
            Queue<int> qOfDNums = new Queue<int>();
            for (int i = 6; i <= 100000; i++) {
                if (qOfDNums.Count == 4) {
                    break;
                }
                if (isDoskonala(i)) {
                    qOfDNums.Enqueue(i);
                }
            }
            foreach (int num in qOfDNums) {
                Console.Write(num + " ");
            }
            qOfDNums.Dequeue();
            qOfDNums.Dequeue();

            Console.WriteLine();
            foreach (int num in qOfDNums) {
                Console.Write(num + " ");
            }

            // zad 6
            Stack<int> stackOf13 = new Stack<int>();
            for (int i = 13; i <= 100; i += 13) {
                stackOf13.Push(i);
            }
            foreach (int num in stackOf13) {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            stackOf13.Pop();
            stackOf13.Pop();
            foreach (int num in stackOf13) {
                Console.Write(num + " ");
            }

            // zad 7
            Console.Write("Podaj ilosc ciagow: ");
            int numOfCiags = int.Parse(Console.ReadLine());
            string[] ciags = new string[numOfCiags];
            Dictionary<string, string> ciagsD = new Dictionary<string, string>();
            for (int i = 0; i < numOfCiags; i++){
                string ciag = Console.ReadLine();
                ciags[i] = ciag;
            }
            
            for (int i = 0; i < numOfCiags; i++) {
                ciagsD.Add(Code(ciags[i]), ciags[i]);
            }

            Console.ReadKey();
        }

        //czesc zadania 3
        public static bool isPrime (int n){
            for (int i = 2; i < Math.Sqrt(n); i++){
                if (n % i == 0){
                    return false;
                }
            }
            return true;
        }

        // czesc zadania 5
        public static bool isDoskonala(int num){
            int sum = 0;
            for (int i = 1; i < num; i++){
                if (num % i == 0){
                    sum += i;
                }
            }
            return sum == num;

        }
        // czesc zadania 7
        public static string Code (string s){
            char[] c = s.ToCharArray();
            Dictionary<char, int> codes = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++){
                if (!codes.ContainsKey(c[i])) {
                    codes.Add(s[i], 0);
                }
                if (codes.ContainsKey(s[i])){
                    codes[s[i]]++;
                }
            }
            string res = "";
            foreach (var item in codes) {
                res += item.Key;
                res += item.Value;
            }
            return res;
        }
    }

    // czesc zadania 4
    struct Osoba{
        public int age;
        public string firstName;
        public string  lastName;

        public Osoba(int age, string firstName, string lastName){
            this.age = age;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
