# SchoolAverageCalculator
[PL]
Główną funkcją aplikacji jest obliczanie średniej z ocen w szkole. Użytkownik wprowadza oceny do programu, może je dodawać, usuwać i zmieniać.
Zamysł aplikacji jest z braku pomysłu, nie wiedziałem jaki projekt mogę stworzyć, by móc wykorzystać wiedzę z kursu.

SCHEMAT APLIKACJI

MainPage
1. See summary
  SummaryPage - wyświetla średnią ważoną i listę ocen
2. Add new mark
  AddMarkPage - proces dodawania nowej oceny (wartość, waga i ewentualny opis)
3. Manage existing marks
  wybór oceny
    EditMarkMage - edycja oceny
4. Close app
  zamyka aplikację

NAWIGACJA

Moim pomysłem na utrudnienie sobie zadanie było dodanie podziału na pliki i dodanie nawigacji (NavigationService) coś na wzór stosu.
Navigation.GoTo(Page) przenosi na stronę
Navigation.GoBack() usuwa najnowszą stronę i powraca do poprzedniej
Navigation.RefreshPage() odświeża aktualnie wyświetloną stronę (na nowo ją rysuje)

Hierarchia Stron

IConsolePage
  BasePage
    ActionPage - służy do wykonywania akcji, klasa pochodna MUSI zamimplementowac metodę Action()
    MenuPage - służy do wyświetlenia menu opcji i decyzji co dalej wykonać
