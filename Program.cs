using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ZaliczenieApp
{
    class Program
    {

        static void Main()
        {
            Dictionary<string, double> oceny = new Dictionary<string, double>();
            XmlDocument XmlBaza = new XmlDocument();
            var menu = true;
            var pmenu = false;
            //Sprawdza czy istnieje baza danych. Jeśli nie to tworzy jeśli istnieje otwiera.
            //Małe pliki więc XmlDocument nie będzie nam zjadał dużo pamięci.
            if (!File.Exists("studenci.xml"))
            {
                Console.WriteLine("Nie znaleziono pliku studenci.xml! Utworzono nowy plik");
                XmlNode rootNode = XmlBaza.CreateElement("Lista");
                XmlBaza.AppendChild(rootNode);
                XmlBaza.Save("studenci.xml");
            }
            else
            {
                XmlBaza.Load("studenci.xml");
            }

            while (menu == true)
            {
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "MENU GŁÓWNE"));
                Console.WriteLine("W celu wywołania funkcji programu należy nacisnąć odpowiadającą jej cyfrę na klawiaturze.");
                Console.WriteLine("[1] Dodaj studenta.");
                Console.WriteLine("[2] Usuń studenta.");
                Console.WriteLine("[3] Wprowadź zmiany w danych studenta lub jego ocenach.");
                Console.WriteLine("[4] Wyświetl średnią, medianę średnich i odchylenie standardowe ocen wszystkich studentów.");
                Console.WriteLine("[5] Zapisz i Zamknij Program.");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Wybrano opcję dodania studenta. Struktura składa się z: ");
                        Console.WriteLine("1. Imienia i nazwiska.");
                        Console.WriteLine("2. Numeru indeksu.");
                        Console.WriteLine("3. Semestru.");
                        Console.WriteLine("4. Słownika zawierającego pojedynczą ocenę z przedmiotu o danej nazwie.");
                        Console.WriteLine("Podaj imię i nazwisko studenta:");
                        string imienazwisko = Console.ReadLine();
                        Console.WriteLine("Podaj nazwę semestru studenta:");
                        string semestr = Console.ReadLine();
                        pmenu = true;
                        while (pmenu == true)
                        {
                            Console.WriteLine("[1]Imię i nazwisko: " + imienazwisko);
                            Console.WriteLine("[2]Semestr: " + semestr);
                            Console.WriteLine("[3]Dane są poprawne.");
                            Console.WriteLine("Jeśli wprowadzone dane są poprawne zatwierdź je cyfrą 3.");
                            Console.WriteLine("Jeśli wprowadzone dane są niepoprawne wywołaj je jak funkcję programu i podaj nową wartość.");
                            switch (Console.ReadKey().Key)
                            {
                                case ConsoleKey.D1:
                                    Console.WriteLine("--> Wprowadź imię i nazwisko studenta:");
                                    imienazwisko = Console.ReadLine();
                                    Console.WriteLine("--> Dane po dokonaniu zmiany:");
                                    break;
                                case ConsoleKey.D2:
                                    Console.WriteLine("--> Wprowadź nazwę semestru studenta:");
                                    semestr = Console.ReadLine();
                                    Console.WriteLine("---> Dane po dokonaniu zmiany:");
                                    break;
                                case ConsoleKey.D3:
                                    Console.WriteLine("--> Zatwierdzono poprawność powyższych danych.");
                                    Console.WriteLine("Dane zostały wprowadzone do bazy studentów.");
                                    Console.WriteLine("--->Nastąpi teraz powrót do menu głównego.");

                                    XmlNode rootNode = XmlBaza.CreateElement("Lista");

                                    XmlNode student = XmlBaza.CreateElement("Student");
                                    rootNode.AppendChild(student);

                                    XmlNode imie = XmlBaza.CreateElement("Name");
                                    imie.InnerText = imienazwisko;
                                    student.AppendChild(imie);

                                    XmlNode seme = XmlBaza.CreateElement("Semestr");
                                    seme.InnerText = semestr;
                                    student.AppendChild(seme);
                                    
                                    XmlBaza.Save("studenci.xml");
                                    pmenu = false;
                                    break;
                                default:
                                    Console.WriteLine("<-- Wprowadzone polecenie nie jest poprawne! Zadziałają tutaj tylko cyfry od 1 do 3.");
                                    break;
                            }
                        }
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("--> Wybrano opcję usunięcia studenta.");
                        Console.WriteLine("Podaj imię i nazwisko studenta lub jego numer indeksu.");
                        var szukany = Console.ReadLine();
                       // if() { }
                        //Ewentualnie pojawi się komunikat o jego braku w bazie danych.
                        Console.WriteLine("Jeśli chcesz usunąć studenta z bazy danych musisz napisać 'POTWIERDZAM' i zatwierdzić polecenie enterem.");
                        Console.WriteLine("Aby anulować polecenie należy napisać 'ANULUJ'.");
                        switch (Console.ReadLine())
                        {
                            case "POTWIERDZAM":
                                break;
                            case "ANULUJ":
                                break;
                            default:
                                Console.WriteLine("<-- Wprowadzone polecenie nie jest poprawne! Napisz ANULUJ lub POTWIERDZAM.");
                                break;
                        }
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        break;

                    case ConsoleKey.D5:
                        XmlBaza.Save("studenci.xml");
                        //System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("<-- Wprowadzone polecenie nie jest poprawne!");
                        break;
                }
            }
        }

    }

}