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
    // public void CheckAllFilmsTest()
    // {
    //     ???
    // }
    // public void CheckReservationsByAccountTest()
    // {
    //     ???
    // }

    [TestMethod]
    public void CheckDeleteReservationTest()
    {
        ReservationsLogic reservationlogic = new ReservationsLogic();
        List<int> chairs = new List<int>();
        chairs.Add(12);
        chairs.Add(17);
        chairs.Add(18);
        ReservationModel model = new ReservationModel(999, 3, 1, chairs, 12.50);
        reservationlogic.UpdateList(model);
        Assert.IsNotNull(reservationlogic.GetById(999));

        List<ReservationModel> reservations = ReservationsAccess.LoadAll();
        ReservationModel x = reservationlogic.GetById(999);
        reservationlogic.DeleteReservation(x);
        ReservationsAccess.WriteAll(reservations);
        ReservationModel res = reservationlogic.GetById(999);
        Assert.IsNull(res);
    }
    [TestMethod]
    public void CheckMoviesByDateTest()
    {
        int id = 99999;
        ShowModel show = new ShowModel(id, 1, 1, "2999-03-03", "12:30");
        ShowsLogic showlogic = new ShowsLogic();
        showlogic.UpdateList(show);
        List<ShowModel> Shows = ShowsAccess.LoadAll();
        Assert.IsTrue(ShowsLogic.MoviesByDate(Shows, "2999-03-03", false));
        Assert.IsFalse(ShowsLogic.MoviesByDate(Shows, "2999-09-09", false));
    }
    // public void CheckChooseShowTest()
    // {
    // Not used!
    // }
    public void CheckShowsByDateTest()
    {
        ShowsLogic showlogic = new ShowsLogic();
        Assert.IsFalse(showlogic.ValidShowDate("2023-13-13"));
        Assert.IsTrue(showlogic.ValidShowDate("2023-12-12"));
    }
    [TestMethod]
    public void CheckValidShowTimeTest()
    {
        ShowsLogic showlogic = new ShowsLogic();
        Assert.IsFalse(showlogic.ValidShowTime("25:30"));
        Assert.IsTrue(showlogic.ValidShowTime("12:30"));
    }
}