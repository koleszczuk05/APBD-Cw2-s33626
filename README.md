Podzieliłem klasy na obiekty, np. User albo Device, i zrobiłem do nich klasy serwisowe, np. DeviceService i UserService, zgodnie z zasadą SRP, żeby klasy miały tylko jedną odpowiedzialność: klasy serwisowe do obsługi, a tamte jako obiekty tego, co będzie obsługiwane.

Zrobiłem klasy bazowe, takie jak User i Device, żeby później, chcąc rozszerzyć typ urządzeń albo użytkowników, wystarczyło tylko dziedziczyć po klasie bazowej zgodnie z zasadą OCP.

Klasy pochodne są wymienne z klasami bazowymi bez wpływu na działanie, np. RentDevice przyjmuje Device, ale niezależnie od tego, czy przekażemy np. Laptop albo Camera, i tak będzie dobrze działać zgodnie z zasadą LSP.

Stworzyłem 3 oddzielne klasy Service: UserService, RentalService i DeviceService, żeby nie robić wszystkiego w jednej wielkiej klasie serwisowej, tylko wydzielić metody do różnych klas, które odpowiadają za dany typ, zgodnie z zasadą ISP.

Serwisy nie tworzą same obiektu IDataBase, tylko przekazuje się im go w konstruktorze, żeby nie zależały od siebie, tylko mogły działać oddzielnie. Tak samo daję tam interfejs IDataBase, żeby nie było to zależne od konkretnej klasy, zgodnie z zasadą DIP.

W moim projekcie przykładem wysokiej kohezji jest wydzielenie odpowiedzialności za kwestie związane z użytkownikami do klasy UserService, spraw związanych z wypożyczeniami do RentalService, a rzeczy dotyczących urządzeń do DeviceService. Przykładem niskiego sprzężenia jest zastosowanie oddzielnego interfejsu IDataBase, który przekazujemy w konstruktorze, zamiast tworzyć nową instancję bazy w każdej klasie, która jej używa. Dzięki temu wszystkie serwisy ze sobą współpracują, ale nie są od siebie sztywno zależne. Podzielenie na te różne klasy User, Device, ich pochodne i te 3 serwisowe to odpowiedzialność klas, żeby wszystko nie było w jednym miejscu.

Uruchomienie:
Otworzyć projekt w Riderze, uruchomić Program.cs. W konsoli wyświetla się automatyczny test sprawdzający wymagania z Worda.

Wybrałem model podzielenia na Models, Service, Data i Enums, żeby odseparować dane od logiki biznesowej. Modele to czyste dane, serwisy zawierają logikę biznesową, a data to magazyn danych, w którym są one przetrzymywane. Ułatwia to zmienianie różnych rzeczy, bo wiadomo, gdzie co jest i nie trzeba tego szukać w wielkiej klasie, tylko od razu wiadomo gdzie i nie powinno mieć to wpływu na inne klasy.

Opis projektu:
Projekt implementuje prosty system wypożyczalni sprzętu elektronicznego (Laptop, Camera, Projector) dla 2 typów użytkowników: Student i Employee. System pilnuje limitów wypożyczeń (maksymalnie 2 urządzenia dla Studenta, 5 dla Pracownika) i rzuca odpowiednie wyjątki przy próbie ich przekroczenia. Posiada również mechanizm naliczania kar dla osób, które nie oddały sprzętu w terminie.
