# Simple Warehouse Manager (Console App)

Prosta aplikacja konsolowa w C# napisana w ramach nauki platformy .NET. Projekt to klasyczny "magazyn" realizujący operacje CRUD, stworzony, aby przećwiczyć programowanie obiektowe oraz nowsze funkcje języka.

## Co potrafi aplikacja?
* Pełna obsługa operacji CRUD (dodawanie, wyświetlanie, edycja ilości/ceny oraz usuwanie produktów).
* Walidacja wprowadzanych danych (zabezpieczenie przed wpisywaniem liter zamiast cyfr, pustych nazw itp.).

##  Czego się tu nauczyłem / Wykorzystane elementy:
* **C# / .NET 7+**
* **LINQ** (podstawowe operacje na kolekcjach, np. `FirstOrDefault`).
* **Typy generyczne z ograniczeniami** (`where T : ISpanParsable<T>`) – stworzyłem uniwersalną metodę do bezpiecznego wczytywania i parsowania liczb z konsoli.
* **Podstawy OOP** (enkapsulacja, walidacja danych wewnątrz właściwości klasy).
* **Nullable Reference Types** – świadome korzystanie z operatora `null!`.

## Jak uruchomić
1. Sklonuj repozytorium.
2. Otwórz projekt w Visual Studio.
3. Uruchom projekt (F5).
