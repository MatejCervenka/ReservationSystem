# Rezervační Systém pro Kadeřnictví
Tento rezervační systém může být využit pro jakékoli služby, aby mohli zákazníci snadno provádět rezervace a správci mohli spravovat rezervace. Webová aplikace je postavena na platformě ASP.NET Core s využitím Entity Frameworku pro práci s databází, AutoMapperu pro mapování databázových entit a Razor Pages pro tvorbu uživatelského rozhraní.
Zde je jako příklad služby používající tento systém Kadeřnictví.

---

## Funkcionality
**Uživatelská One-Page Stránka:** Skládá se ze tří sekcí:
  - **Intro:** Informace o podniku/službě a tlačítko pro přesun na rezervační formulář.
  - **Ceník a Formulář:** Ceník nabízených služeb a formulář pro rezervaci.
  - **Kontakty:** Telefonní čísla, email a adresa.
  
**Admin Přístup:** Stránka pro přihlášení adminů, kde po správném zadání přihlašovacích údajů mají přístup ke stránce se seznamem rezervací.

---

## Databázová Struktura
Systém využívá SQL databázi se čtyřmi hlavními tabulkami:

**Logins**
  - **Username:** Uživatelské jméno admina.
  - **Password:** Heslo admina.

**Reservations**
  - **FirstName:** Jméno zákazníka.
  - **LastName:** Příjmení zákazníka.
  - **Phone:** Telefon zákazníka.
  - **Email:** Email zákazníka.
  - **ServiceId:** FK k ID služby z tabulky Services.
  - **CreatedAt:** Datum a čas vytvoření rezervace.

**Services**
  - **Name:** Název služby.

**Pricing**
  - **Title:** Název služby.
  - **Description:** Popis služby.
  - **Amount:** Cena služby.
  - **SaleAmount:** Cena po slevě (pokud je sleva).
  - **Currency:** Měna.

---

## Použití
**Uživatelská Stránka**
  - **Intro Sekce: Stručné představení podniku a tlačítko pro přesun na rezervační formulář.
  - **Ceník a Formulář: Zobrazení ceníku služeb a formulář pro vytvoření nové rezervace.
  - **Kontakty: Kontaktní údaje na podnik.

**Admin Sekce**
  - **Přihlášení:**
    - Admin se přihlásí pomocí uživatelského jména a hesla.
  - **Seznam Rezervací:**
    - Po přihlášení se admin dostane na stránku se seznamem všech rezervací.
    - Každá rezervace je zobrazena v řádku a obsahuje tlačítko s ikonou tří teček. Po kliknutí na toto tlačítko se zobrazí další **tři možnosti**
  - **Možnosti:**  ***(Prozatím neimplementováno)***
    - **Kopírovat Email:** Po stisknutí této možnosti se automaticky zkopíruje emailová adresa dané rezervace do schránky. Tuto adresu pak můžete vložit do poštovního klienta pro zasílání emailů.
    - **Editovat Rezervaci:** Po stisknutí této možnosti se zobrazí nová stránka, kde můžete editovat údaje dané rezervace. Zde můžete aktualizovat jméno zákazníka, telefonní číslo, email nebo vybrat jinou službu.
    - **Smazat Rezervaci:** Po stisknutí této možnosti se daná rezervace smaže z databáze a již nebude zobrazena v seznamu rezervací.

    
---

## Technologie
  - **Backend:** ASP.NET Core
  - **Databáze:** SQL Server
  - **ORM:** Entity Framework Core
  - **Mapping:** AutoMapper
  - **Frontend:** Razor Pages

### Entity Framework
  - **Entity Framework:** Používá se k práci s databází. Obsahuje entity, které odpovídají tabulkám v databázi, a DbContext třídu pro komunikaci s databází.

### AutoMapper
  - **AutoMapper:** Používá se pro mapování mezi databázovými entitami a viewModely, které se používají ve webových stránkách.

### Rayor Pages
  - **Razor Pages:** Používají se k tvorbě uživatelského rozhraní. Razor Pages kombinují HTML a C# kód a umožňují dynamické generování obsahu na webových stránkách.
