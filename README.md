# GymBuddy
<img width="338" alt="GymBuddyLogo" src="https://github.com/KimAloshynNoA/GymBuddy/assets/107928665/934bbf20-2ca8-43b4-8483-792dc07dc96e">


## Opis
Aplikacja jest przyznaczona dla osób aktywnych, uprawiających różne rodzaje sportu. Umozliwia łatwą organizację poszczególnych ćwiczeń, podzialonych na kategorie i monitorowanie postępów. 
Również planowana jest aktualizacja, która pozwoli prowadzić kalendarz treningów wraz z przypomnieniami o ich nadchodzeniu. 

## Funkcje i cechy

* Rejestracja i logowanie użytkownika
* Sesja użytkownika
* Wylogowanie użytkownika
* Haszowanie hasła
* Tworzenie nowych rodzajów aktywności oraz treningów do nich należących
* Zapisywanie postępów w poszczególnych ćwiczeniach i porównywanie ich z treningiem poprzednim. 
* Dodawanie nowych użytkowników do bazy przez administratora

## Użyte technologie

* ASP.NET
* Entity Framework
* Postgres SQL
* HTML 5
* SCSS
* React
* Material UI

## Przygotowanie środowiska lokalnego do części Backend

* Zainstaluj pgAdmin. Tu znajdziesz dla Windows -> https://www.pgadmin.org/download/pgadmin-4-windows/
* Utwórz Server, ustal hasło, swórz baze dnaych gymbuddy-db i zmodyfikuj ConnectionString w appsettings.json.
* Mając otwartą solucję w VisualStudio w PackageManagerConsole wykonaj komendę "update-database". To sprawi, że EntityFramework utworzy tabele w bazie na podstawie zdefiniowanych Models.

## Diagram ERD
<img width="509" alt="DiagramERD" src="https://github.com/KimAloshynNoA/GymBuddy/assets/107928665/8f29dab7-0ea8-4ad9-a43a-3e62f3969b50">
