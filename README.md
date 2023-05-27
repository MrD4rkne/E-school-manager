# SchoolAverageCalculator
[PL]
Główną funkcją aplikacji jest obliczanie średniej z ocen w szkole. Użytkownik wprowadza oceny do programu, może je dodawać, usuwać i zmieniać.
Zamysł aplikacji jest z braku pomysłu, nie wiedziałem jaki projekt mogę stworzyć, by móc wykorzystać wiedzę z kursu.

SCHEMAT APLIKACJI

MainPage

    1. See summary - SummaryPage - wyświetla średnią ważoną i listę ocen
    2. Add new mark - AddMarkPage - proces dodawania nowej oceny (wartość, waga i ewentualny opis)
    3. Manage existing marks - wybór oceny do zarządzanie, potme zmienianie lub usuwanie
    4. Close app - zamyka aplikację

NAWIGACJA

Moim pomysłem na utrudnienie sobie zadanie było dodanie podziału na pliki i dodanie nawigacji (NavigationService) coś na wzór stosu.

    1. Navigation.GoTo(Page) przenosi na stronę;
    2. Navigation.GoBack() usuwa najnowszą stronę i powraca do poprzedniej;
    3. Navigation.RefreshPage() odświeża aktualnie wyświetloną stronę (na nowo ją rysuje);

Hierarchia Stron

    1. IConsolePage (nadrzędny interfejs)
    2.  BasePage (każda strona)
    3.      ActionPage (strona do akcji) - służy do wykonywania akcji, klasa pochodna MUSI zamimplementowac metodę Action()
    4.      MenuPage (strona menu) - służy do wyświetlenia menu opcji i decyzji co dalej wykonać
