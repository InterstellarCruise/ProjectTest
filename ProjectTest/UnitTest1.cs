using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ProjectTest;


[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void CheckGetShows()
    {
        ShowsLogic showlogic = new ShowsLogic();
        ShowModel tempshow = new ShowModel(-99, -99, 1, "2023-03-15", "12:00");
        showlogic.UpdateList(tempshow);
        List<ShowModel> showModels = showlogic.GetShows();
        ShowModel showfound = showModels.FirstOrDefault(x => x.Id == tempshow.Id);
        Assert.AreEqual(showfound.Id, tempshow.Id);
        showlogic.DeleteShow(showfound);
    }
    [TestMethod]
    public void CheckGetFilms()
    {
        FilmsLogic filmlogic = new FilmsLogic();
        List<String> genre = new List<string> { "horror" };
        FilmModel tempfilm = new FilmModel(-99, "test", "test", 99, 2.5, genre);
        filmlogic.UpdateList(tempfilm);
        List<FilmModel> filmModels = filmlogic.GetFilms();
        FilmModel filmfound = filmModels.FirstOrDefault(x => x.Id == tempfilm.Id);
        Assert.AreEqual(filmfound.Id, tempfilm.Id);
        filmlogic.DeleteFilm(filmfound);
    }
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
    public void IncomeShowTest()
    {
        ShowsLogic showLogic = new ShowsLogic();
        ReservationsLogic reservationsLogic = new ReservationsLogic();
        
        ShowModel tempShow = new ShowModel(-99, -99, 1, "2023-03-15", "12:00");
        List<int> tempChairID = new List<int>{40, 41, 42, 43};
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
    public void AllCurrShowsTest()
    {

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

