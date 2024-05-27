using AutoMapper;
using ReserveSystem.Database;
using ReserveSystem.Interfaces;
using ReserveSystem.Models;
using ReserveSystem.ViewModels;

namespace ReserveSystem.Services;

public class LoginService : ILoginService
{
    private readonly MyDbContext _dbContext;
    private readonly IMapper _mapper;

    public LoginService(MyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public bool IsValid(string username, string password)
    {
        // Zkontroluje, zda uživatelské jméno a heslo nejsou prázdné nebo null
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return false;
        }

        // Najde záznam v databázi podle uživatelského jména
        var user = _dbContext.Logins.FirstOrDefault(l => l.Username == username);

        // Pokud uživatel s daným uživatelským jménem neexistuje, nebo heslo neodpovídá, vrátí false
        if (user == null || user.Password != password)
        {
            return false;
        }

        // Přihlášení bylo úspěšné
        return true;
    }

    public List<LoginViewModel> GetAll()
    {
        // Načte všechny záznamy z databáze
        var loginDbModels = _dbContext.Logins.ToList();

        // Zkontroluje, zda nějaké záznamy existují
        if (loginDbModels == null || !loginDbModels.Any())
        {
            return new List<LoginViewModel>();
        }

        // Namapuje seznam entit na seznam view modelů pomocí AutoMapperu
        var loginViewModels = _mapper.Map<List<LoginViewModel>>(loginDbModels);

        return loginViewModels;
    }
    
    public bool CreateLogin(LoginViewModel loginViewModel)
    {
        // Pokud není loginViewModel inicializován (je null), vrátíme false
        if (loginViewModel == null)
        {
            return false;
        }

        // Pokud nejsou vyplněny žádné údaje pro uživatelské jméno a heslo, vrátíme false
        if (string.IsNullOrEmpty(loginViewModel.Username) && string.IsNullOrEmpty(loginViewModel.Password))
        {
            return false;
        }

        // Mapujeme data z loginViewModel na Login objekt, který odpovídá struktuře databázové tabulky
        var loginDbModel = _mapper.Map<Login>(loginViewModel);

        // Přidáme tento nový Login objekt do kontextu databáze
        _dbContext.Logins.Add(loginDbModel);

        // Uložíme změny do databáze a zkontrolujeme, zda byly uloženy úspěšně
        if (_dbContext.SaveChanges() > 0)
        {
            // Pokud byla alespoň jedna změna uložena, vrátíme true
            return true;
        }

        // Pokud žádná změna nebyla uložena, vrátíme false
        return false;
    }

    public LoginViewModel GetById(int id)
    {
        // Zkontroluje, zda ID není neplatné
        if (id <= 0)
        {
            return null;
        }

        // Najde záznam podle ID v databázi
        var loginDbModel = _dbContext.Logins.Find(id);

        // Pokud záznam nebyl nalezen, vrátí null
        if (loginDbModel == null)
        {
            return null;
        }

        // Namapuje nalezený záznam na LoginViewModel pomocí AutoMapperu
        var loginViewModel = _mapper.Map<LoginViewModel>(loginDbModel);

        return loginViewModel;
    }

    public LoginViewModel GetByName(string username)
    {
        // Zkontroluje, zda uživatelské jméno není prázdné nebo null
        if (string.IsNullOrEmpty(username))
        {
            return null;
        }

        // Najde záznam podle uživatelského jména v databázi
        var loginDbModel = _dbContext.Logins.FirstOrDefault(l => l.Username == username);

        // Pokud záznam nebyl nalezen, vrátí null
        if (loginDbModel == null)
        {
            return null;
        }

        // Namapuje nalezený záznam na LoginViewModel pomocí AutoMapperu
        var loginViewModel = _mapper.Map<LoginViewModel>(loginDbModel);
        return loginViewModel;
    }
}