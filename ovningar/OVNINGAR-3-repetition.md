# Repetition — tio uppgifter på samma mönster

28 september 2026, måndag

Du sa: "Jag mästrar inte den här nivån än." Det är rätt sagt, och det är
inte samma problem som förut.

Förra gången saknades ett begrepp. Nu saknas **mängd**. Du har sett
mönstret en gång per steg. Det behöver köras tio gånger tills det sitter
i fingrarna och du inte längre tänker på det.

Därför är alla tio uppgifterna här **samma form**:

```
läs n
loopa n gånger
    läs en rad
    (kanske ett villkor)
        skriv ut något
```

Strukturen ändras aldrig. Bara villkoret och det som skrivs ut.

De sex första ska gå på några minuter var. Går de inte det — säg till, då
har jag lagt nivån fel.

---

## Så här arbetar du

Allt körs i kladdlådan `ovningar/Program.cs`. Radera allt, skriv om från
början, kör, nästa.

**Till varje uppgift finns ett färdigt testkommando.** Klistra in det i
terminalen i stället för att knappa in raderna:

```
printf '3\nkatt\nhund\nfisk\n' | dotnet run
```

`\n` betyder ny rad. Röret `|` skickar texten in i programmet. Du får svar
på tre sekunder och kan köra om hur många gånger du vill. Det är därför
mängdträning fungerar med den här metoden och inte med handknappning.

Vill du köra i `~/kattis-csharp/ovningar/` måste du stå i den mappen. Annars
lägg till `--project ~/kattis-csharp/ovningar` på slutet.

**Regler, som förut:**

- `using System;` överst i varje fil
- Warning stoppar dig inte. Bara error
- Fastnar du mer än fem minuter: gå till facit

---

# UPPGIFTERNA

## 1 — Skriv ut alla orden

Läs `n`, läs sedan `n` ord, skriv ut alla.

Ingen if-sats. Uppvärmning — det här är mönstret utan något ovanpå.

```
printf '3\nkatt\nhund\nfisk\n' | dotnet run
```

Förväntat:

```
katt
hund
fisk
```

---

## 2 — Bara de jämna varven

Samma, men skriv bara ut orden på varv 2, 4, 6 … Alltså **motsatsen till
Odd Echo**.

```
printf '5\nhello\ni\nam\nan\necho\n' | dotnet run
```

Förväntat:

```
i
an
```

Tänk efter på villkoret innan du skriver. Odd Echo hade `i % 2 == 1`.
Vad ska det stå här?

Och kom ihåg regeln: läsningen ligger utanför if-satsen.

---

## 3 — Varvnummer före ordet

Skriv ut varje ord med sitt varvnummer före, kolon och mellanslag emellan.

```
printf '3\nhello\nworld\nigen\n' | dotnet run
```

Förväntat:

```
1: hello
2: world
3: igen
```

Ingen if-sats. Här är det utskriften som är uppgiften — stränginterpolation
med **två** hål i samma text.

---

## 4 — Tal större än 10

Nu är raderna **tal** i stället för ord. Skriv ut de som är större än 10.

```
printf '5\n4\n12\n10\n30\n7\n' | dotnet run
```

Förväntat:

```
12
30
```

Notera att `10` inte är med. `>` är strikt.

Det nya här: raden ska bli ett tal innan du kan jämföra. Du vet vilket
verktyg det är.

---

## 5 — Dubbla värdet

Läs `n` tal, skriv ut varje tal gånger två.

```
printf '4\n3\n5\n10\n0\n' | dotnet run
```

Förväntat:

```
6
10
20
0
```

Ingen if-sats. `*` betyder gånger.

---

## 6 — Ord som börjar på a

Skriv ut bara de ord som börjar på bokstaven a.

```
printf '5\napa\nbanan\nananas\ncitron\navokado\n' | dotnet run
```

Förväntat:

```
apa
ananas
avokado
```

### Teori: två sätt att titta på första bokstaven

**Sätt 1 — `StartsWith`**

```csharp
if (ord.StartsWith("a"))
```

- `ord` — lådan med radens text
- `.` — punkten: något som hör till just den här strängen
- `StartsWith` — "börjar med". Stort S, stort W
- `("a")` — **dubbla** citattecken. StartsWith vill ha en sträng

Den ger tillbaka sant eller falskt direkt, så den kan stå ensam i if-satsen.
Inget `==` behövs.

**Sätt 2 — `ord[0]`**

```csharp
if (ord[0] == 'a')
```

- `ord[0]` — hakparenteser, precis som i FizzBuzz. Plocka ut ett enskilt
  tecken ur strängen. **Räkningen börjar på 0**, så `[0]` är första bokstaven
- `== 'a'` — **enkla** citattecken. Ett enskilt tecken, inte text

Bilden: en sträng är en rad med lådor, en bokstav i varje. `ord[0]` öppnar
den första lådan.

Båda fungerar och jag har kört båda. `StartsWith` är tydligare att läsa.
`[0]` är värt att känna igen, för du kommer se det överallt.

Enkla citattecken `' '` för ETT tecken. Dubbla `" "` för text av vilken
längd som helst. Samma skillnad som `Split(' ')` i FizzBuzz.

---

## 7 — Alla ord i versaler

Skriv ut varje ord med stora bokstäver.

```
printf '3\nhej\npå\ndig\n' | dotnet run
```

Förväntat:

```
HEJ
PÅ
DIG
```

### Teori: `ToUpper`

```csharp
ord.ToUpper()
```

- `ToUpper` — "gör till versaler". Stort T, stort U
- `()` — parenteserna betyder "gör det nu". De är tomma för att verktyget
  inte behöver veta något mer

**Viktigt:** `ToUpper` **ändrar inte** lådan `ord`. Den ger tillbaka ett
NYTT värde och lämnar originalet i fred.

```csharp
ord.ToUpper();                    // räknar ut HEJ — och slänger det
Console.WriteLine(ord.ToUpper()); // räknar ut HEJ och skriver ut det
string stor = ord.ToUpper();      // räknar ut HEJ och sparar det
```

Strängar i C# går inte att ändra. Varje "ändring" ger en ny sträng. Det är
en egenskap hos språket, inte något du gjort fel.

`ToLower` finns också och gör det omvända.

---

## 8 — Varje ords längd

Skriv ut hur många tecken varje ord har, i stället för ordet.

```
printf '4\nkatt\nko\nhund\nal\n' | dotnet run
```

Förväntat:

```
4
2
4
2
```

Du har använt `.Length` i förra häftet. Här är det det enda som skrivs ut.

---

## 9 — Summan av talen

Läs `n` tal och skriv ut deras **summa**, på en enda rad, efter loopen.

```
printf '4\n5\n10\n2\n3\n' | dotnet run
```

Förväntat:

```
20
```

### Teori: ackumulatorn — nytt begrepp

Det här är den första uppgiften i häftet som kräver något du inte gjort
förut, och det är ett riktigt begrepp värt ett eget namn.

**Problemet**

Hittills har varje varv varit oberoende. Loopen läste en rad, gjorde något
med den, och glömde den. Nästa varv visste ingenting om det förra.

Men en summa kan inte räknas ut i ett enda varv. Den byggs upp **över**
varven. Varv 3 måste veta vad varv 1 och 2 kom fram till.

**Lösningen**

En låda som ligger **utanför** loopen och överlever mellan varven.

```csharp
int summa = 0;                    // före loopen: skapas en gång

for (int i = 1; i <= n; i++)
{
    int tal = int.Parse(Console.ReadLine());
    summa = summa + tal;          // inuti: ändras varje varv
}

Console.WriteLine(summa);         // efter loopen: läses en gång
```

Tre platser, tre jobb. Det är hela mönstret, och det heter **ackumulator** —
av "ackumulera", att samla upp.

**Raden som gör jobbet:**

```csharp
summa = summa + tal;
```

Läs den **högerifrån**, aldrig som en likhet:

1. ta det som ligger i `summa` just nu
2. lägg till `tal`
3. lägg resultatet tillbaka i `summa`

`=` betyder "lägg in i", inte "är lika med". Därför är det inte motsägelsefullt
att `summa` står på båda sidor. Högersidan räknas ut först, sedan läggs
resultatet i lådan.

**Bilden:** en burk på bordet. Före loopen är den tom — det är `= 0`. Varje
varv lägger du ett mynt i. Efter loopen räknar du burken.

Burken måste stå på bordet hela tiden. Ställer du fram en ny burk varje varv
har du bara det sista myntet.

**Handkörningen med indata 5, 10, 2, 3:**

| varv | `tal` | `summa` före | `summa` efter |
|---|---|---|---|
| — | — | — | 0 (startvärdet) |
| 1 | 5 | 0 | 5 |
| 2 | 10 | 5 | 15 |
| 3 | 2 | 15 | 17 |
| 4 | 3 | 17 | 20 |

Efter loopen: 20. Kolumn tre visar poängen — `summa` bär med sig sitt värde
in i nästa varv.

**Kortformen** `summa += tal;` betyder exakt samma sak som
`summa = summa + tal;`. Använd den långa versionen först. Kortformen kommer
du se överallt sedan.

---

## 10 — Räkna hur många ord som var långa

Läs `n` ord. Skriv ut **antalet** ord som var längre än tre tecken. Bara
antalet, på en rad, efter loopen.

```
printf '5\nkatt\nko\nhund\nal\nfisk\n' | dotnet run
```

Förväntat:

```
3
```

`katt`, `hund` och `fisk` är längre än tre tecken. `ko` och `al` är det inte.

Samma ackumulatormönster som uppgift 9, men nu räknar du i stället för att
summera — och du räknar bara ibland, när villkoret slår till.

Det betyder att du behöver **båda** sakerna samtidigt: en ackumulator utanför
loopen, och en if-sats inuti. Det är därför den ligger sist.

Fundera på vad du ska lägga till varje gång villkoret är sant. Det är inte
ordets längd.

---
---

# FACIT — med förklaring

Läs det även när du hade rätt.

Alla tio är körda och verifierade. Utskrifterna nedan är riktiga
programutskrifter, inte gissningar.

---

## Facit 1 — alla orden

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    string ord = Console.ReadLine();
    Console.WriteLine(ord);
}
```

### Varför

Grundmönstret, utan något ovanpå. Tre delar:

- `n` läses **före** loopen. Den är gränsen
- loopen kör `n` varv, `i` räknar dem
- `ReadLine` ligger **inuti** måsvingarna — en läsning per varv

Lär dig de här åtta raderna utantill. Nio av tio uppgifter i det här häftet
är den här koden med en rad bytt.

---

## Facit 2 — jämna varv

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    string ord = Console.ReadLine();

    if (i % 2 == 0)
    {
        Console.WriteLine(ord);
    }
}
```

Ger `i` och `an`.

### Varför

**`i % 2 == 0`** — rest 0 vid division med 2 betyder jämnt. Odd Echo hade
`== 1`, som är udda. En etta bytt mot en nolla, och du får motsatsen.

**`ReadLine` ligger kvar utanför if-satsen.** Alla fem orden läses, två
skrivs ut. Hade läsningen legat inuti hade markören stått still på varv 1
och 3, och du hade fått `hello` och `i` — de två första orden i rad.

Det är samma fälla som i förra häftet. Den kommer tillbaka i varje uppgift
där du sorterar ut något, så det är värt att den sitter.

---

## Facit 3 — varvnummer före

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    string ord = Console.ReadLine();
    Console.WriteLine($"{i}: {ord}");
}
```

Ger `1: hello`, `2: world`, `3: igen`.

### Varför

Utskriftsraden tecken för tecken:

```
$      det finns hål i den här texten
"      texten börjar
{i}    första hålet — varvnumret
:      vanlig text, ett kolon
(mellanslag)   vanlig text
{ord}  andra hålet — ordet
"      texten slutar
```

**Två hål i samma text.** Det är det nya. Dollartecknet står en gång, i
början, oavsett hur många hål som kommer.

Kolonet och mellanslaget ligger **mellan** måsvingarna, som vanlig text. Allt
som inte står i måsvingar skrivs ut bokstavligt.

Glömmer du dollartecknet blir utskriften `{i}: {ord}` — bokstavligt, inget
felmeddelande. Samma tysta fälla som i Abracadabra.

Med plus hade det blivit `i + ": " + ord` — tre delar och två citattecken att
hålla reda på. Det är därför interpolation finns.

---

## Facit 4 — tal större än 10

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    int tal = int.Parse(Console.ReadLine());

    if (tal > 10)
    {
        Console.WriteLine(tal);
    }
}
```

Ger `12` och `30`.

### Varför

**`int tal = int.Parse(Console.ReadLine());`**

Samma rad som du använt för `n`, men inuti loopen. En gång per varv.

`ReadLine` ger alltid text, också när det står en siffra på raden. Utan
`int.Parse` går det inte att jämföra med `>` — C# skulle säga
`Operator '>' cannot be applied to operands of type 'string' and 'int'`.

Det är samma sak som `"7" + 1` blir `71`. Text är text tills du tolkat den.

**`tal > 10`** är strikt större än. `10 > 10` är falskt, så tian faller bort.
Ville du ha den med skulle det stå `>=`.

Typen på lådan skiljer sig mellan uppgifterna: `string ord` när raden är ett
ord, `int tal` när raden är ett tal. Det är det enda som ändras.

---

## Facit 5 — dubbla värdet

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    int tal = int.Parse(Console.ReadLine());
    Console.WriteLine(tal * 2);
}
```

Ger `6`, `10`, `20`, `0`.

### Varför

`*` betyder gånger. Räkningen sker **inuti** parentesen — `WriteLine` skriver
ut det som kommer ut, inte uttrycket självt.

Notera: `tal` ändras inte. `tal * 2` räknar ut ett nytt värde och lämnar
lådan i fred. Ville du ändra lådan skulle det stå `tal = tal * 2;`.

Samma sak som med `ToUpper` i uppgift 7: att räkna ut något är inte samma
sak som att ändra något.

Och `0 * 2` är 0. Nollan är inget specialfall — den går genom samma
beräkning som resten.

---

## Facit 6 — ord som börjar på a

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    string ord = Console.ReadLine();

    if (ord.StartsWith("a"))
    {
        Console.WriteLine(ord);
    }
}
```

Ger `apa`, `ananas`, `avokado`.

### Varför

**`ord.StartsWith("a")`** ger tillbaka sant eller falskt. Därför står den
ensam i if-satsen, utan `==`.

Det är samma sorts uttryck som `tal > 10` — något som är antingen sant eller
falskt. En if-sats kräver alltid det. Skriver du `if (ord)` får du
`Cannot implicitly convert type 'string' to 'bool'`, vilket betyder: jag
väntade mig ett sant-eller-falskt, men fick text.

### Den andra varianten

```csharp
if (ord[0] == 'a')
```

Kört, ger samma svar.

- `ord[0]` — första tecknet. Hakparenteser, räkning från 0, precis som
  `input[0]` i FizzBuzz
- `'a'` — enkla citattecken. Ett tecken, inte en sträng
- `==` behövs här, för `ord[0]` är ett tecken och inte ett sant-eller-falskt

Skriver du `ord[0] == "a"` med dubbla citattecken får du fel: du jämför ett
tecken med en sträng, och det är två olika typer.

**En skillnad värd att veta:** `ord[0]` kraschar på en tom sträng med
`IndexOutOfRangeException` — det finns ingen låda nummer 0 att öppna.
`StartsWith` klarar tom sträng och svarar falskt. På Kattis spelar det sällan
roll, i verklig kod gör det det.

Båda är rätt. `StartsWith` läser sig som svenska. `[0]` ska du känna igen.

---

## Facit 7 — versaler

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    string ord = Console.ReadLine();
    Console.WriteLine(ord.ToUpper());
}
```

Ger `HEJ`, `PÅ`, `DIG`.

### Varför

`ord.ToUpper()` räknar ut en ny sträng med stora bokstäver och ger den
tillbaka. `WriteLine` skriver ut det som kommer tillbaka.

**Lådan `ord` är oförändrad.** Skrev du `Console.WriteLine(ord)` på nästa rad
skulle det stå `hej` igen, med små bokstäver.

Det är därför den här raden inte gör något alls:

```csharp
ord.ToUpper();      // räknar ut HEJ och slänger det
```

Den räknar ut versalversionen och kastar den, eftersom ingen tar emot den.
Inget felmeddelande — bara en rad som inte gör något. Du får möjligen en
varning om att resultatet inte används.

Strängar i C# är **oföränderliga**: de går inte att ändra efter att de
skapats. Varje "ändring" ger en ny sträng. Det gäller `ToUpper`, `ToLower`,
`Trim`, `Replace` — alla ger tillbaka något nytt.

Och `på` blev `PÅ`. Å-ä-ö hanteras rätt.

---

## Facit 8 — ordets längd

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    string ord = Console.ReadLine();
    Console.WriteLine(ord.Length);
}
```

Ger `4`, `2`, `4`, `2`.

### Varför

`ord.Length` ger ett **tal**, inte text. `WriteLine` klarar båda och skriver
ut talet.

Notera att det inte står några parenteser efter `Length`. `ToUpper()` har
parenteser, `Length` har inte.

Skillnaden: `ToUpper` är något strängen **gör** — den räknar ut ett svar, och
parenteserna betyder "gör det nu". `Length` är något strängen **är** — ett
värde som redan finns där, färdigt att läsas.

Skriver du `ord.Length()` får du fel. Det kommer du göra minst en gång, och
felmeddelandet kommer säga att `Length` inte är en metod.

Ordet för det som har parenteser är **metod**. Det som inte har det kallas
**egenskap**. Du behöver inte orden än, men de kommer på utbildningen.

---

## Facit 9 — summan

```csharp
using System;

int n = int.Parse(Console.ReadLine());

int summa = 0;

for (int i = 1; i <= n; i++)
{
    int tal = int.Parse(Console.ReadLine());
    summa = summa + tal;
}

Console.WriteLine(summa);
```

Ger `20`.

### Varför

Tre platser, tre jobb:

| var | rad | vad |
|---|---|---|
| före loopen | `int summa = 0;` | skapas en gång, tom burk |
| inuti loopen | `summa = summa + tal;` | ändras varje varv |
| efter loopen | `Console.WriteLine(summa);` | läses en gång |

**Varför `= 0` och inte något annat:** noll är rätt startvärde för en summa,
för noll plus något är det något. Hade du startat på 1 hade svaret blivit 21.

För en **produkt** hade startvärdet varit 1, av samma skäl.

**Varför `summa` måste stå före loopen** är två saker samtidigt.

Dels överlevnad: en låda som skapas inuti måsvingarna kastas när varvet är
slut, och nästa varv gör en ny. Då hade du bara haft det sista talet.

Dels räckvidd. Det som skapas inuti måsvingarna finns **bara** där inne.
Jag körde den varianten:

```csharp
for (int i = 1; i <= n; i++)
{
    int summa = 0;
    ...
}
Console.WriteLine(summa);      // error CS0103
```

```
error CS0103: The name 'summa' does not exist in the current context
```

Utanför måsvingarna finns lådan inte. Det ordet är **räckvidd** — var i
filen ett namn går att nå. Det förklarar också `CS0136` du fick förra veckan:
räknaren `i` hör till loopen, och en `n` utanför krockar med en `n` inuti.

**`summa = summa + tal;` läses högerifrån.** Ta det som ligger i `summa`,
lägg till `tal`, lägg tillbaka. `=` är "lägg in i", inte "är lika med" —
därför går det an att `summa` står på båda sidor.

### Om utskriften hamnar inuti loopen

Jag körde den också. Med indata 5, 10, 2, 3:

```
5
15
17
20
```

Det är summan efter varje varv — själva handkörningstabellen, utskriven.
Inget felmeddelande, för koden är korrekt C#. Den svarar bara på en annan
fråga än den som ställdes.

Nyttigt när du felsöker: lägg en `WriteLine` inuti loopen och se
ackumulatorn växa. Ta bort den innan du skickar in till Kattis.

---

## Facit 10 — räkna de långa orden

```csharp
using System;

int n = int.Parse(Console.ReadLine());

int antal = 0;

for (int i = 1; i <= n; i++)
{
    string ord = Console.ReadLine();

    if (ord.Length > 3)
    {
        antal = antal + 1;
    }
}

Console.WriteLine(antal);
```

Ger `3`.

### Varför

Två mönster i samma program, och det är därför den ligger sist:

- **ackumulatorn** från uppgift 9 — `antal` före, ändras inuti, läses efter
- **if-satsen** från uppgift 6 — läs alltid, välj sedan

**`antal = antal + 1;`** och inte `antal = antal + ord.Length;`

Det är den fällan uppgiften var byggd för. Du ska **räkna ord**, inte summera
längder. Varje träff är värd exakt ett.

Med `ord.Length` hade svaret blivit 4 + 4 + 4 = 12 i stället för 3. Inget
felmeddelande — bara fel svar på en fråga som liknar den rätta.

**Att räkna är att summera ettor.** Det är samma mönster som uppgift 9, med
talet 1 i stället för ett inläst värde. Ser du det har du sett vad en
ackumulator faktiskt är.

**`antal = antal + 1;` ligger inuti if-satsen.** Det ska det. Bara de varv där
villkoret slår till ska räknas. Låg den utanför hade du räknat alla fem orden.

Notera att det här är den ENDA raden som ska ligga inuti if-satsen. Läsningen
ligger utanför, utskriften ligger efter loopen. Tre nivåer, tre platser.

Kortformen är `antal++;` — samma `++` som i `i++` i loopens tredje del. Nu
ser du vad den alltid har gjort: ökat en ackumulator med ett.

---

## Ordlista — orden som tillkommit

| ord | betyder |
|---|---|
| ackumulator | låda utanför loopen som samlar upp ett värde över varven |
| räckvidd | var i filen ett namn går att nå. Utanför måsvingarna finns det inte |
| `StartsWith("a")` | börjar strängen med a? Ger sant eller falskt |
| `ord[0]` | första tecknet i strängen. Räkning från 0 |
| `'a'` | ETT tecken. Enkla citattecken |
| `"a"` | text av vilken längd som helst. Dubbla citattecken |
| `ToUpper()` | ny sträng med stora bokstäver. Ändrar inte originalet |
| `ToLower()` | samma, med små bokstäver |
| oföränderlig | strängar går inte att ändra. Varje ändring ger en ny sträng |
| metod | något som har parenteser. `ToUpper()`. Den gör något |
| egenskap | något som inte har parenteser. `Length`. Den är något |
| `*` | gånger |
| `+=` | `summa += tal` är kortform för `summa = summa + tal` |
| `++` | `antal++` är kortform för `antal = antal + 1` |
| `>` / `>=` | större än / större än eller lika med |
| CS0103 | namnet finns inte. Stavfel, eller fel räckvidd |
| CS0136 | två lådor med samma namn i samma sammanhang |

---

## Nästa steg när de här tio sitter

Cold-puter Science på Kattis (`open.kattis.com/problems/cold`) är uppgift 10
med ett annat villkor: räkna hur många tal som är mindre än noll.

Enda skillnaden är att talen där ligger på **samma rad**, åtskilda av
mellanslag — så det blir `Split` igen, som i FizzBuzz, plus `foreach`. Men
räknar-mönstret är exakt det du just gjort.

Klarar du de här tio utan att titta i facit är du redo för den.

---

## Om du kör fast

1. **Läs felmeddelandet.** Gå till raden och kolumnen: `Program.cs(9,19)`
   betyder rad 9, tecken 19
2. **Många fel på en rad = ett trasigt tecken**
3. **Warning stoppar dig inte.** Bara error
4. **Rätt antal rader men fel innehåll?** Läsningen ligger troligen inuti
   if-satsen
5. **Bara en rad utskrift när det skulle vara flera?** Utskriften ligger
   troligen utanför loopen
6. **Bara det sista värdet?** Ackumulatorn ligger troligen inuti loopen
7. **Handkör.** Penna, en kolumn per låda, en rad per varv
8. **Fem minuter, sedan facit**
