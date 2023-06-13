using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ProjectTest;


[TestClass]
public class UnitTest1
{
    //[TestMethod]
    //public void CheckGetShows()
    //{
    //    ShowsLogic showlogic = new ShowsLogic();
    //    ShowModel tempshow = new ShowModel(-99, -99, 1, "2023-03-15", "12:00");
    //    showlogic.UpdateList(tempshow);
    //    List<ShowModel> showModels = Showlogic.GetShows();
    //    ShowModel showfound = showModels.FirstOrDefault(x => x.Id == tempshow.Id);
    //    Assert.AreEqual(showfound.Id, tempshow.Id);
    //    showlogic.DeleteShow(showfound);
    //}

    //[TestMethod]
    //public void CheckGetFilms()
    //{
    //    FilmsLogic filmlogic = new FilmsLogic();
    //    List<String> genre = new List<string> { "horror" };
    //    FilmModel tempfilm = new FilmModel(-99, "test", "test", 99, 2.5, genre);
    //    filmlogic.UpdateList(tempfilm);
    //    List<FilmModel> filmModels = filmlogic.GetFilms();
    //    FilmModel filmfound = filmModels.FirstOrDefault(x => x.Id == tempfilm.Id);
    //    Assert.AreEqual(filmfound.Id, tempfilm.Id);
    //    filmlogic.DeleteFilm(filmfound);
    //}

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
    public void GetByShowIdTest()
    {
        List<int> ressedchairs = new List<int> { 16, 17, 18 };
        ShowModel tempShow = new ShowModel(99, -99, 1, "2023-03-15", "12:00");
        ReservationModel tempRes = new ReservationModel(-999, 99, 1, ressedchairs, 25);
        ReservationsLogic reservationsLogic = new ReservationsLogic();
        reservationsLogic.UpdateList(tempRes);
        ShowsLogic showsLogic = new ShowsLogic();
        showsLogic.UpdateList(tempShow);
        List<ReservationModel> currRes = reservationsLogic.GetByShowId(99, 1);
        Assert.AreEqual(1, currRes.Count);
        // ReservationsLogic.DeleteReservation(tempRes);
        // ShowsLogic.DeleteShow(tempShow);
    }

    [TestMethod]
    public void GetbyShowListTest()
    {
        List<int> ressedchairs = new List<int> { 16, 17, 18 };
        ReservationModel tempRes = new ReservationModel(-999, 99, 1, ressedchairs, 25);
        ReservationsLogic reservationsLogic = new ReservationsLogic();
        var currRes = reservationsLogic.GetByShowIdList(99);
        int count = new List<ReservationModel>(currRes).Count;
        Assert.AreEqual(1, count);
    }

    [TestMethod]
    public void FindByShowIdTest()
    {
        List<int> ressedchairs = new List<int> { 16, 17, 18 };
        ReservationModel tempRes = new ReservationModel(-999, 99, 1, ressedchairs, 25);
        ReservationsLogic reservationsLogic = new ReservationsLogic();
        reservationsLogic.UpdateList(tempRes);
        List<ReservationModel> currRes = reservationsLogic.GetByShowId(99, 1);
        Assert.AreEqual(1, currRes.Count);
        // ReservationsLogic.DeleteReservation(tempRes);
        // ShowsLogic.DeleteShow(tempShow);
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
    public void AllReservationTest()
    {
        ReservationsLogic reservationsLogic = new ReservationsLogic();
        List<int> ressedchairs = new List<int> { 16, 17, 18 };
        ReservationModel tempRes = new ReservationModel(-999, -999, 1, ressedchairs, 24);
        reservationsLogic.UpdateList(tempRes);
        List<ReservationModel> allRes = ReservationsLogic.AllReservation();
        ReservationModel resFound = allRes.Find(x => x.Id == tempRes.Id);
        Assert.AreEqual(resFound.Id, tempRes.Id);

        reservationsLogic.DeleteReservation(resFound);
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
    public void ValidShowYear()
    {
        string invalidYear = "2046-35-35";
        string validYear = "2024-07-22";
        ShowsLogic showLogic = new ShowsLogic();

        Assert.IsTrue(showLogic.ValidShowDate(validYear));
        Assert.IsFalse(showLogic.ValidShowDate(invalidYear));
    }

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
        {

            if (reservation.Accountid == 100000)
            {
                MyReservations.Add(reservation);
            }
        }

        Assert.IsNotNull(MyReservations);

    }

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

    [TestMethod]
    public void CheckShowsByDateTest()
    {
        ShowsLogic showlogic = new ShowsLogic();
        Assert.IsFalse(showlogic.ValidShowDate("2023-35-35"));
        Assert.IsTrue(showlogic.ValidShowDate("2023-12-12"));
    }

    [TestMethod]
    public void CheckValidShowTimeTest()
    {
        ShowsLogic showlogic = new ShowsLogic();
        Assert.IsFalse(showlogic.ValidShowTime("25:30"));
        Assert.IsTrue(showlogic.ValidShowTime("12:30"));
    }

    [TestMethod]
    public void CheckRoomAvailableTest()
    {
        string inputdate = "2023-03-15";
        List<ShowModel> showsondate = ShowsLogic.ShowsByDate(inputdate);
        Assert.IsFalse(RoomsLogic.AvailableCheck(showsondate, "15:30"));
    }

    [TestMethod]
    public void CheckValidTimeTest()
    {
        string time = "25:30";
        string time2 = "22:30";
        int[] hm = new int[0];
        hm = time.Split(":").Select(int.Parse).ToArray();


        int[] hm2 = new int[0];
        hm2 = time2.Split(":").Select(int.Parse).ToArray();
        Assert.IsFalse(RoomsLogic.ValidTime(hm, true));
        Assert.IsTrue(RoomsLogic.ValidTime(hm2, true));
    }
    [TestMethod]
    public void AllFilmsTest()
    {
        FilmsLogic films = new FilmsLogic();
        FilmsLogic.AllFilms(new List<FilmModel> { new FilmModel(-99, "testop", "testop", 12, 2.5, new List<string> { "horror" }) });
        Dictionary<string, int> dic = FilmsLogic.FilmInfo;
        Assert.IsTrue(dic.ContainsKey($"Film name: testop."));
    }
    [TestMethod]
    public void OccupiedSeatsTest()
    {
        ReservationModel reservation = new(-100, -100, -100, new List<int> { 15, 16, }, 16);
        ReservationsLogic reservationLogic = new ReservationsLogic();
        reservationLogic.UpdateList(reservation);
        var count = ChairLogic.OccupiedSeats(reservation.Id, 3);
        Assert.AreEqual(2, count);
        reservationLogic.DeleteReservation(reservation);
    }
    [TestMethod]
    public void DeleteRoomTest()
    {
        RoomsLogic roomsLogic = new RoomsLogic();
        RoomModel roomModel = new(-99, 10, 10, 100);
        roomsLogic.UpdateList(roomModel);
        RoomModel roomFound = roomsLogic.GetById(roomModel.Id);
        Assert.IsNotNull(roomFound);
        roomsLogic.DeleteRoom(roomFound);
    }

<<<<<<< HEAD
    [TestMethod]
    public void CheckLastFilmIDTest()
    {
        int id = FilmsLogic.LastID() + 1;
        List<string> genres = new List<string>();
        genres.Add("Horror");
        FilmModel film = new FilmModel(id, "Unit", "test", 0, 2.5, genres);
        FilmsLogic filmlogic = new FilmsLogic();
        filmlogic.UpdateList(film);
        List<FilmModel> _films;
        _films = FilmsAccess.LoadAll();

        Assert.AreEqual(FilmsLogic.LastID(), _films.Count());
    }


    [TestMethod]
    public void CheckLastShowIDTest()
    {
        int id = ShowsLogic.LastID() + 1;
        int movieID = FilmsLogic.LastID();
        List<string> genres = new List<string>();
        genres.Add("Horror");
        ShowModel show = new ShowModel(id, movieID, 2, "2023-08-15", "15:30");
        ShowsLogic showlogic = new ShowsLogic();
        showlogic.UpdateList(show);
        List<ShowModel> _shows;
        _shows = ShowsAccess.LoadAll();

        Assert.AreEqual(ShowsLogic.LastID(), _shows.Count());
    }
=======
    [DataTestMethod]
    [DynamicData(nameof(GetTestModels), typeof(UnitTest1), DynamicDataSourceType.Method)]
    public void UpdateListTest<T>(T model)
    {
        // Test code here
        AccountsLogic accountsLogic = new AccountsLogic();
        BarLogic barsLogic = new BarLogic();
        ChairLogic chairsLogic = new ChairLogic();
        FilmsLogic filmsLogic = new FilmsLogic();
        ReservationsLogic reservationsLogic = new ReservationsLogic();
        RoomsLogic roomsLogic = new RoomsLogic();
        ShowsLogic showsLogic = new ShowsLogic();
        Type modelType = typeof(T);
        if (modelType == typeof(AccountModel))
        {
            AccountModel accountModel = (AccountModel)(object)model;
            accountsLogic.UpdateList(accountModel);
            AccountModel accountFound = accountsLogic.GetById(accountModel.Id);
            Assert.IsNotNull(accountFound);
            accountsLogic.RemoveAcc(accountFound.EmailAddress);
        }
        else if (modelType == typeof(BarModel))
        {
            BarModel barModel = (BarModel)(object)model;
            barsLogic.UpdateList(barModel);
            BarModel barFound = barsLogic.GetById(barModel.Id);
            Assert.IsNotNull(barFound);
        }
        else if (modelType == typeof(ChairModel))
        {
            ChairModel chairModel = (ChairModel)(object)model;
            chairsLogic.UpdateList(chairModel);
            ChairModel chairFound = chairsLogic.GetById(chairModel.Id);
            Assert.IsNotNull(chairFound);
            ChairLogic.DeleteChair(chairFound.Id);
        }
        else if (modelType == typeof(FilmModel))
        {
            FilmModel filmModel = (FilmModel)(object)model;
            filmsLogic.UpdateList(filmModel);
            FilmModel filmFound = filmsLogic.GetById(filmModel.Id);
            Assert.IsNotNull(filmFound);
            filmsLogic.DeleteFilm(filmFound);
        }
        else if (modelType == typeof(ReservationModel))
        {
            ReservationModel reservationModel = (ReservationModel)(object)model;
            reservationsLogic.UpdateList(reservationModel);
            ReservationModel reservationFound = reservationsLogic.GetById(reservationModel.Id);
            Assert.IsNotNull(reservationFound);
            reservationsLogic.DeleteReservation(reservationFound);
        }
        else if (modelType == typeof(RoomModel))
        {
            RoomModel roomModel = (RoomModel)(object)model;
            roomsLogic.UpdateList(roomModel);
            RoomModel roomFound = roomsLogic.GetById(roomModel.Id);
            Assert.IsNotNull(roomFound);
            roomsLogic.DeleteRoom(roomFound);
        }
        else if (modelType == typeof(ShowModel))
        {
            ShowModel showModel = (ShowModel)(object)model;
            showsLogic.UpdateList(showModel);
            ShowModel showFound = showsLogic.GetById(showModel.Id);
            Assert.IsNotNull(showFound);
            showsLogic.DeleteShow(showFound);

        }
    }
    public static IEnumerable<object[]> GetTestModels<T>()
    {
        yield return new object[] { new AccountModel(-99, "@@@", "@@@", "Testie test") };
        yield return new object[] { new BarModel(-99, "2023-06-13", -99, -99, "12:00", 2) };
        yield return new object[] { new ChairModel(-99, -99, 3, 100, "XYZ") };
        yield return new object[] { new FilmModel(-99, "Testie", "Testie test", 12, 3.4, new List<string> { "test" }) };
        yield return new object[] { new ReservationModel(-99, -99, -99, new List<int> { 607, 608 }, 24) };
        yield return new object[] { new RoomModel(-99, 10, 10, 100) };
        yield return new object[] { new ShowModel(-99, -99, -99, "2023-06-13", "12:00") };
        // Add more test models here
    }
    
>>>>>>> Unittest_milan
}

