# Trappan till Odd Echo — fem mikroövningar om att läsa flera rader

24 september 2026, torsdag eftermiddag

Du sa: "Jag behöver övningar för att förstå detta problem." Samma sak som
med Abracadabra i går — teorin landar, men steget till tomt papper är för
långt. Så: en trappa till.

**Ämnet är att läsa flera rader indata.** Slutsteget är Odd Echo.

Fem steg. Varje steg lägger till exakt en ny sak.

---

## Så här arbetar du med häftet

1. Läs teorin för ett steg. Bara ett.
2. Skriv koden själv i `ovningar/Program.cs`. Utan att titta i facit.
3. Kör med `dotnet run`. Se vad som händer.
4. Läs facit längst ner — även när du hade rätt.
5. Sedan nästa steg.

Facit ligger samlat sist, med avsikt. Du ska ha chansen att försöka först.

**Kör du fast mer än fem minuter: gå till facit.** Att stirra lär dig ingenting.

### Att mata in flera rader

De här övningarna behöver flera rader indata. Kör `dotnet run` och skriv
en rad i taget, enter efter varje. Programmet väntar tills det fått alla
rader det bett om.

Går det snabbare för dig kan du också mata in allt på en gång:

```
printf '5\nhello\ni\nam\nan\necho\n' | dotnet run
```

`\n` betyder "ny rad". Röret `|` skickar texten in i programmet i stället
för att du knappar den. Det är samma sak som att skriva raderna för hand,
bara snabbare när du kör om många gånger.

### Två fasta regler, som förut

- **`using System;` överst i varje fil.** Kattis har inte implicit usings.
- **Warning stoppar dig inte. Bara error.**

---

## STEG 1 — Två ReadLine efter varandra

### Teorin

Hittills har du anropat `Console.ReadLine()` en gång per program. Nu ska du
anropa den flera gånger, och då måste du veta en sak du inte behövt förut.

**Varje anrop av `Console.ReadLine()` ger NÄSTA rad. Inte samma rad igen.**

Bakom kulisserna finns en osynlig markör som pekar på "här är jag i indata".
Varje `ReadLine` gör två saker:

1. läser raden markören står på
2. flyttar markören ett steg ned

Markören går bara framåt. Den kan aldrig backa. Har en rad passerats är den
borta för alltid.

**Bilden:** en kö av människor vid en lucka. `ReadLine()` betyder
"nästa, tack". Den du precis expedierat går därifrån och kommer aldrig
tillbaka.

```csharp
string första = Console.ReadLine();   // tar rad 1, markören går till rad 2
string andra  = Console.ReadLine();   // tar rad 2, markören går till rad 3
```

Två anrop, två olika rader, två olika lådor.

Det här är också förklaringen till något du redan gjort utan att tänka på
det. I Time Loop skrev du:

```csharp
int n = int.Parse(Console.ReadLine());
```

Den raden åt upp indatans första rad. Hade det funnits fler rader hade
nästa `ReadLine` fått rad två — inte rad ett igen.

### Övning 1

Skriv ett program som:

1. Läser två rader från användaren
2. Skriver ut båda, i samma ordning som de kom

Kör det och mata in `hej` och `svejs`. Utskriften ska bli:

```
hej
svejs
```

Poängen är inte svårighetsgraden. Poängen är att du ska SE med egna ögon
att de två anropen gav olika rader. Det är hela grunden för resten av
häftet.

---

## STEG 2 — Tre rader, i omvänd ordning

### Teorin

Inget nytt verktyg här. En ny insikt.

Markören går bara framåt. Alltså: **läser du en rad och inte sparar den,
är den borta.** Du kan inte gå tillbaka och hämta den.

Det är samma sak som telefonnummer-bilden från förra häftet, men skarpare:
här finns det inte ens någon att fråga en gång till.

Vill du skriva ut raderna i omvänd ordning måste alltså alla tre finnas
kvar när du börjar skriva ut. Och det enda sättet att ha något kvar är att
lägga det i en låda.

```csharp
string rad1 = Console.ReadLine();
string rad2 = Console.ReadLine();
string rad3 = Console.ReadLine();
```

Tre lådor, tre etiketter. Nu ligger alla tre kvar samtidigt, och du kan
peka på dem i vilken ordning du vill.

**Läsordningen och utskriftsordningen är två olika saker.** Du MÅSTE läsa
1, 2, 3 — markören bestämmer det. Men du får skriva ut 3, 2, 1. Det är
lådorna som gör den friheten möjlig.

### Övning 2

Skriv ett program som:

1. Läser tre rader
2. Skriver ut dem i omvänd ordning

Matar du in `ett`, `två`, `tre` ska det stå:

```
tre
två
ett
```

**När det funkar — gör också det här:** ta bort `string rad1 =` från första
raden, så att den bara står `Console.ReadLine();`. Kör igen. Vad skrivs ut
i stället för `ett`? Och vilket felmeddelande får du?

---

## STEG 3 — Läs n rader i en loop

### Teorin

Tre rader klarade du med tre lådor. Men tänk om det är hundra rader. Eller
— och det är det verkliga problemet — tänk om du inte vet hur många.

Du kan inte skriva hundra lådor. Och du kan definitivt inte skriva kod för
ett antal du inte känner till.

Det här är exakt samma problem som fick dig att lära dig loopen i förra
häftet, och lösningen är densamma.

**Det nya: `ReadLine` läggs INUTI loopen.**

```csharp
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    string ord = Console.ReadLine();
    Console.WriteLine(ord);
}
```

Rad för rad:

- `int n = int.Parse(Console.ReadLine());`
  Läser **första** raden och tolkar den som ett tal. Det är antalet rader
  som kommer efter. Markören står nu på rad 2.

- `for (int i = 1; i <= n; i++)`
  Samma tre delar som alltid: börja på 1, fortsätt så länge `i` är högst
  `n`, öka med ett mellan varven. `n` varv, ett per ord.

- `string ord = Console.ReadLine();`
  Inuti måsvingarna. Körs alltså en gång per varv. Varv 1 hämtar rad 2,
  varv 2 hämtar rad 3, och så vidare — markören flyttas ett steg för varje
  anrop.

`string ord` skapas på nytt varje varv, får det varvets rad, och kastas när
varvet är slut. Det är helt i sin ordning. Nästa varv gör en ny låda med
samma etikett.

**Bilden:** kön igen. Loopen ropar "nästa, tack" exakt `n` gånger.

### Namnen — ditt CS0136 från i går

Du skrev `for (int n = 0; n < 4; n++)` när du redan hade en `n` från
indata, och fick `CS0136`. Det felet betyder: "det finns redan en låda som
heter n här, du kan inte göra en till."

**`n` är gränsen** — kommer från indata, sätts en gång, ändras aldrig.
**`i` är räknaren** — ändras varje varv.

Två olika jobb, två olika namn. Och hårdkoda aldrig en siffra där `n` ska
stå — då slutar programmet fungera så fort indata ändras.

### Övning 3

Skriv ett program som:

1. Läser ett tal `n` från första raden
2. Läser `n` rader till
3. Skriver ut alla

Ingen utsortering än. Allt som kommer in ska ut.

Testa med:

```
3
katt
hund
fisk
```

Utskriften ska bli `katt`, `hund`, `fisk`.

Kör det sedan igen med fyra ord och ändra bara första raden till `4`.
Programmet ska klara det utan att du rör koden. Gör det inte det, har du
hårdkodat något.

---

## STEG 4 — Läs alla, skriv ut några

### Teorin

Det här steget är häftets viktigaste. Odd Echo handlar egentligen bara om
den här ena saken.

Hittills har du skrivit ut varje rad du läst. Nu ska du **läsa alla rader
men bara skriva ut några**.

Och då gäller en regel som är lätt att formulera och lätt att bryta mot:

> **Läs ALLTID varje rad. Bestäm sedan om den ska skrivas ut.**

Läsningen ligger **utanför** if-satsen. Utskriften ligger **inuti**.

```csharp
for (int i = 1; i <= n; i++)
{
    string ord = Console.ReadLine();   // utanför if — sker varje varv

    if (villkor)
    {
        Console.WriteLine(ord);        // inuti if — sker ibland
    }
}
```

### Varför det MÅSTE vara så

Markören flyttas bara när du anropar `ReadLine`.

Lägger du läsningen inuti if-satsen står markören still på de varv där
villkoret är falskt. Nästa gång villkoret slår till plockar du upp ordet
som råkade stå på tur — inte ordet du ville ha.

**Bilden:** du ropar "nästa, tack" bara varannan gång. Kön rör sig inte
däremellan. Du expedierar person 1, 2, 3 i rad och tror att du tagit
1, 3, 5.

### Ett villkor om längd

Villkoret i den här övningen har ingenting med varannan att göra. Det är
med flit — du ska se strukturen "läs alltid, välj sedan" utan att modulo
ligger i vägen.

```csharp
ord.Length
```

- `ord` — namnet på lådan där radens text ligger
- `.` — punkten betyder "inuti". Något som hör till just den här strängen
- `Length` — längden. Antalet tecken i strängen. Stort L

`"katt".Length` är 4. `"ko".Length` är 2.

Och jämförelsen:

```csharp
if (ord.Length > 3)
```

`>` betyder större än. Strikt större — `3 > 3` är falskt. Ett ord på exakt
tre tecken åker alltså ut.

### Övning 4

Skriv ett program som:

1. Läser ett tal `n` från första raden
2. Läser `n` rader
3. Skriver ut **bara** de ord som är längre än tre tecken

Testa med:

```
5
katt
ko
hund
al
fisk
```

Utskriften ska bli:

```
katt
hund
fisk
```

`ko` och `al` är två tecken och faller bort.

**Kontroll att du gjort rätt:** om `ko` och `al` inte bara försvinner utan
utskriften blir helt fel — till exempel att `al` dyker upp — då ligger
`ReadLine` inuti if-satsen. Flytta ut den.

---

## STEG 5 — Odd Echo

### Teorin

Nu är du framme. Det här är steg 4 med ett annat villkor. Inget annat.

Uppgiften ligger på `open.kattis.com/problems/oddecho`

Första raden säger hur många ord som kommer. Sedan kommer orden, ett per
rad. Du ska skriva ut det 1:a, 3:e, 5:e — varannat, med start på det första.

```
Indata          Utdata
5               hello
hello           am
i               echo
am
an
echo
```

### Villkoret: modulo igen

Du kan det här från FizzBuzz. `%` ger resten vid division.

```
1 % 2  ->  1     udda
2 % 2  ->  0     jämnt
3 % 2  ->  1     udda
4 % 2  ->  0     jämnt
```

Rest 1 vid division med 2 betyder udda. Rest 0 betyder jämnt.

Loopar du med `int i = 1` är varv 1, 3, 5 precis de ord som ska skrivas ut,
och de har `i % 2 == 1`.

### Handkörningen

Indata är `5`, sedan `hello i am an echo`.

| varv `i` | `ReadLine` ger | `i % 2` | skrivs ut |
|---|---|---|---|
| 1 | hello | 1 | **hello** |
| 2 | i | 0 | — |
| 3 | am | 1 | **am** |
| 4 | an | 0 | — |
| 5 | echo | 1 | **echo** |
| 6 | `6 <= 5` falskt — loopen slutar | | |

Notera kolumn två: **varje varv hämtar en rad**, också varv 2 och 4 där
inget skrivs ut. Det är det som gör att varv 3 får `am` och inte `i`.

### Om du börjar på noll i stället

`int i = 0` går också, men då vänder allt: `0 % 2` är 0, och det är de
JÄMNA i-värdena som ska skrivas ut. Villkoret blir `i % 2 == 0` och
loopvillkoret `i < n`.

Båda fungerar. Men du måste veta vilken du valt. Blandar du ihop dem får
du ut orden 2, 4 — som är precis fel svar. Det är samma off-by-one-tänk
som i förra häftets facit 5.

Välj `int i = 1` och `i % 2 == 1` om du är osäker. Den följer uppgiftens
ordval: "det första, det tredje".

### Övning 5

Lös Odd Echo.

Projektet finns redan: `~/kattis-csharp/oddecho/`

Testa lokalt med båda exemplen från uppgiften. Kontrollera tecken för
tecken. Sedan: klistra in på Kattis, submit, och när den är grön — commit
och push.

---
---

# FACIT — med förklaring

Läs det här även när du hade rätt. Förklaringen är det som gör nästa steg
snabbare.

---

## Facit 1 — två ReadLine

```csharp
using System;

string första = Console.ReadLine();
string andra = Console.ReadLine();

Console.WriteLine(första);
Console.WriteLine(andra);
```

Kört med `hej` och `svejs` ger det:

```
hej
svejs
```

### Varför ser det ut så

**Rad 1 och 2** är två separata anrop. Det första tar indatans rad 1, det
andra tar rad 2. Markören flyttades ett steg däremellan, utan att du bad
om det — det sker automatiskt vid varje läsning.

**Två lådor, två etiketter.** Hade du skrivit `första` båda gångerna hade
den andra läsningen skrivit över den första, och `hej` varit borta.

**Utskrifterna ligger efter båda läsningarna.** Det behöver de inte göra —
du kunde lika gärna skrivit ut den första direkt. Men lägger du dem sist
ser du tydligt att båda värdena fortfarande finns kvar, sparade.

Å-ä-ö i variabelnamn funkar i C#, som du ser. Det är inte vanligt i
branschen — engelska namn är standard — men det är inte fel.

---

## Facit 2 — tre rader, omvänd ordning

```csharp
using System;

string rad1 = Console.ReadLine();
string rad2 = Console.ReadLine();
string rad3 = Console.ReadLine();

Console.WriteLine(rad3);
Console.WriteLine(rad2);
Console.WriteLine(rad1);
```

Kört med `ett`, `två`, `tre` ger det `tre`, `två`, `ett`.

### Varför ser det ut så

**Läsningarna måste stå i ordning 1, 2, 3.** Du har inget val — markören
går bara framåt. Den första `ReadLine` FÅR rad 1, vad du än döper lådan till.

**Utskrifterna får stå i vilken ordning du vill.** Det är hela skillnaden
mellan att läsa och att ha sparat. När värdet ligger i en låda är
ordningen din att bestämma.

Det är därför lådor finns. Utan dem vore programmet tvunget att göra saker
i exakt den takt indata kommer.

### Och det du skulle prova

Tar du bort `string rad1 =` blir raden:

```csharp
Console.ReadLine();
```

Den läser fortfarande rad 1 — markören flyttas — men värdet kastas direkt.
Ingen låda, ingen etikett, borta.

Sedan går det inte att kompilera:

```
error CS0103: The name 'rad1' does not exist in the current context
```

C# letar efter en låda som heter `rad1` på sista utskriftsraden och hittar
ingen. Den skapades aldrig.

Det är samma fel som när du skrev `WriteLine(Fizz)` utan citattecken i
måndags: ett namn som inte pekar på något.

Notera skillnaden mot att bara glömma bort raden: här **läses** raden ändå.
Markören går framåt. Hade programmet fortsatt hade rad 2 hamnat i `rad2`,
precis som vanligt. Läsningen och sparandet är två olika saker.

---

## Facit 3 — n rader i en loop

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    string ord = Console.ReadLine();
    Console.WriteLine(ord);
}
```

### Varför ser det ut så

**`int n = int.Parse(Console.ReadLine());`**
Står först, utanför loopen. Läser indatans rad 1 och tolkar den som ett tal.

Den HAR att ligga före loopen, av två skäl. Dels för att loopen behöver `n`
för att veta hur många varv (datorn läser uppifrån och ned — ligger raden
efter loopen finns `n` inte än, och du får `CS0103`). Dels för att markören
står på rad 1 från början, och det är just antalet som står där.

**`for (int i = 1; i <= n; i++)`**
`n` varv. Ett per ord. `i` räknar varven, `n` sätter gränsen.

**`string ord = Console.ReadLine();` — inuti måsvingarna**
Det är den avgörande detaljen i hela steget. En läsning per varv. Varv 1
hämtar indatans rad 2, varv 2 hämtar rad 3, och så vidare.

Lådan `ord` skapas på nytt varje varv och kastas när varvet är slut. Det är
inget problem — du behöver bara ordet just det varv du skriver ut det.

Hade du behövt alla orden kvar samtidigt — säg för att skriva ut dem baklänges
— hade det inte räckt. Då hade du behövt en array. Men det behövs inte här.

### Varför två lådor med olika jobb

| | `n` | `i` |
|---|---|---|
| var kommer den från | indata | loopen |
| ändras den | nej | varje varv |
| vad gör den | sätter gränsen | räknar varven |

Ger du dem samma namn får du `CS0136` — felet du fick i går. Det betyder:
"det finns redan en låda med det namnet i det här sammanhanget."

Hårdkodar du en siffra i stället för `n` — `i <= 4` — fungerar programmet
på ett testfall och går sönder på nästa. Kattis kör flera.

---

## Facit 4 — läs alla, skriv ut några

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    string ord = Console.ReadLine();

    if (ord.Length > 3)
    {
        Console.WriteLine(ord);
    }
}
```

Kört med `5 / katt / ko / hund / al / fisk` ger det `katt`, `hund`, `fisk`.

### Varför ser det ut så

Jämför med facit 3. En enda sak är tillagd: en if-sats runt utskriften.

**`string ord = Console.ReadLine();` ligger kvar UTANFÖR if-satsen.**

Det är hela steget. Läsningen sker varje varv, oavsett vad villkoret säger.
Alla fem orden läses. Tre av dem skrivs ut.

**`if (ord.Length > 3)`**

- `ord.Length` — antalet tecken i strängen som ligger i lådan
- `>` — större än. Strikt. `3 > 3` är falskt
- Måsvingarna efter `if` omsluter det som ska hända när villkoret är sant

`"ko".Length` är 2, och `2 > 3` är falskt. Ingen utskrift det varvet.
Men raden lästes ändå, och markören flyttades.

### Vad som händer om läsningen hamnar inuti if-satsen

Det går inte ens att skriva, för `ord` skulle inte finnas när villkoret
prövas. Men motsvarigheten går:

```csharp
if (Console.ReadLine().Length > 3)
{
    Console.WriteLine(...);      // och nu har du inget ord kvar att skriva
}
```

Den varianten läser bara på de varv där if-satsen körs, och du har dessutom
kastat bort ordet. Båda problemen kommer av samma sak: läsningen får inte
sitta ihop med beslutet.

**Läs. Spara. Bestäm sedan.** Tre separata saker, i den ordningen.

---

## Facit 5 — Odd Echo

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    string ord = Console.ReadLine();

    if (i % 2 == 1)
    {
        Console.WriteLine(ord);
    }
}
```

Kört med uppgiftens andra exempel ger det `only`, `these`, `words`, `are`,
`correct`. Rätt svar.

### Varför ser det ut så

Jämför med facit 4. **En enda rad skiljer:**

```
facit 4   if (ord.Length > 3)
facit 5   if (i % 2 == 1)
```

Det är hela uppgiften. Allt annat hade du redan efter steg 4.

Och notera vad villkoret tittar på. I facit 4 tittade det på **ordet**.
Här tittar det på **varvnumret** — ordet i sig spelar ingen roll, bara
vilken position det har.

**`i % 2 == 1`** tecken för tecken:

- `i` — räknaren. Vilket varv vi är på
- `%` — modulo. Dela, behåll bara resten
- `2` — det vi delar med
- `==` — två likhetstecken. En FRÅGA: är detta lika med?
- `1` — resten vi letar efter

Ett `=` i stället för `==` ger `Cannot implicitly convert type 'int' to
'bool'`, vilket betyder: jag väntade mig ett sant-eller-falskt, men fick
ett tal.

### Fällan, och hur fel den blir

Så här ser den felaktiga versionen ut:

```csharp
if (i % 2 == 1)
{
    Console.WriteLine(Console.ReadLine());   // läser BARA på udda varv
}
```

Jag har kört båda. Med indata `5 / hello / i / am / an / echo`:

| | varv 1 | varv 2 | varv 3 | varv 4 | varv 5 | utskrift |
|---|---|---|---|---|---|---|
| rätt | läser hello, skriver | läser i | läser am, skriver | läser an | läser echo, skriver | hello am echo |
| fällan | läser hello, skriver | läser inte | läser i, skriver | läser inte | läser am, skriver | hello i am |

Fällan ger `hello`, `i`, `am`. Den skriver ut de tre första orden i rad och
ser vid en hastig blick nästan rimlig ut — tre rader, rätt antal. Det är
det som gör den farlig.

Orsaken står i tabellen: på varv 2 och 4 anropas aldrig `ReadLine`, så
markören står still. Varv 3 plockar därför upp `i` — ordet som stod på tur
— i stället för `am`.

**Läs alltid. Välj sedan.**

---

## Ordlista — orden som tillkommit

| ord | betyder |
|---|---|
| markören | den osynliga pekaren på "var i indata är jag". Går bara framåt |
| `Console.ReadLine()` | läs raden markören står på, flytta markören ett steg |
| `.Length` | antalet tecken i en sträng |
| `>` | större än. Strikt — `3 > 3` är falskt |
| `%` | modulo. Resten vid division |
| `i % 2 == 1` | `i` är udda |
| `i % 2 == 0` | `i` är jämnt |
| CS0136 | två lådor med samma namn i samma sammanhang |
| CS0103 | namnet finns inte — stavfel, eller lådan skapades aldrig |
| gränsen | `n`. Kommer från indata, ändras aldrig |
| räknaren | `i`. Ändras varje varv |

---

## Om du kör fast

1. **Läs felmeddelandet.** Högt, om det hjälper.
2. **Gå till kolumnen.** `Program.cs(3,19)` betyder rad 3, tecken 19.
   Inte "någonstans i filen".
3. **Många fel på en rad = ett trasigt tecken.** Inte många misstag.
4. **Warning stoppar dig inte.** Bara error.
5. **Fel utskrift utan felmeddelande?** Handkör. Gör tabellen med penna.
   Varv för varv, en kolumn per låda. Det hittar fel som ögat missar.
6. **Fem minuter, sedan facit.**

---

## Två knappar som inte gör samma sak

Du fastnade på det i går, så det står här också:

- **▷-knappen i VS Code** startar **felsökaren**. Inmatningen hamnar i
  Debug Console, inte i terminalen, och det blir förvirrande.
- **`dotnet run` i terminalen** kör bara programmet. Inmatning och utskrift
  på samma ställe.

Använd `dotnet run` medan du lär dig. Felsökaren är ett kraftfullt verktyg,
men den är ett eget ämne.
