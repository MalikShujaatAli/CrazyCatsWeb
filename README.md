# Crazy Cats — Pet Adoption Website

An **ASP.NET Core 8 MVC** website for an animal shelter: browse animals available for adoption, submit an
adoption application, contact the shelter, and donate. Server-rendered with Razor views over Entity
Framework Core and SQL Server.

Built in December 2024 as a university web development project — my first full MVC application.

---

## Stack

| | |
|---|---|
| Framework | ASP.NET Core 8 MVC |
| Views | Razor (`.cshtml`), shared `_Layout` |
| Data | Entity Framework Core 9, SQL Server (database-first scaffold) |
| Styling | Custom CSS + SCSS, Bootstrap |

## Pages

| Controller | What it serves |
|---|---|
| `Home` | Landing page, featured animals, privacy page |
| `About` | Shelter information and animal detail pages |
| `Contact` | Contact form |
| `Donation` | Donation page |
| `Register` | Account creation |
| `Login` | Sign in |
| `Reset` | Password reset request and confirmation |

---

## Data model

```
Animal  (Id, Name, Species, Breed, Age, Description, IsAdopted, ImageUrl)
   │
   └──< AdoptionApplication  (Id, ApplicantName, ApplicantEmail, AnimalId, Message, IsApproved)

User    (Id, Username, Password, Email)
```

`Animal` carries an `IsAdopted` flag and a collection of applications, so one animal can receive several
applications and a staff member approves one of them (`IsApproved`). The model classes are `partial` —
they were scaffolded from an existing SQL Server database with `dotnet ef dbcontext scaffold` rather than
written code-first. `quereis.sql` in the repository root holds the schema.

---

## Running it

Needs the .NET 8 SDK and SQL Server (LocalDB is fine).

```bash
# point appsettings.json → ConnectionStrings at your SQL Server instance
# then create the schema from quereis.sql

dotnet restore
dotnet run
```

---

## Known limitations

This is an early project and it shows. Listed in the order I would fix them:

1. **Passwords are stored as plain strings.** `User.Password` is a `string` with no hashing anywhere in
   the codebase. This is the first and most serious thing to change — BCrypt or ASP.NET Core Identity.
2. **No authorisation on anything.** The login page exists, but no controller checks whether a request is
   authenticated, so every page is reachable by anyone.
3. **`node_modules` is committed** under `wwwroot/vender/` and enumerated file-by-file in the `.csproj`.
   That is why this repository is 11 MB. Front-end dependencies belong in a package manifest, not in
   version control.
4. **A WPF package reference (`Extended.Wpf.Toolkit`) is in a web project** — leftover from a template and
   doing nothing.
5. **No validation or anti-forgery handling** on the form posts.
6. **No tests.**

If you want to see what I build now rather than at the end of 2024, look at the other repositories on
[my profile](https://github.com/MalikShujaatAli) — the difference between this and them is the point.

## Built by

Malik Shujaat Ali — [github.com/MalikShujaatAli](https://github.com/MalikShujaatAli) ·
[linkedin.com/in/malik-shujaat-ali](https://www.linkedin.com/in/malik-shujaat-ali)
