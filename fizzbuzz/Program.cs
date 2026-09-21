// Kattis: FizzBuzz  —  https://open.kattis.com/problems/fizzbuzz
//
// UPPGIFTEN
// Indata: en rad med tre heltal X, Y och N  (1 <= X < Y <= N <= 100)
// Utdata: talen 1 till N, ett per rad.
//         Tal delbara med X       -> Fizz
//         Tal delbara med Y       -> Buzz
//         Tal delbara med BÅDA    -> FizzBuzz
//
// EXEMPEL
//   in:  2 3 7
//   ut:  1 / Fizz / Buzz / Fizz / 5 / FizzBuzz / 7   (en per rad)
//
// ──────────────────────────────────────────────────────────────
// STEG 1: skriv på svenska vad programmet ska göra, i ordning.
//   1. Programmet ska läsa in tre heltal från standard input x, y och n.
//   2. Sedan ska det skriva ut talet 1 till n, ett tal per rad.
//   3. Om talet är delbart med x ska det skriva ut "Fizz", om det är delbart med y ska det skriva ut "Buzz", och om det är delbart med både x och y ska det skriva ut "FizzBuzz".
//   4. Varje tal ska kontrolera delbarheten och skriva ut. 
// STEG 2: skriv koden under den här raden.
// ──────────────────────────────────────────────────────────────

var input = Console.ReadLine().Split(' ');
int x = int.Parse(input[0]);
int y = int.Parse(input[1]);
int n = int.Parse(input[2]);

for (int tal = 1; tal <= n; tal++)
{
    { if (tal % x == 0 && tal % y == 0)
      { Console.WriteLine("FizzBuzz"); }
      else if (tal % x == 0)
      { Console.WriteLine("Fizz"); }
      else if (tal % y ==0)
      { Console.WriteLine("Buzz"); }
      else
      { Console.WriteLine(tal); }
      } 
}