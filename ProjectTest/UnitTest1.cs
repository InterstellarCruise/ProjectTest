namespace ProjectTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void CheckAccountEmailTest()
    {
        // AccountsLogic accounts = new AccountsLogic();
        // string validemail = "di@g.com";
        // string invalidemail = "mi@";
        // Assert.IsTrue(accounts.CheckEmail(validemail));
        // Assert.IsFalse(accounts.CheckEmail(invalidemail));
    }
    // [DataTestMethod]
    // [DataRow(null, null)]
    // [DataRow("user@", null)]
    // [DataRow(null, "password")]
    // [DataRow("di@g.com", "password")]
    // [DataRow("email@", "123")]
    // [DataRow("di@g.com", "123")]


    // [TestMethod]
    // public void CheckLoginTest(string email, string password)
    // {
    //     AccountsLogic accounts = new AccountsLogic();
    //     AccountModel account = accounts.CheckLogin(email, password);
    //     bool accountornot = false;
    //     if (account == null)
    //     {
    //         accountornot = true;
    //         Assert.IsTrue(accountornot);
    //     }
    //     else
    //     {
    //         Assert.IsFalse(accountornot);
    //         Assert.AreEqual("Diana Faliuta", account.FullName);
    //     }
    // }
    [TestMethod]
    public void CheckLastIDTest()
    {

        int id = 99999;
        List<string> genres = new List<string>();
        genres.Add("Horror");
        FilmModel film = new FilmModel(id, "Unit", "test", 0, 2.5, genres);
        FilmsLogic filmlogic = new FilmsLogic();
        filmlogic.UpdateList(film);
        // FilmsAccess.Add(film);
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
