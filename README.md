# Integruoto-laboratoriniai

Naudojimo instrukcijos:
- Norint sukurti studentą:
  1. Parašome '1' ir spaudžiame Enter
  2. Įrašome vardą ir spaudžiame Enter
  3. Įrašome pavardę ir spaudžiame Enter
  4. Įrašome pirmojo namų darbo įvertinimą ir spaudžiame Enter
  5. Pasirinktinai: Jeigu reikia daugiau namų darbų, kartoti nuo 4 žingsnio, toliau keliauti į 6 žingsnį.
  6. Įrašyti '-1', kad baigti namų darbų įvertinimų įrašymą ir spaudžiame Enter
  7. Jūsų nuožiūrą pasirinkti ar generuoti egzamino įvertinimus ar ranka. Taip/Ne
  8. Jeigu pasirinkote Ne: įrašykite skaičių ir spaudžiame Enter ir einame į žingsnį 10.
  9. Jeigu pasirinkote Taip: eikite į žingsnį 10.
  10. Jūsų nuožiūra pasirinkti ar sukurti dar vieną studentą. Taip/Ne
  11. Jeigu pasirinkote Taip: eikite į žingsnį 2.
  12. Jeigu pasirinkote Ne: grįžote į pradinį meniu.
- Norint nuskaityti iš failo:
  1. Parašome '2' ir spaudžiame Enter.
  2. Jeigu jūsų paleistoje aplinkoje yra failas 'kursiokai4.txt' bus sėkmingai išsaugoti Studentai sąraše.
  3. Jeigu jūsų paleistoje aplinkoje nėra failo 'kursiokai4.txt' bus rodoma klaida ir ši funkcija neveiks.
- Norint pamatyti studentų lentelę:
  1. Parašome '3' ir spaudžiame Enter.
- Norint sugeneruoti atsitiktinius studentų sąrašų failus:
  1. Parašome '4' ir spaudžiame Enter
- Norint pamėginti skirtingų konteinerių dviejų strategijų testus rūšiuojant studentus iš 'kursiokai4.txt' failo:
  1. Parašome '5' ir spaudžiame Enter

v0.1 Release:
* Galimybė sukurti Studentas objektą pagal kintamuosius Vardas, Pavardė, Namų darbų balai, Egzamino balas.
* Galimybė automatizuoti balų sukurimą.
* Galimybė pasirinkti tarp Medianos ir Vidurkio apskaičiavimo.

v0.2 Release:
* Galimybė sukurti Studentas objektą pagal kintamuosius Vardas, Pavardė, Namų darbų balai, Egzamino balas įrašant ranka arba automatizuotai po pirmo sukurto ranka studento.
* Galimybė nuskaityti iš failo ir išsaugoti į studentų List naujus studentus.
* Galimybė pasirinkti iš menių kurią funckiją atlikti
* Lentelėje surūšiuota pagal Vardą stulepli ir rodomas Vidurkis bei Mediana.

v0.3 Release:

* Atskirtos klasės nuo pagrindinės Program klasės.
* Pridėti keli try ir catch blokai, kad pagauti klaidas ir jas apibūdinti

v0.4 Release:

* Galimybė sukurti Studentas objektą pagal kintamuosius Vardas, Pavardė, Namų darbų balai, Egzamino balas įrašant ranka arba automatizuotai po pirmo sukurto ranka studento.
* Galimybė nuskaityti iš failo ir išsaugoti į studentų List naujus studentus.
* Galimybė pasirinkti iš menių kurią funckiją atlikti
* Lentelėje surūšiuota pagal Vardą stulepli ir rodomas Vidurkis bei Mediana.
* Galimybė sukurti 5 failus su 10 iki 100000 įrašų ir juos išrūšiuoti į du failus bei rodoma kiek laiko užtrūko programa.

v0.5 Release:

* Padaryti kodo efektyvumo testavimai pakeičiant List tipą į LinkedList ir Queue.
* Didelio skirtumo nebuvo, tad efektyvumas neatrastas.
* Laikmačio testai aprašyti ReadMe.md faile.


v1.0 pridėti testavimai Studentų rūšiavimui į du konteinerius pagal vidurkį, šio testo rezultatai:

```
------------ Pradedamas pirmasis testas su List ------------
Pries sort Memory usage: 3980877824
Pradedamas skaiciavimas List rusiavimas i Vargsus ir Kietekus
RunTime 00s 00ms
Po sort Memory usage: 3981172736(294912)
------------ Baigtas pirmasis testas su List ------------
```

```
------------ Pradedamas pirmasis testas su LinkedList ------------
Pries sort Memory usage: 3981172736
Pradedamas skaiciavimas LinkedList rusiavimas i Vargsus ir Kietekus
RunTime 00s 00ms
Po sort Memory usage: 3982168064(995328)
------------ Baigtas pirmasis testas su LinkedList ------------
```

```
------------ Pradedamas pirmasis testas su Queue ------------
Pries sort Memory usage: 3982176256
Pradedamas skaiciavimas Queue rusiavimas i Vargsus ir Kietekus
RunTime 00s 00ms
Po sort Memory usage: 3982594048(417792)
------------ Baigtas pirmasis testas su Queue ------------
```

```
------------ Pradedamas antrasis testas su List ------------
Pries sort Memory usage: 3982602240
Pradedamas skaiciavimas List rusiavimas i Vargsus ir Kietekus
RunTime 00s 26ms
Po sort Memory usage: 3982721024(118784)
------------ Baigtas antrasis testas su List ------------
```

```
------------ Pradedamas antrasis testas su LinkedList ------------
Pries sort Memory usage: 3982729216
Pradedamas skaiciavimas LinkedList rusiavimas i Vargsus ir Kietekus
RunTime 00s 00ms
Po sort Memory usage: 3983024128(294912)
------------ Baigtas antrasis testas su LinkedList ------------
```

```
------------ Pradedamas antrasis testas su Queue ------------
Pries sort Memory usage: 3983024128
Pradedamas skaiciavimas Queue rusiavimas i Vargsus ir Kietekus
RunTime 00s 00ms
Po sort Memory usage: 3983298560(274432)
------------ Baigtas antrasis testas su Queue ------------
```

Naudojant pirmąją strategija, puikiai matosi kiek daugiau naudoja Memory, skliausteliuose aprašyta kiek padidėjo memory po sort.
Naudojant antrąją strategiją, sumažėja memory sąnaudos bet viename iš testų pasirodė padidėjęs sortinimo laikas 26ms prie List.

Integruoto-laboratoriniai:
1. Galimybė sukurti Studentas objektą pagal kintamuosius Vardas, Pavardė, Namų darbų balai, Egzamino balas įrašant ranka arba automatizuotai po pirmo sukurto ranka studento.
2. Galimybė nuskaityti iš failo ir išsaugoti į studentų List naujus studentus.
3. Galimybė pasirinkti iš menių kurią funckiją atlikti
4. Lentelėje surūšiuota pagal Vardą stulepli ir rodomas Vidurkis bei Mediana.
5. Galimybė sukurti 5 failus su 10 iki 100000 įrašų ir juos išrūšiuoti į du failus bei rodoma kiek laiko užtrūko programa.

Laikmačio testai
|ID|Type|Method|Laikas|
|---|---|---|---|
|1|List|Add|11s 49ms|
|2|List|Add|11s 23ms|
|3|List|Add|11s 33ms|
|4|LinkedList|AddFirst|11s 46ms|
|5|LinkedList|AddFirst|11s 44ms|
|6|LinkedList|AddFirst|11s 26ms|
|7|LinkedList|AddLast|11s 35ms|
|8|LinkedList|AddLast|11s 29ms|
|9|LinkedList|AddLast|11s 28ms|
|10|Queue|Enqueue|11s 59ms|
|11|Queue|Enqueue|11s 29ms|
|12|Queue|Enqueue|11s 26ms|

Norint pridėti į sąrašą objektus nepasirodė pakankamai didelis skirtumas, kad pagerintų programos greitį.
