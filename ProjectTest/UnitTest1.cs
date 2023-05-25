namespace ProjectTest;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void CheckAccountEmailTest()
    {
        AccountsLogic accounts = new AccountsLogic();
        string validemail = "test@";
        string validpassword = "test";
        string fullname = "test test";
        accounts.NewAcc(validemail, validpassword, fullname);
        string invalidemail = "testttt@";

        Assert.IsTrue(accounts.CheckEmail(validemail));
        Assert.IsFalse(accounts.CheckEmail(invalidemail));
        accounts.RemoveAcc(validemail);
    }
    [TestMethod]
    public void CheckLoginTest()
    {
        AccountsLogic accounts = new AccountsLogic();
        string email = "test@";
        string password = "test";
        string fullname = "test test";
        accounts.NewAcc(email, password, fullname);
        AccountModel account = accounts.CheckLogin(email, password);

        Assert.AreEqual("test test", account.FullName);
        accounts.RemoveAcc(email);
    }
    [TestMethod]
    public void NewAccTest()
    {
        AccountModel account = new AccountModel(100000, "test@", "test", "test test");
        AccountsLogic accounts = new AccountsLogic();
        accounts.UpdateList(account);
        AccountModel accountfound = accounts.GetById(100000);

        Assert.AreEqual(accountfound.FullName, account.FullName);
        accounts.RemoveAcc(account.EmailAddress);
    }
    [TestMethod]
    public void RemoveAcc()
    {
        AccountModel account = new AccountModel(100000, "test@", "test", "test test");
        AccountsLogic accounts = new AccountsLogic();
        accounts.UpdateList(account);
        accounts.RemoveAcc(account.EmailAddress);
        AccountModel accountfound = accounts.GetById(100000);
        Assert.IsNull(accountfound);
    }
    [TestMethod]
    public void CheckLastIDTest()
    {

        int id = 99999;
        List<string> genres = new List<string>();
        genres.Add("Horror");
        FilmModel film = new FilmModel(id, "Unit", "test", 0, 2.5, genres);
        FilmsLogic filmlogic = new FilmsLogic();
        filmlogic.UpdateList(film);
        List<FilmModel> _films;
        _films = FilmsAccess.LoadAll();
        int last = _films[_films.Count - 1].Id;
        Assert.AreEqual(id, last);
    }
    public void CheckAllFilmsTest()
    {

    }
    public void CheckReservationsByAccountTest()
    {

    }
    public void CheckDeleteReservationTest()
    {

    }
    public void CheckMoviesByDateTest()
    {

    }
    public void CheckChooseShowTest()
    {

    }
    public void CheckShowsByDateTest()
    {

    }
    public void CheckValidShowTimeTest()
    {

    }
}

