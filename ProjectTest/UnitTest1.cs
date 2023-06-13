namespace ProjectTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void CheckAccountEmailTest()
    {
        AccountsLogic accounts = new AccountsLogic();
        string validemail = "di@g.com";
        string invalidemail = "mi@";
        Assert.IsTrue(accounts.CheckEmail(validemail));
        Assert.IsFalse(accounts.CheckEmail(invalidemail));
    }
<<<<<<< Updated upstream
    [DataTestMethod]
    [DataRow(null, null)]
    [DataRow("user@", null)]
    [DataRow(null, "password")]
    [DataRow("di@g.com", "password")]
    [DataRow("email@", "123")]
    [DataRow("di@g.com", "123")]
    public void CheckLoginTest(string email, string password)
=======
    [TestMethod]
    public void AllReservationTest()
    {
        ReservationsLogic reservationLogic = new ReservationsLogic();
        List<int> ressedchairs = new List<int> { 15, 16, 18 };
        ReservationModel tempRes = new ReservationModel(-999, -999, 5, ressedchairs, 25);

        reservationLogic.UpdateList(tempRes);

        List<ReservationModel> allRes = ReservationsLogic.AllReservation();
        var resFound = allRes.FirstOrDefault(x => x.Id == allRes.Id);
        Assert.AreEqual(resFound.Id, tempRes.Id);

        reservationLogic.DeleteReservation(resFound);

    }

    [TestMethod]
    public void CheckLoginTest()
>>>>>>> Stashed changes
    {
        AccountsLogic accounts = new AccountsLogic();
        AccountModel account = accounts.CheckLogin(email, password);
<<<<<<< Updated upstream
        bool accountornot = false;
        if (account == null)
=======

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
    public void GetByRoomidTest()
    {
        ChairModel tempchair = new ChairModel(1000000, 8, 0, 0, "!");
        ChairLogic chairlogic = new ChairLogic();
        chairlogic.UpdateList(tempchair);
        List<ChairModel> currchair = chairlogic.GetByRoomId(8);
        Assert.AreEqual(1, currchair.Count);
        ChairLogic.DeleteChair(1000000);
    }

    [TestMethod]
    public void DeleteChair()
    {
        ChairModel tempchair = new ChairModel(1000000, 8, 0, 0, "!");
        ChairLogic chairlogic = new ChairLogic();
        chairlogic.UpdateList(tempchair);
        ChairLogic.DeleteChair(1000000);
        List<ChairModel> currchair = chairlogic.GetByRoomId(8);
        Assert.AreEqual(0, currchair.Count);
    }

    [TestMethod]
    public void RowNumberTest()
    {
        ChairModel tempchair = new ChairModel(1000000, 8, 999, 999, "!");

        string currchair = ChairLogic.RowNumber(tempchair);
        Assert.AreEqual("!999", currchair);
    }

    [TestMethod]
    public void TakeSeatTest()
    {
        ChairModel tempchair = new ChairModel(1000000, 8, 1, 999, "!");
        ChairLogic.TakeSeat(tempchair);
        Assert.IsTrue(tempchair.takeseat);
    }

    [TestMethod]
    public void RemoveSeatTest()
    {
        ChairModel tempchair = new ChairModel(1000000, 8, 1, 999, "!");
        ChairLogic.TakeSeat(tempchair);
        ChairLogic.RemoveSeat(tempchair);
        Assert.IsFalse(tempchair.takeseat);
    }

    [TestMethod]
    public void DeleteFilm()
    {
        List<string> genre = new List<string> { "horror" };
        FilmModel film = new FilmModel(999, "test1", "test000", 99, 2.5, genre);
        FilmsLogic films = new FilmsLogic();
        films.UpdateList(film);
        films.DeleteFilm(film);
        var exists = films.GetById(film.Id);
        Assert.IsNull(exists);
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

    [TestMethod]
    public void ValidShowYear()
    {
        string invalidYear = "2046-35-35";
        string validYear = "2024-07-22";
        ShowsLogic showLogic = new ShowsLogic();

        Assert.IsTrue(showLogic.ValidShowDate(validYear));
        Assert.IsFalse(showLogic.ValidShowDate(invalidYear));
    }

    [TestMethod]
    public void IncomeShowTest()
    {
        ShowsLogic showLogic = new ShowsLogic();
        ReservationsLogic reservationsLogic = new ReservationsLogic();

        ShowModel tempShow = new ShowModel(-99, -99, 1, "2023-03-15", "12:00");
        List<int> tempChairID = new List<int> { 40, 41, 42, 43 };
        ReservationModel tempReservation = new ReservationModel(-99, -99, -99, tempChairID, 36.0);

        showLogic.UpdateList(tempShow);
        reservationsLogic.UpdateList(tempReservation);

        double totalIncome = ReservationsLogic.IncomeShow(-99);
        Assert.AreEqual(36, totalIncome);
        //barreservation deleten

        showLogic.DeleteShow(tempShow);
        reservationsLogic.DeleteReservation(tempReservation);
    }

    [TestMethod]
    public void AllCurrentFilmsTest()
    {
        FilmsLogic filmsLogic = new FilmsLogic();
        List<string> genre = new List<string> { "horror" };
        FilmModel tempFilm = new FilmModel(-999, "test1", "test000", 99, 2.5, genre);

        filmsLogic.UpdateList(tempFilm);

        List<FilmModel> allCurrentFilms = FilmsLogic.AllCurrentFilms();
        var filmFound = allCurrentFilms.FirstOrDefault(x => x.Id == tempFilm.Id);
        Assert.AreEqual(filmFound.Id, tempFilm.Id);

        filmsLogic.DeleteFilm(filmFound);

    }

    [TestMethod]
    public void IncomeRankTest()
    {
        ShowsLogic showLogic = new ShowsLogic();
        ReservationsLogic reservationsLogic = new ReservationsLogic();

        ShowModel tempShow = new ShowModel(-100, -100, 1, "2023-03-22", "10:59");
        List<int> tempChairID = new List<int> { 40, 41 };
        ReservationModel tempReservation = new ReservationModel(-100, -100, -100, tempChairID, 16.0);

        showLogic.UpdateList(tempShow);
        reservationsLogic.UpdateList(tempReservation);

        double totalAmount = ReservationsLogic.IncomeRank(-100, 3);

        Assert.AreEqual(16, totalAmount);

        showLogic.DeleteShow(tempShow);
        reservationsLogic.DeleteReservation(tempReservation);
    }

    [TestMethod]
    public void IncomeDateTest()
    {
        ShowsLogic showLogic = new ShowsLogic();
        ReservationsLogic reservationsLogic = new ReservationsLogic();

        ShowModel tempShow = new ShowModel(-101, -101, 1, "2023-03-22", "10:59");
        List<int> tempChairID = new List<int> { 40, 41 };
        ReservationModel tempReservation = new ReservationModel(-101, -101, -101, tempChairID, 16.0);

        showLogic.UpdateList(tempShow);
        reservationsLogic.UpdateList(tempReservation);

        double totalAmount = ReservationsLogic.IncomeDate("2023-03-22");

        Assert.AreEqual(16, totalAmount);

        showLogic.DeleteShow(tempShow);
        reservationsLogic.DeleteReservation(tempReservation);
    }

    [TestMethod]
    public void DeleteShowTest()
    {
        ShowsLogic showLogic = new ShowsLogic();
        ShowModel tempShow = new ShowModel(-101, -101, 1, "2023-03-22", "10:59");

        showLogic.UpdateList(tempShow);
        ShowModel showFound = showLogic.GetById(tempShow.Id);
        Assert.IsNotNull(showFound);

        showLogic.DeleteShow(tempShow);
        ShowModel showFound2 = showLogic.GetById(tempShow.Id);
        Assert.IsNull(showFound2);

    }

    [TestMethod]
    public void ValidShowDateTest()
    {
        string invalidDate = "2023-35-35";
        string validDate = "2023-03-22";
        ShowsLogic showLogic = new ShowsLogic();

        Assert.IsTrue(showLogic.ValidShowDate(validDate));
        Assert.IsFalse(showLogic.ValidShowDate(invalidDate));
    }

    [TestMethod]
    public void AllCurrentShowsTest()
    {
        ShowsLogic showLogic = new ShowsLogic();
        ShowModel tempShow = new ShowModel(-101, -101, 1, "2023-03-22", "10:59");
        showLogic.UpdateList(tempShow);
        List<ShowModel> allCurrentShows = ShowsLogic.AllCurrentShows();
        ShowModel showFound = allCurrentShows.Find(x => x.Id == tempShow.Id);
        Assert.IsNotNull(showFound);
        showLogic.DeleteShow(showFound);
    }

    // public void CheckAllFilmsTest()
    // {
    //     ???
    // }

    [TestMethod]
    public void CheckReservationsByAccountTest()
    {

        AccountModel account = new AccountModel(100000, "test@", "test", "test test");
        AccountsLogic accounts = new AccountsLogic();
        accounts.UpdateList(account);

        ReservationsLogic reservationlogic = new ReservationsLogic();
        List<int> chairs = new List<int>();
        chairs.Add(12);
        chairs.Add(17);
        chairs.Add(18);
        ReservationModel model = new ReservationModel(999, 3, 100000, chairs, 12.50);
        reservationlogic.UpdateList(model);

        List<ReservationModel> reservations = ReservationsAccess.LoadAll();
        List<ReservationModel> MyReservations = new List<ReservationModel>();
        foreach (ReservationModel reservation in reservations)
>>>>>>> Stashed changes
        {
            accountornot = true;
            Assert.IsTrue(accountornot);
        }
        else
        {
            Assert.IsFalse(accountornot);
            Assert.AreEqual("Diana Faliuta", account.FullName);
        }
    }
}