# Trappan till Abracadabra

Sju mikroövningar, allt förklarat. 23 september 2026.

Samma innehåll finns som Google-dokument:
https://docs.google.com/document/d/1EDa6M5ZZKwGy6vMXTp-vLaEdH8d4Lhs9rXex6m5Feww/edit

---

## Så här arbetar du

1. Läs teorin för **ett** steg. Bara ett.
2. Skriv koden själv i `Program.cs`. Utan att titta i facit.
3. Kör den med `dotnet run`. Se vad som händer.
4. Läs facit längst ner — **även när du hade rätt**. Facit förklarar VARFÖR.
5. Sedan nästa steg.

Facit ligger samlat sist, med avsikt. Du ska ha chansen att försöka först.

**Kör du fast mer än fem minuter: titta i facit.** Det är inget nederlag.
Att sitta och stirra lär dig ingenting.

För varje ny övning: radera allt i `Program.cs` och skriv om från början.
Just att skriva om från tomt papper är poängen.

```
cd ~/kattis-csharp/ovningar
dotnet run
```

---

## Två regler som gäller alla sju stegen

### Regel 1: börja alltid med `using System;`

```csharp
using System;

// ... din kod här ...
```

`using` betyder "jag vill kunna nå verktygen i det här biblioteket".
`System` är biblioteket där `Console` bor.

På din maskin funkar koden även utan raden — .NET 10 lägger till den
osynligt. På Kattis gör den inte det, och då får du
`CS0103: The name 'Console' does not exist in the current context`.

Det var precis det som hände med Hello World.

### Regel 2: en varning är inte ett fel

`warning` betyder varning. Programmet kompilerar och kör ändå.
`error` betyder fel. Då kör ingenting.

Titta efter ordet. Bara `error` stoppar dig.

---

# STEG 1 — skriv ut en fast rad

## Teorin

Ett program gör ingenting av sig självt. Det finns bara en sak det kan
göra utan hjälp: visa något för dig.

```csharp
Console.WriteLine("något");
```

Tecken för tecken:

| Del | Betydelse |
|---|---|
| `Console` | terminalfönstret, sett inifrån programmet. Stort C — `console` finns inte |
| `.` | punkten betyder "inuti". `Console.WriteLine` = verktyget WriteLine som finns inuti Console |
| `WriteLine` | skriv ut, och byt sedan rad. `Write` utan `Line` byter inte rad |
| `( )` | två saker samtidigt: "gör det nu", och "här kommer det du gör det med" |
| `" "` | citattecken: ta det här bokstavligt, det är text |
| `;` | instruktionen är slut. Som punkt i en mening |

**Bilden:** du sitter bakom en lucka och ropar upp ett meddelande.
`Console` är luckan. `WriteLine` är att säga det högt. Citattecknen är
den exakta ordalydelsen.

## Övning 1

Skriv ett program som skriver ut exakt:

```
Hej, jag heter Pablo
```

Inget mer. Radera allt annat ur `Program.cs` först.

När det funkar: ändra texten till något annat och kör igen. Bara för att
känna att det är du som bestämmer.

---

# STEG 2 — flera rader i följd

## Teorin

Det nya här är inte ett verktyg. Det är en **regel om hur datorn läser**.

Ett program körs uppifrån och ned, en rad i taget. Datorn läser rad 1,
gör det som står där, går till rad 2, gör det, går till rad 3.

Den hoppar aldrig framåt eller bakåt om inte något uttryckligen säger åt
den att göra det. Loopen i steg 5 är just ett sådant "säger åt den".

```csharp
Console.WriteLine("ett");
Console.WriteLine("två");
```

ger

```
ett
två
```

Vill du ha dem i omvänd ordning byter du plats på raderna. Det finns
ingen annan hemlighet.

**Bilden:** en inköpslista. Du läser uppifrån och ned och gör en sak i
taget. Du hoppar inte till punkt 4 för att den ser roligare ut.

## Övning 2

Skriv ett program som skriver ut precis det här, i precis den ordningen:

```
Ett
Två
Tre
```

---

# STEG 3 — läs en rad text och skriv ut den

## Teorin

### Först: problemet

Ett program glömmer allt. Det har inget minne av sig självt. Tar det emot
något och inte lägger undan det, är det borta i samma ögonblick.

**Bilden:** någon säger ett telefonnummer till dig. Skriver du inte ned
det är det borta. Papperet är det som behövs.

### Sedan: lösningen — variabeln

En **variabel** är en låda med en etikett på. Du lägger ett värde i lådan,
och etiketten gör att du kan peka på den senare.

```csharp
string namn = "Pablo";
```

| Del | Betydelse |
|---|---|
| `string` | **typen**. Typ = vilken sorts sak det här är. `string` betyder text. Ordet betyder "en tråd av tecken" |
| `namn` | **namnet** på lådan. Etiketten. Du väljer det själv |
| `=` | betyder INTE "är lika med". Betyder "lägg högersidan IN I lådan på vänstersidan". Ett uppdrag, inte ett påstående |
| `"Pablo"` | värdet som läggs i lådan |

Läs raden högerifrån: ta texten Pablo, lägg den i en låda som heter namn,
och den lådan får bara innehålla text.

### Och: att läsa från användaren

```csharp
Console.ReadLine()
```

`ReadLine` betyder "läs en rad". Programmet **stannar och väntar** tills du
skrivit något och tryckt enter. Det du skrev kommer tillbaka som en
sträng.

Men det försvinner direkt om du inte lägger det i en låda. Därför skriver
man de två sakerna på samma rad:

```csharp
string namn = Console.ReadLine();
```

Läs högerifrån: läs en rad från användaren, och lägg det du får i en låda
som heter namn.

### Att använda lådan

```csharp
Console.WriteLine(namn);     // skriver INNEHÅLLET  ->  Pablo
Console.WriteLine("namn");   // skriver ordet        ->  namn
```

Citattecken = "ta det bokstavligt".
Utan citattecken = "det här är ett namn, hämta innehållet".

Samma skillnad som i FizzBuzz när du skrev `WriteLine(Fizz)` utan
citattecken och C# letade efter en låda som hette Fizz.

### Och att sätta ihop text med ett värde

```csharp
Console.WriteLine($"Hej {namn}");
```

| Del | Betydelse |
|---|---|
| `$` | dollartecknet, allra först, före citattecknet. Betyder: den här texten innehåller hål, leta efter dem. Utan det skrivs `{namn}` ut bokstavligen |
| `{ }` | **hålet**. Det som står inuti är ett namn vars värde ska in i hålet |
| `Hej ` | vanlig text, mellanslaget efter inräknat |

## Övning 3

Skriv ett program som:

1. Frågar efter ditt namn (skriv ut frågan)
2. Läser vad du svarar
3. Hälsar på dig med namnet i

Utskriften ska bli ungefär:

```
Vad heter du?
Pablo
Hej Pablo
```

Raden `Pablo` i mitten är det **du** skrev in. Den syns för att terminalen
visar det du knappar.

---

# STEG 4 — läs ett tal och räkna med det

## Teorin

Det nya här är en sak: **text går inte att räkna med.**

### Problemet

`Console.ReadLine()` ger alltid TEXT. Alltid. Även om du skriver `7`.

Det du får tillbaka är tecknet sju, inte talet sju. Skillnaden låter
hårdragen men den är total:

```
"7" + 1   ger  "71"     texten sju med en etta klistrad efter
 7  + 1   ger   8       talet sju plus ett
```

Plus mellan text betyder **klistra ihop**. Plus mellan tal betyder
**addera**. C# gör det du ber om, och är det ena text blir det klistring.

Det här är en av de vanligaste flervalsfällorna som finns.

**Bilden:** en lapp där det står "7". Lappen kan du inte lägga ihop med en
annan lapp och få 8. Du måste först läsa lappen och förstå att den
betyder talet sju.

### Lösningen — int.Parse

```csharp
int tal = int.Parse("7");
```

| Del | Betydelse |
|---|---|
| `int` | typen heltal. 1, 2, −47, 100. Inga decimaler. Kortform för *integer* |
| `tal` | namnet på lådan |
| `int.Parse` | Parse betyder **tolka**. Tar text, ger tillbaka ett heltal. Stort P |
| `( )` | här inne läggs texten som ska tolkas |

Går det inte — säg att texten var "hej" — får du `FormatException`.
Det betyder exakt: det här gick inte att tolka som ett tal.

### De två stegen ihopskrivna

Två rader, tydligast när man är ny:

```csharp
string rad = Console.ReadLine();
int tal = int.Parse(rad);
```

Eller en rad, vilket är vad du kommer se överallt:

```csharp
int tal = int.Parse(Console.ReadLine());
```

Exakt samma sak. Den inre parentesen görs först: läs raden. Sedan den
yttre: tolka som tal. Sedan `=`: lägg i lådan.

Båda är rätt.

### En sak du inte behöver här

I FizzBuzz skrev du `Split(' ')`. Det fanns där av ett skäl: **tre tal låg
på samma rad** och du behövde klippa isär dem.

Här ligger **ett** tal ensamt på raden. Det finns inget att klippa.
Ingen Split.

## Övning 4

Skriv ett program som:

1. Ber användaren om ett tal
2. Läser talet
3. Skriver ut talet plus ett

Matar du in `7` ska det stå `8`.

**När det funkar — gör också det här, det är halva poängen:** ta bort
`int.Parse` och använd texten direkt i additionen. Kör. Se vad som står.
Då har du sett fällan med egna ögon i stället för att läsa om den.

---

# STEG 5 — skriv ut 1 till 5 med en loop

## Teorin

### Problemet

Du vill skriva ut 1, 2, 3, 4, 5 på var sin rad. Du **kan** göra det med fem
`WriteLine`-rader. Det funkar.

Men vore det 1 till 100 blir det hundra rader. Och — viktigare — om
antalet bestäms av något användaren skriver in, vet du inte ens hur många
rader du ska skriva. Du kan inte skriva kod för ett antal du inte känner
till.

### Lösningen — loopen

Du skriver instruktionen **en** gång, och talar om hur många varv.

```csharp
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}
```

Inom parentesen står **tre delar**, åtskilda av semikolon. De svarar på tre
frågor:

| Del | Fråga | Vad som händer |
|---|---|---|
| `int i = 1` | **Var börjar jag?** | Skapa en låda som heter `i` och lägg 1 i den. Händer EN gång, före första varvet. `i` är bara ett namn — tradition, står för index |
| `i <= 5` | **Ska jag fortsätta?** | "i är mindre än eller lika med 5". Kontrolleras FÖRE varje varv. Sant → kör varvet. Falskt → hoppa ut |
| `i++` | **Vad händer mellan varven?** | `++` betyder öka med ett. Kortform för `i = i + 1`. Händer EFTER varje varv |

Semikolon **mellan** delarna, men **inget** semikolon efter slutparentesen.
Ett semikolon där gör att loopen kör tom.

### Måsvingarna

```csharp
for ( ... )
{
    // allt som står här körs en gång per varv
}
```

Måsvingar samlar ihop rader till **ett block**: "allt det här hör ihop".
Öppnande `{` ska ha ett stängande `}`.

Skriv dem alltid i par direkt, innan du fyller i innehållet. Då glömmer du
aldrig det andra.

### Handkörningen

```
i = 1    1 <= 5 sant     skriver 1     sedan i = 2
i = 2    2 <= 5 sant     skriver 2     sedan i = 3
i = 3    3 <= 5 sant     skriver 3     sedan i = 4
i = 4    4 <= 5 sant     skriver 4     sedan i = 5
i = 5    5 <= 5 sant     skriver 5     sedan i = 6
i = 6    6 <= 5 FALSKT   klart, ut ur loopen
```

Fem varv. Fem rader utskrift.

Sista raden är inget varv — villkoret prövas, är falskt, loopen slutar.
Men du måste skriva den raden när du handkör, annars vet du inte att du är
klar.

Tecknet `<=` skrivs med vinkelparentes och likhetstecken. Det var här du
fastnade i måndags: macOS autokorrigering bytte `<` mot ett franskt
citattecken och du fick fem felmeddelanden av ett enda tecken.

## Övning 5

Skriv ett program som skriver ut talen 1 till 5, ett per rad, med en
for-loop. Ingen indata. Ingen ReadLine. Bara loopen.

**När det funkar — gör de här tre ändringarna, en i taget, och kör efter
varje. Gissa först, kör sedan:**

- a) ändra `5` till `10`
- b) ändra `int i = 1` till `int i = 0`
- c) ändra `i <= 5` till `i < 5`

Det tar tre minuter och lär dig mer om loopen än att läsa om den igen.

---

# STEG 6 — skriv ut 1 till n, där n läses in

## Teorin

Här finns **ingenting nytt alls**. Noll nya verktyg.

Det enda som händer är att två saker du redan kan sätts ihop:

- **steg 4** — läs ett tal från användaren och lägg det i en låda
- **steg 5** — loopa från 1 till ett bestämt tal

Det bestämda talet i loopen behöver inte vara en siffra du skrivit. Det
kan vara **namnet på en låda**.

```csharp
for (int i = 1; i <= 5; i++)   // slutar vid 5
for (int i = 1; i <= n; i++)   // slutar vid det som ligger i n
```

C# tittar i lådan `n` varje gång villkoret prövas.

**Bilden:** du frågar någon "hur många ska jag räkna till?" och de svarar
sju. Du räknar 1 till 7. Du visste inte i förväg att det var sju — du
frågade först.

**Ordningen** är det enda som måste stämma:

1. läs in `n` — måste ske FÖRE loopen
2. loopa till `n`

Loopen kan inte använda `n` innan `n` finns. Datorn läser uppifrån och ned.

## Övning 6

Skriv ett program som:

1. Läser ett tal från användaren
2. Skriver ut talen 1 till och med det talet, ett per rad

Matar du in `3` ska det stå:

```
1
2
3
```

Kör det tre gånger med olika tal. Känns det trivialt nu — då är trappan
byggd rätt.

---

# STEG 7 — Abracadabra

## Teorin

Nu är du framme. Det här är **steg 6 plus stränginterpolationen**. Inget
annat.

Uppgiften heter *Stuck In A Time Loop* och ligger på
https://open.kattis.com/problems/timeloop

Indata: ett heltal N mellan 1 och 100.
Utdata: N rader, där rad nummer i är talet i, ett mellanslag, och ordet
Abracadabra.

För N = 5:

```
1 Abracadabra
2 Abracadabra
3 Abracadabra
4 Abracadabra
5 Abracadabra
```

Jämför med steg 6. Där skrev du ut bara talet:

```csharp
Console.WriteLine(i);
```

Här ska du skriva ut talet **och** ett ord efter. Det är det enda som är
annorlunda. Verktyget:

```csharp
$"{i} Abracadabra"
```

| Del | Betydelse |
|---|---|
| `$` | det finns hål i den här texten |
| `{i}` | hålet, fylls med innehållet i lådan `i` |
| `" Abracadabra"` | vanlig text — **och se noga på mellanslaget**. Det ligger innanför citattecknen, direkt efter måsvingen. Glömmer du det blir det `1Abracadabra` och Kattis underkänner |

## När du ska lägga det i repot

Det här är den första riktiga Kattis-lösningen efter Hello World. Eget
projekt, precis som då:

```
cd ~/kattis-csharp
dotnet new console -o timeloop
cd timeloop
```

Skriv koden i `timeloop/Program.cs`. Glöm inte `using System;`.

Testa lokalt med `dotnet run`, mata in `5`, kontrollera tecken för tecken.
Klistra sedan in i Kattis, submit, och när den är grön — commit och push.

## Övning 7

Lös Stuck In A Time Loop.

---
---

# FACIT — MED FÖRKLARING

Läs det här **även när du hade rätt**. Förklaringen är det som gör nästa
steg snabbare.

---

## Facit 1 — en fast rad

```csharp
using System;

Console.WriteLine("Hej, jag heter Pablo");
```

**Varför ser det ut så:**

Hela programmet är en enda instruktion. `using`-raden är inte en
instruktion — den säger bara var verktygen finns, den gör ingenting.

Texten står innanför citattecken för att den ska tas bokstavligt.
Kommatecknet inuti citattecknen är bara ett tecken bland andra.

Semikolon på slutet. Och ja: `using System;` har också semikolon. Det är
en av få rader som inte är en instruktion men ändå avslutas med semikolon.

**Vanliga fel här:**

```
console.WriteLine    litet c  ->  CS0103, namnet finns inte
Console.Writeline    litet l  ->  CS0117 eller CS1061
glömt semikolon               ->  ; expected
```

---

## Facit 2 — tre rader

```csharp
using System;

Console.WriteLine("Ett");
Console.WriteLine("Två");
Console.WriteLine("Tre");
```

**Varför ser det ut så:**

Tre instruktioner, var och en avslutad med semikolon, utförda i den ordning
de står.

Det finns ingen smartare lösning här och den ska inte finnas. Poängen är
att du ska känna att ordningen i filen är ordningen i utskriften —
ingenting annat styr den.

Bytte du plats på två rader och körde om? Bra. Då **vet** du det nu i
stället för att tro det.

---

## Facit 3 — läs text och hälsa

```csharp
using System;

Console.WriteLine("Vad heter du?");

string namn = Console.ReadLine();

Console.WriteLine($"Hej {namn}");
```

**Varför ser det ut så:**

**Rad 1** ställer frågan. Utan den stannar programmet och väntar utan att
tala om varför — användaren ser ett tomt fönster. Frågan är inte pynt, den
är en del av programmet.

**Rad 2** gör två saker, läs den högerifrån:

```
Console.ReadLine()   läs en rad. Programmet stannar och väntar.
string namn =        lägg det du fick i en låda som heter namn.
```

Hade du hoppat över `string namn =` och bara skrivit `Console.ReadLine();`
hade programmet väntat på dig, tagit emot ditt namn — och slängt det.
Det är precis telefonnummer-problemet.

**Rad 3** sätter ihop fast text med innehållet i lådan.

**Alternativet som också är rätt:**

```csharp
Console.WriteLine("Hej " + namn);
```

Plus mellan text och text betyder klistra ihop. Funkar. Men se var
mellanslaget måste ligga — inuti citattecknen, efter Hej. Det är den
detaljen interpolation gör lättare att hålla reda på.

**Båda är rätt.** Det är skillnad på FEL och ANNORLUNDA.

---

## Facit 4 — läs ett tal och räkna

```csharp
using System;

Console.WriteLine("Ge mig ett tal:");

string rad = Console.ReadLine();
int tal = int.Parse(rad);

int resultat = tal + 1;

Console.WriteLine(resultat);
```

**Varför ser det ut så:**

`string rad = Console.ReadLine();` — här ligger ditt svar som TEXT. Skrev
du 7 så innehåller lådan tecknet sju, inte talet sju.

`int tal = int.Parse(rad);` — tolkar texten som heltal. Nu, och först nu,
går det att räkna med.

`int resultat = tal + 1;` — ny låda, typ int. Högersidan räknas ut FÖRST,
sedan läggs resultatet i lådan.

`Console.WriteLine(resultat);` — utan citattecken, alltså innehållet. Med
citattecken hade det stått ordet `resultat`.

**Kortare version, också rätt:**

```csharp
using System;

int tal = int.Parse(Console.ReadLine());
Console.WriteLine(tal + 1);
```

Samma sak, färre lådor. Den långa versionen är lättare att handköra när
man är ny. Den korta är vad du kommer se i andras kod.

**Och det du skulle prova:**

```csharp
string rad = Console.ReadLine();
Console.WriteLine(rad + 1);
```

Matar du in `7` står det `71`. Inte 8.

Varför: `rad` är TEXT. Plus mellan text och något annat betyder klistra
ihop. C# gör om ettan till texten "1" och limmar fast den.

**Inget felmeddelande. Programmet kör. Svaret är bara fel.**

Samma familj som `7 / 2` blir `3` — heltalsdivision kastar decimalerna
utan att säga till. Fel som inte larmar är farligare än fel som kraschar.

---

## Facit 5 — loopen, 1 till 5

```csharp
using System;

for (int i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}
```

**Varför ser det ut så:**

- `int i = 1` — börja på 1. Uppgiften sa 1 till 5, inte 0 till 5.
- `i <= 5` — mindre än ELLER LIKA MED. Femman ska vara med. Hade det stått
  `i < 5` hade loopen slutat efter 4.
- `i++` — öka med ett efter varje varv. Utan den skulle `i` för alltid vara
  1, villkoret alltid sant, och programmet skriva ut ettor tills du bryter
  det. Det kallas en **oändlig loop**.

**Och de tre ändringarna:**

```
a) i <= 10          ->  tio rader, 1 till 10
b) int i = 0        ->  sex rader: 0 1 2 3 4 5
                        Ett varv MER, inte ett annat.
                        Starten flyttades ned, slutet står kvar.
c) i < 5            ->  fyra rader: 1 2 3 4
                        När i blir 5 är 5 < 5 falskt.
```

Skillnaden mellan `<` och `<=`, och vad startvärdet gör, är rakt igenom
den vanligaste källan till "ett för många" eller "ett för få". Det har ett
eget namn i branschen: **off-by-one**.

---

## Facit 6 — loopen med inläst n

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    Console.WriteLine(i);
}
```

**Varför ser det ut så:**

`int n = int.Parse(Console.ReadLine());` — läs en rad, tolka som heltal,
lägg i lådan n. Den **har** att ligga före loopen. Datorn läser uppifrån
och ned — hade raden legat efter loopen hade C# sagt CS0103, namnet n
finns inte, för på den punkten i filen fanns det inte än.

`i <= n` — enda skillnaden mot steg 5. En siffra bytt mot ett namn.

**Två lådor, två jobb:**

```
n   sätts en gång, ändras aldrig.  Den är GRÄNSEN.
i   ändras varje varv.             Den är RÄKNAREN.
```

Blandar du ihop dem blir det fel på ett sätt som är svårt att se. Ge dem
namn du hör skillnad på när du är osäker: `grans` och `varv` i stället för
`n` och `i`.

---

## Facit 7 — Abracadabra

```csharp
using System;

int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    Console.WriteLine($"{i} Abracadabra");
}
```

**Varför ser det ut så:**

Jämför med facit 6. **En enda rad skiljer:**

```
facit 6   Console.WriteLine(i);
facit 7   Console.WriteLine($"{i} Abracadabra");
```

Det är hela uppgiften. Allt annat hade du redan.

Raden tecken för tecken:

```
$                 dollartecknet. Utan det skrivs {i} ut bokstavligen
"                 citattecknet öppnar texten
{i}               hålet. Fylls med innehållet i lådan i
(mellanslag)      ETT mellanslag, innanför citattecknen.
                  Utan det: 1Abracadabra. Underkänt.
Abracadabra       fast text. Stort A. Kattis jämför tecken för tecken
"                 stänger texten
)                 stänger WriteLine
;                 instruktionen slut
```

**Ingen Split här.** I FizzBuzz låg tre tal på samma rad och måste klippas
isär. Här ligger ett tal ensamt. Det finns ingenting att klippa.

---

# Ordlista

| Ord | Betydelse |
|---|---|
| `using` | säg var verktygen finns. Kattis kräver `using System;` |
| `Console` | terminalfönstret, sett inifrån programmet |
| `WriteLine` | skriv ut och byt rad |
| `Write` | skriv ut utan att byta rad |
| `ReadLine` | läs en rad från användaren, ge tillbaka TEXT |
| variabel | en låda med etikett, där ett värde sparas |
| typ | vilken sorts sak något är |
| `string` | typen text |
| `int` | typen heltal. Inga decimaler |
| `=` | lägg in i. Ett uppdrag |
| `==` | är lika med. En fråga |
| `int.Parse` | tolka text som heltal |
| stränginterpolation | `$"{...}"` — sätt in ett värde mitt i en text |
| loop | gör något om och om igen |
| for-loopen | tre delar: var börjar jag, ska jag fortsätta, vad händer mellan varven |
| `i++` | öka i med ett |
| `<` | mindre än |
| `<=` | mindre än eller lika med |
| `{ }` | måsvingar. Samlar rader till ett block |
| `;` | instruktionen är slut |
| `warning` | varning. Programmet kör ändå |
| `error` | fel. Ingenting körs |
| off-by-one | ett varv för många eller för få. Vanligaste loopfelet |

---

# Om du kör fast

**1. Läs felmeddelandet.** Högt, om det hjälper.

**2. Gå till kolumnen.** Felet ser ut så här:

```
Program.cs(3,19): error CS1002: ; expected
```

Det betyder **rad 3, tecken 19**. Inte "någonstans i filen". Ställ
markören där och titta på det tecknet.

**3. Många fel på en rad = ett trasigt tecken.** Du har haft tre sådana på
tre dagar: ett franskt citattecken i stället för `<`, och en punkt i
stället för semikolon. När fem fel pekar på samma rad, leta efter ETT
tecken — inte fem misstag.

**4. Warning stoppar dig inte.** Bara error.

**5. Fem minuter, sedan facit.** Att stirra lär dig ingenting.
