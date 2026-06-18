# Simple Warehouse Manager (Console App)

Prosta aplikacja konsolowa w C# napisana w ramach nauki platformy .NET. Projekt to klasyczny "magazyn" realizujący operacje CRUD. Początkowo oparty na listach w pamięci, **został zrefaktoryzowany do pracy z prawdziwą relacyjną bazą danych** przy użyciu nowoczesnego ORM.

## Co potrafi aplikacja?
* Pełna obsługa operacji CRUD (dodawanie, wyświetlanie, edycja ilości/ceny oraz usuwanie produktów).
* Trwały zapis danych do relacyjnej bazy danych.
* Walidacja wprowadzanych z konsoli danych (zabezpieczenie przed wpisywaniem liter zamiast cyfr, pustych nazw itp.).

## Wykorzystane technologie i umiejętności:
* **C# / .NET 7+**
* **Entity Framework Core** (podejście Code-First) – zarządzanie bazą danych z poziomu kodu obiektowego.
* **SQL Server (LocalDB)** – trzymanie danych w relacyjnej bazie.
* **Migracje EF Core** – płynne generowanie i aktualizowanie schematu bazy z poziomu Konsoli Menedżera Pakietów.
* **LINQ** – operacje i zapytania do bazy danych (np. `FirstOrDefault`, `ToList`).
* **Typy generyczne z ograniczeniami** (`where T : ISpanParsable<T>`) – uniwersalna metoda do bezpiecznego wczytywania i parsowania liczb z konsoli.
* **Podstawy OOP** – enkapsulacja, wydzielenie modeli danych i logiki.

## Jak uruchomić
1. Sklonuj repozytorium.
2. Otwórz projekt w Visual Studio.
3. W górnym menu wybierz *Narzędzia* -> *Menedżer pakietów NuGet* -> *Konsola menedżera pakietów*.
4. Wpisz komendę `Update-Database` i wciśnij Enter, aby automatycznie utworzyć lokalną bazę danych SQL na swoim komputerze.
5. Uruchom projekt (F5).
